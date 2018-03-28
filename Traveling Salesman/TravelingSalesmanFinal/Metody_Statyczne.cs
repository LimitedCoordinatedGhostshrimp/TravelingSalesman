using System;
using System.IO;
using System.Collections.Generic;

// Wszelkie użyteczne metody z których korzystam wszędzie są tu
//
// Wyświetlanie podanej tabeli
// Podawanie liczby kolumn w podanej tabel
// Podawanie liczby wierszy w podanej tabel
// Zmiana zapisu(Do specjalnej metody)
// Liczy silnie podanej liczby
// Wyswietla tabele jednowymiarową

class Metody_Statyczne
{
    public Metody_Statyczne() { }
    public static void Wyświetl_Tabelę(int[,] tabela)
    {
        for (int i = 0; i < Liczba_Wierszy(tabela); i++)
        {
            for (int j = 0; j < Liczba_Kolumn(tabela); j++)
            {
                Console.Write(tabela[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static int Liczba_Kolumn(int[,] tabela)
    {
        int i = 0;
        int k;
        try
        {
            do
            {
                k = tabela[0, i];
                i++;
            } while (true);
        }
        catch (Exception)
        {
            return i;
        }
    }

    public static int Liczba_Wierszy(int[,] tabela)
    {
        return tabela.Length / Liczba_Kolumn(tabela);
    }

    public static int[] Zmień_Zapis_Na_Liczbowy(char[] Sekwencja)
    {
        int[] Wynik = new int[Sekwencja.Length];
        for (int i = 0; i < Sekwencja.Length; i++)
        {
            if (Sekwencja[i] == 'a')
            {
                Wynik[i] = 10;
            }
            else if (Sekwencja[i] == 'b')
            {
                Wynik[i] = 11;
            }
            else if (Sekwencja[i] == 'c')
            {
                Wynik[i] = 12;
            }
            else if (Sekwencja[i] == 'd')
            {
                Wynik[i] = 13;
            }
            else if (Sekwencja[i] == 'e')
            {
                Wynik[i] = 14;
            }
            else if (Sekwencja[i] == 'f')
            {
                Wynik[i] = 15;
            }
            else if (Sekwencja[i] == 'g')
            {
                Wynik[i] = 16;
            }
            else if (Sekwencja[i] == 'h')
            {
                Wynik[i] = 17;
            }
            else if (Sekwencja[i] == 'i')
            {
                Wynik[i] = 18;
            }
            else if (Sekwencja[i] == 'j')
            {
                Wynik[i] = 19;
            }
            else if (Sekwencja[i] == 'k')
            {
                Wynik[i] = 20;
            }
            else if (Sekwencja[i] == 'l')
            {
                Wynik[i] = 21;
            }
            else
            {
                Wynik[i] = int.Parse(Sekwencja[i].ToString());
            }
        }
        return Wynik;
    }

    public static string Zmień_Zapis_Na_Alfabetyczny(int Ilość_Wierzchołków)
    {
        string Wynik = "";

        char[] Alfabet = new char[11];
        Alfabet[0] = 'a';
        Alfabet[1] = 'b';
        Alfabet[2] = 'c';
        Alfabet[3] = 'd';
        Alfabet[4] = 'e';
        Alfabet[5] = 'f';
        Alfabet[6] = 'g';
        Alfabet[7] = 'h';
        Alfabet[8] = 'i';
        Alfabet[9] = 'j';
        Alfabet[10] = 'k';

        int j = 0;
        for (Int64 i = 1; i <= Ilość_Wierzchołków; i++) //Wypisz w stringu wszystkie wierzcholki tak, by dwucyfrowe liczby zamienić na znaki alfabetu. Potrzebne do poprawnego działania późniejszego skryptu.
        {
            if (i >= 10) // Jeżeli cyfra dwucyfrowa(czytaj od 10 do 21) to przepisz z pomocą macierzy Alfabet
            {
                Wynik += Alfabet[j];
                j++;
            }
            else
            {
                Wynik += i;
            }
        }

        return Wynik;
    }

    public static Int64 Silnia(Int64 liczba)
    {
        Int64 wynik = 1;
        for (int i = 1; i < liczba + 1; i++)
        {
            wynik *= i;
        }
        return wynik;
    }

    public static string Zamień_Tablicę_Char_Na_String(char[] Tablica_Charów)
    {
        string Wynik = "";
        for (int i = 0; i < Tablica_Charów.Length; i++)
        {
            Wynik += Tablica_Charów[i];
        }
        return Wynik;
    }

    public static string Do_Tablicy_Wyników(char[] Tablica_Charów)
    {
        string Wynik = "";
        int[] Przepisana_Tablica = Zmień_Zapis_Na_Liczbowy(Tablica_Charów);
        for (int i = 0; i < Przepisana_Tablica.Length; i++)
        {
            if (i<Przepisana_Tablica.Length-1)
            {
                Wynik += Przepisana_Tablica[i] + "-> ";
            }
            else
            {
                Wynik += Przepisana_Tablica[i];
            }
            
        }
        return Wynik;
    }

    public static void Wyświetl_Tablicę(string [] Opcje)
    {

        for (int i = 0; i < Opcje.Length; i++)
        {
            Console.WriteLine(Opcje[i]);
        }

        Console.WriteLine();
    }

    public static char[] Przesuń_Macierz(char[] Macierz,int Przesunięcie)
    {
        char[] Wynik = new char[Macierz.Length];

        for (int i = Przesunięcie; i < Wynik.Length; i++)
        {
            Wynik[i] = Macierz[i - Przesunięcie];
        }
        for (int i = 0; i < Przesunięcie; i++)
        {
            Wynik[i] = Macierz[Macierz.Length-Przesunięcie+i];
        }
        return Wynik;

    }

    public static char[] Odwróć_Macierz(char[] Macierz)
    {
        char[] Wynik = new char[Macierz.Length];

        for (int i = 0; i < Macierz.Length; i++)
		{
            Wynik[i] = Macierz[Macierz.Length - 1 - i];
		}
        return Wynik;
    }

    public static List<char[]> Lista_Odwróconych_Macierzy(char[] Linijka)
    {
        List<char[]> Wynik = new List<char[]> { };
        for (int i = 0; i < Linijka.Length; i++)
        {
            Wynik.Add(Przesuń_Macierz(Linijka, i));
        }
        for (int j = 0; j < Linijka.Length; j++)
        {
            Wynik.Add(Przesuń_Macierz(Odwróć_Macierz(Linijka), j));
        }

        return Wynik;
    }

}