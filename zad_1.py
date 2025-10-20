from collections import defaultdict
import re
import math


def wczytaj_dane_z_pliku(nazwa_pliku, separatory=None):
    if separatory is None:
        separatory = r'[ ,;\t|]+'

    dane = []
    with open(nazwa_pliku, 'r') as plik:
        for linia in plik:
            linia = linia.strip()
            if linia:
                kolumny = re.split(separatory, linia)
                dane.append(kolumny)
    print_dane_w_tabeli(dane)
    return dane


def oblicz_statystyki(dane):
    liczba_atrybutow = len(dane[0])
    unikalne_wartosci = [set() for _ in range(liczba_atrybutow)]
    wystapienia = [defaultdict(int) for _ in range(liczba_atrybutow)]

    for wiersz in dane:
        for i, wartosc in enumerate(wiersz):
            unikalne_wartosci[i].add(wartosc)
            wystapienia[i][wartosc] += 1

    return unikalne_wartosci, wystapienia


def wyswietl_statystyki(unikalne_wartosci, wystapienia):
    for i, (unikalne, wyst) in enumerate(zip(unikalne_wartosci, wystapienia)):
        print(f"\nAtrybut {i + 1}:")
        print(f"  Liczba unikalnych wartości: {len(unikalne)}")
        print("  Wystąpienia:")
        for wartosc, liczba in wyst.items():
            print(f"    {wartosc}: {liczba}")


def print_dane_w_tabeli(dane):
    if not dane:
        print("Brak danych do wyświetlenia.")
        return

    liczba_kolumn = len(dane[0])
    naglowki = [f"a{i + 1}" for i in range(liczba_kolumn - 1)] + ["d"]

    szerokosci = [len(n) for n in naglowki]
    for wiersz in dane:
        for i, wartosc in enumerate(wiersz):
            szerokosci[i] = max(szerokosci[i], len(str(wartosc)))

    naglowek_format = " | ".join(f"{{:<{szerokosci[i]}}}" for i in range(liczba_kolumn))
    linia = "-+-".join("-" * szerokosci[i] for i in range(liczba_kolumn))

    print("\nTabela danych:\n")
    print(naglowek_format.format(*naglowki))
    print(linia)

    for wiersz in dane:
        print(naglowek_format.format(*wiersz))


def get_entropy(wystapienia, atrybut):
    wystapienia_klasy = wystapienia[atrybut - 1]

    suma = sum(wystapienia_klasy.values())

    entropia = 0.0
    for wartosc, liczba in wystapienia_klasy.items():
        p_i = liczba / suma
        if p_i > 0:
            entropia -= p_i * math.log2(p_i)

    print(f"\nEntropia dla ostatniego atrybutu: {entropia:.4f}")
    return entropia


def info_attribute(dane, atrybut):
    wynik = defaultdict(list)

    for wiersz in dane:
        wartosc_atrybutu = wiersz[atrybut - 1]
        decyzja = wiersz[-1]
        wynik[wartosc_atrybutu].append(decyzja)

    return wynik



if __name__ == "__main__":
    nazwa_pliku = "gielda.txt"
    dane = wczytaj_dane_z_pliku(nazwa_pliku, ",")
    unikalne, wystapienia = oblicz_statystyki(dane)
    get_entropy(wystapienia, 1)
    wyswietl_statystyki(unikalne, wystapienia)
