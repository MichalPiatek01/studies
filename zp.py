from datetime import datetime

from WezelBST import WezelBST
from graf.graf import Graf


### do innego modułu na kolosie
class ActionNode:
    def __init__(self, text: str):
        self.text = text
        self.timestamp = datetime.now()
        self.prev = None
        self.next = None

    def __repr__(self):
        return f"ActionNode(text={self.text!r}, time={self.timestamp.strftime('%H:%M:%S')})"



class TextHistory:
    def __init__(self):
        self.head = None
        self.tail = None
        self.current = None

    def add_action(self, text: str):
        new_node = ActionNode(text)

        if self.head is None:
            self.head = self.tail = self.current = new_node
            return

        if self.current is not self.tail:
            node = self.current.next
            while node:
                next_node = node.next
                node.prev = None
                node.next = None
                node = next_node
            self.current.next = None
            self.tail = self.current

        self.tail.next = new_node
        new_node.prev = self.tail
        self.tail = new_node
        self.current = new_node

    def undo(self):
        if self.current is None:
            return None

        if self.current.prev is None:
            return None

        self.current = self.current.prev
        return self.current.text

    def redo(self):
        if self.current is None:
            return None

        if self.current.next is None:
            return None

        self.current = self.current.next
        return self.current.text

    def show_current_state(self):
        if self.current is None:
            print("Brak akcji w historii.")
        else:
            print(f"Aktualna operacja: {self.current.text}")

def demo_text_history():
    historia = TextHistory()

    historia.add_action("Wpisano zdanie A")
    historia.add_action("Wpisano zdanie B")
    historia.add_action("Wpisano zdanie C")

    historia.show_current_state()

    print("UNDO 1:", historia.undo())
    print("UNDO 2:", historia.undo())

    historia.show_current_state()

    print("REDO 1:", historia.redo())
    historia.show_current_state()

    historia.add_action("Wpisano zdanie D")
    historia.show_current_state()



### nowy moduł

class Wezel:
    def __init__(self, isbn, tytul):
        self.isbn = isbn
        self.tytul = tytul
        self.licznik_sztuk = 1

        self.left = None
        self.right = None

    def __str__(self):
        return f"[{self.isbn}] {self.tytul} - Ilosc: {self.licznik_sztuk}"

class DrzewoBST:
    def __init__(self):
        self.root = None

    def insertValue(self, isbn, tytul):
        nowy = WezelBST(isbn, tytul)

        if self.root is None:
            self.root = nowy
            return

        curr = self.root

        while True:
            if isbn == curr.isbn:
                curr.licznik_sztuk += 1
                return
            elif isbn < curr.isbn:
                if curr.left is None:
                    curr.left = nowy
                    return
                curr = curr.left
            else:
                if curr.right is None:
                    curr.right = nowy
                    return
                curr = curr.right

    def inorder(self, tree=None):
        if tree is None:
            tree = self.root

        result = ""
        if tree.left is not None:
            result += self.inorder(tree.left)

        result += str(tree) + "\n"

        if tree.right is not None:
            result += self.inorder(tree.right)

        return result

    def zapiszDoPliku(self, nazwa_pliku):
        if self.root is None:
            with open(nazwa_pliku, "w") as f:
                f.write("")
            return

        raport = self.inorder()
        with open(nazwa_pliku, "w") as f:
            f.write(raport)

def przetworz_zwroty(plik_wej="zwroty.txt", plik_wyj="stan_biblioteki.txt"):
    drzewo = DrzewoBST()

    with open(plik_wej, "r") as f:
        for linia in f:
            linia = linia.strip()
            if not linia:
                continue

            czesci = linia.split()
            isbn = czesci[0]
            tytul = " ".join(czesci[1:]) if len(czesci) > 1 else "BRAK_TYTULU"

            drzewo.insertValue(isbn, tytul)

    drzewo.zapiszDoPliku(plik_wyj)


# network_loader.py

import csv


def wczytaj_siec_z_csv(nazwa_pliku="siec.csv"):
    graf = Graf()

    with open(nazwa_pliku, "r",) as plik:
        reader = csv.reader(plik)

        for wiersz in reader:
            router_a = wiersz[0]
            router_b = wiersz[1]
            ping = int(wiersz[2])

            graf.dodaj_wezel(router_a)
            graf.dodaj_wezel(router_b)

            graf.dodaj_krawedz(router_a, router_b, kierunek="N", waga=ping)

    return graf


# router_engine.py

from math import inf
from wezel import Wezel


def find_fastest_route(graf, start_node, end_node):
    start = Wezel(start_node)
    end = Wezel(end_node)

    if start not in graf.graf:
        print(f"Router startowy '{start_node}' nie istnieje w grafie.")
        return None, None

    if end not in graf.graf:
        print(f"Router docelowy '{end_node}' nie istnieje w grafie.")
        return None, None

    # Inicjalizacja tablicy odległości i poprzedników
    dystans = {}
    poprzednik = {}
    nieodwiedzone = set()

    for wezel in graf.graf.keys():
        dystans[wezel] = inf
        poprzednik[wezel] = None
        nieodwiedzone.add(wezel)

    dystans[start] = 0

    while nieodwiedzone:
        biezacy = None
        min_dystans = float("inf")

        for w in nieodwiedzone:
            if dystans[w] < min_dystans:
                min_dystans = dystans[w]
                biezacy = w

        if biezacy is None:
            break

        if biezacy == end:
            break

        nieodwiedzone.remove(biezacy)
        for krawedz in graf.graf[biezacy]:
            sasiad = krawedz.cel
            if sasiad not in nieodwiedzone:
                continue

            waga = krawedz.waga if krawedz.waga is not None else 0
            nowy_dystans = dystans[biezacy] + waga

            if nowy_dystans < dystans[sasiad]:
                dystans[sasiad] = nowy_dystans
                poprzednik[sasiad] = biezacy

    if dystans[end] == inf:
        print(f"Brak ścieżki z '{start_node}' do '{end_node}'.")
        return None, None

    sciezka_wezly = []
    aktualny = end
    while aktualny is not None:
        sciezka_wezly.append(aktualny)
        aktualny = poprzednik[aktualny]

    sciezka_wezly.reverse()

    sciezka_nazwy = [str(w) for w in sciezka_wezly]
    calkowity_ping = dystans[end]

    return sciezka_nazwy, calkowity_ping

def main():
    print("=== Symulacja trasowania pakietów (najmniejsze opóźnienie) ===\n")

    graf = wczytaj_siec_z_csv()

    start = input("Podaj router startowy (np. R1): ")
    koniec = input("Podaj router docelowy (np. R5): ")

    sciezka, ping = find_fastest_route(graf, start, koniec)

    if sciezka is None or ping is None:
        print("Nie udało się wyznaczyć trasy.")
        return

    trasa_str = " -> ".join(sciezka)

    print(f"\nNajlepsza trasa: {trasa_str} (Całkowity ping: {ping}ms)")


if __name__ == '__main__':
    print(demo_text_history())
    przetworz_zwroty("zwroty.txt", "stan_biblioteki.txt")
    print("Wygenerowano raport: stan_biblioteki.txt")
    main()
