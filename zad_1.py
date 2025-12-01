from collections import defaultdict, Counter
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
    """
    Entropia dla wybranego atrybutu na podstawie tablicy wystąpień.
    (Nie jest używana w Info/Gain, ale zostawiamy jako pomocniczą.)
    """
    wystapienia_klasy = wystapienia[atrybut - 1]
    suma = sum(wystapienia_klasy.values())

    entropia = 0.0
    for wartosc, liczba in wystapienia_klasy.items():
        p_i = liczba / suma
        if p_i > 0:
            entropia -= p_i * math.log2(p_i)

    print(f"\nEntropia dla atrybutu {atrybut}: {entropia:.4f}")
    return entropia


def info_attribute(dane, atrybut):
    """
    Grupuje decyzje według wartości atrybutu X.
    Zwraca: wartość_atrybutu -> lista decyzji (klas).
    """
    wynik = defaultdict(list)

    for wiersz in dane:
        wartosc_atrybutu = wiersz[atrybut - 1]
        decyzja = wiersz[-1]
        wynik[wartosc_atrybutu].append(decyzja)

    return wynik


# =========================================================
#      NOWE FUNKCJE: Entropia, Info(X,T), Info(T), Gain
# =========================================================

def entropy_decisions(klasy):
    """
    Entropia dla listy klas decyzyjnych (Info(Ti)).
    """
    liczba = len(klasy)
    liczniki = Counter(klasy)

    entropia = 0.0
    for k, v in liczniki.items():
        p = v / liczba
        if p > 0:
            entropia -= p * math.log2(p)
    return entropia


def info_X_T(dane, atrybut):
    """
    Oblicza Info(X, T) według wzoru:
    Info(X, T) = Σ (|Ti| / |T|) * Info(Ti)
    gdzie Ti – podzbiory danych z tą samą wartością atrybutu X.
    """
    podzial = info_attribute(dane, atrybut)
    T = len(dane)

    info = 0.0
    print(f"\n--- Info(a{atrybut}, T) ---")

    for wartosc, decyzje in podzial.items():
        Ti = len(decyzje)
        info_Ti = entropy_decisions(decyzje)
        waga = Ti / T
        info += waga * info_Ti

        print(f"Wartość '{wartosc}': |T_{wartosc}| = {Ti}, "
              f"waga = {waga:.3f}, Info(T_{wartosc}) = {info_Ti:.16f}")

    print(f"Info(a{atrybut}, T) = {info:.16f}")
    return info


def info_T(dane):
    """
    Entropia całej kolumny decyzyjnej (Info(T)).
    """
    decyzje = [wiersz[-1] for wiersz in dane]
    return entropy_decisions(decyzje)


def gain(dane, atrybut, info_T_value=None, info_attr_value=None):
    """
    Gain(X, T) = Info(T) - Info(X, T)
    Można przekazać wcześniej policzone Info(T) i Info(X,T),
    żeby uniknąć ponownych obliczeń.
    """
    if info_T_value is None:
        info_T_value = info_T(dane)
    if info_attr_value is None:
        info_attr_value = info_X_T(dane, atrybut)

    gain_value = info_T_value - info_attr_value

    print(f"\nGain(a{atrybut}, T) = Info(T) - Info(a{atrybut}, T)")
    print(f"Gain(a{atrybut}, T) = {info_T_value:.16f} - {info_attr_value:.16f}")
    print(f"Gain(a{atrybut}, T) = {gain_value:.16f}")
    return gain_value


# =========================================================
#      NOWE FUNKCJE: SplitInfo(X,T) i GainRatio(X,T)
# =========================================================

def split_info(dane, atrybut):
    """
    SplitInfo(X, T) = I( |T1|/|T|, |T2|/|T|, ..., |Tk|/|T| )
    Entropia rozkładu liczności wartości danego atrybutu.
    """
    licznik_wartosci = defaultdict(int)
    for wiersz in dane:
        wartosc = wiersz[atrybut - 1]
        licznik_wartosci[wartosc] += 1

    T = len(dane)
    split = 0.0

    print(f"\n--- SplitInfo(a{atrybut}, T) ---")
    for wartosc, cnt in licznik_wartosci.items():
        p = cnt / T
        if p > 0:
            split -= p * math.log2(p)
        print(f"Wartość '{wartosc}': |T_{wartosc}| = {cnt}, p = {p:.16f}")

    print(f"SplitInfo(a{atrybut}, T) = {split:.16f}")
    return split


def gain_ratio(dane, atrybut,
               gain_value=None,
               splitinfo_value=None,
               info_T_value=None,
               info_attr_value=None):
    """
    GainRatio(X, T) = Gain(X, T) / SplitInfo(X, T)

    Parametry opcjonalne pozwalają przekazać wcześniej policzone:
      - gain_value  – Gain(X,T)
      - splitinfo_value – SplitInfo(X,T)
      - info_T_value – Info(T)
      - info_attr_value – Info(X,T)
    """
    # Ustal Gain(X,T)
    if gain_value is None:
        if info_T_value is None:
            info_T_value = info_T(dane)
        if info_attr_value is None:
            info_attr_value = info_X_T(dane, atrybut)
        gain_value = info_T_value - info_attr_value

    # Ustal SplitInfo(X,T)
    if splitinfo_value is None:
        splitinfo_value = split_info(dane, atrybut)

    if splitinfo_value == 0:
        print(f"\nGainRatio(a{atrybut}, T) = 0.0 (SplitInfo = 0)")
        return 0.0

    ratio = gain_value / splitinfo_value
    print(f"\nGainRatio(a{atrybut}, T) = Gain(a{atrybut}, T) / SplitInfo(a{atrybut}, T)")
    print(f"GainRatio(a{atrybut}, T) = {gain_value:.16f} / {splitinfo_value:.16f}")
    print(f"GainRatio(a{atrybut}, T) = {ratio:.16f}")
    return ratio

# =========================================================
#      BUDOWANIE DRZEWA DECYZYJNEGO (ID3/C4.5 z GainRatio)
# =========================================================

def all_same_class(dane):
    """Sprawdza, czy wszystkie wiersze mają tę samą klasę decyzyjną."""
    pierwsza = dane[0][-1]
    return all(w[-1] == pierwsza for w in dane)


def majority_class(dane):
    """Zwraca klasę większościową w zbiorze."""
    decyzje = [w[-1] for w in dane]
    return Counter(decyzje).most_common(1)[0][0]


def gain_ratio_value(dane, atrybut):
    """
    Wersja GainRatio(X,T) BEZ wypisywania po drodze.
    Korzysta z tych samych wzorów co gain_ratio(), ale jest "cicha".
    """
    T = len(dane)

    # Info(T)
    decyzje = [w[-1] for w in dane]
    info_T_val = entropy_decisions(decyzje)

    # Info(X, T)
    podzial = info_attribute(dane, atrybut)
    info_XT = 0.0
    for wartosc, dec_sub in podzial.items():
        Ti = len(dec_sub)
        info_XT += (Ti / T) * entropy_decisions(dec_sub)

    gain_val = info_T_val - info_XT

    # SplitInfo(X, T)
    licznik_wartosci = Counter(w[atrybut - 1] for w in dane)
    split = 0.0
    for cnt in licznik_wartosci.values():
        p = cnt / T
        if p > 0:
            split -= p * math.log2(p)

    if split == 0:
        return 0.0

    return gain_val / split


def best_attribute_by_gain_ratio(dane, dostepne_atrybuty):
    """Wybiera atrybut o największym GainRatio."""
    best_attr = None
    best_ratio = -1.0

    for a in dostepne_atrybuty:
        r = gain_ratio_value(dane, a)
        if r > best_ratio:
            best_ratio = r
            best_attr = a

    return best_attr


def build_tree(dane, dostepne_atrybuty):
    """
    Rekurencyjnie buduje drzewo decyzyjne.
    Struktura:
      - węzeł wewnętrzny: {"type": "node", "attr": numer_atrybutu, "children": {wartosc: poddrzewo}}
      - liść:           {"type": "leaf", "class": nazwa_klasy}
    """
    # 1. Jeśli wszystkie przykłady mają tę samą klasę -> liść
    if all_same_class(dane):
        return {"type": "leaf", "class": dane[0][-1]}

    # 2. Jeśli nie ma już atrybutów -> liść z klasą większościową
    if not dostepne_atrybuty:
        return {"type": "leaf", "class": majority_class(dane)}

    # 3. Wybór najlepszego atrybutu wg GainRatio
    best_attr = best_attribute_by_gain_ratio(dane, dostepne_atrybuty)
    if best_attr is None:
        # awaryjnie, gdyby coś poszło nie tak
        return {"type": "leaf", "class": majority_class(dane)}

    # 4. Podział danych wg wartości najlepszego atrybutu
    children = {}
    wartosci = set(w[best_attr - 1] for w in dane)

    remaining_attrs = [a for a in dostepne_atrybuty if a != best_attr]

    for wartosc in wartosci:
        podzbior = [w for w in dane if w[best_attr - 1] == wartosc]
        if not podzbior:
            # Brak przykładów -> liść z klasą większościową całego zbioru
            children[wartosc] = {"type": "leaf", "class": majority_class(dane)}
        else:
            children[wartosc] = build_tree(podzbior, remaining_attrs)

    return {"type": "node", "attr": best_attr, "children": children}

# =========================================================
#      WYPISYWANIE DRZEWA W FORMACIE wizualizacja.txt
# =========================================================

def print_subtree(node, edge_label, level=1):
    """
    Rekurencyjnie wypisuje poddrzewo z odpowiednim wcięciem.
    level = 1 -> jedno "poziomowe" wcięcie od korzenia.
    """
    indent = " " * 10 * level

    if node["type"] == "leaf":
        print(f"{indent}{edge_label} -> D: {node['class']}")
    else:
        print(f"{indent}{edge_label}->Atrybut: {node['attr']}")
        for wartosc, child in sorted(node["children"].items(), key=lambda kv: str(kv[0])):
            print_subtree(child, wartosc, level + 1)


def print_tree_root(tree, nazwa_pliku="car.data"):
    """
    Wypisuje całe drzewo w stylu:
    Drzewo dla pliku car.data
    Atrybut: 6
              high->Atrybut: 4
              ...
    ****************************************************************************************************
    """
    print(f"Drzewo dla pliku {nazwa_pliku}")

    if tree["type"] == "leaf":
        # przypadek ekstremalny: drzewo z jednym liściem
        print(f"D: {tree['class']}")
    else:
        print(f"Atrybut: {tree['attr']}")
        for wartosc, child in sorted(tree["children"].items(), key=lambda kv: str(kv[0])):
            print_subtree(child, wartosc, level=1)

    print("*" * 100)  # linia gwiazdek na końcu




# =========================================================


if __name__ == "__main__":
    nazwa_pliku = "car.data"   # albo "test.txt" przy innych danych
    dane = wczytaj_dane_z_pliku(nazwa_pliku, ",")

    unikalne, wystapienia = oblicz_statystyki(dane)
    wyswietl_statystyki(unikalne, wystapienia)

    # Entropia zbioru (Info(T))
    entropia_zbioru = info_T(dane)
    print(f"\nEntropia zbioru: {entropia_zbioru:.16f}")

    # Przyjmujemy, że ostatnia kolumna to decyzja,
    # więc atrybuty warunkowe to a1..a_(n-1)
    liczba_atrybutow_warunkowych = len(dane[0]) - 1

    print("\n--- Przyrosty informacji i GainRatio ---")
    for i in range(1, liczba_atrybutow_warunkowych + 1):
        print(f"\n=== Atrybut a{i} ===")
        info_attr = info_X_T(dane, i)
        g = gain(dane, i, info_T_value=entropia_zbioru, info_attr_value=info_attr)
        s = split_info(dane, i)
        gain_ratio(dane, i, gain_value=g, splitinfo_value=s)


    # =========================================================
    #      BUDOWA I WYPISANIE DRZEWA JAK W wizualizacja.txt
    # =========================================================
    # Atrybuty warunkowe to kolumny 1..(n-1)
    atrybuty_warunkowe = list(range(1, len(dane[0])))

    tree = build_tree(dane, atrybuty_warunkowe)

    print("\n" + "*" * 100)
    print_tree_root(tree, nazwa_pliku)

