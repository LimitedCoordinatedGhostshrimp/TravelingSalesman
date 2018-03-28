using System;
using System.IO;

// Metoda służy do wyznaczenia ilości permutacji pomiędzy X wierzchołkami w grafie.
//
//
//


class Analizuj
{
    public Int64 Ilość_Wierzchołków;
    public Int64 Ilość_Permutacji;
    string path; // Ścieżka do tekstowej bazy danych wyznaczonych przez nas Permutacji.

    public Analizuj() { }

    public Analizuj(Macierz_Wag MWag)
    {
        // Tworzenie i otwieranie pliku bazy

        path = "możliwosci.txt";
        if (File.Exists(path) == true)
        {
            File.Create(path).Close();
        }
        StreamWriter Zapisz_W_Bazie = new StreamWriter(path);

        // Obliczanie podstawowych wartości

        Ilość_Wierzchołków = Metody_Statyczne.Liczba_Kolumn(MWag.Macierz);
        Ilość_Permutacji = Metody_Statyczne.Silnia(Ilość_Wierzchołków);

        // Wszystkie wierzchołki zapisane od pierwszego do ostatniego w stringu, tylko liczby dwucyfrowe zamienione na litery alfabetu
        string Sekwencja = Metody_Statyczne.Zmień_Zapis_Na_Alfabetyczny((int)Ilość_Wierzchołków); //To string który po kolei ma wierzcholki

        char[] Tablica_Charów = new char[Sekwencja.Length]; // Tu będą zapisywana wyznaczona Permutacja i jak będzie gotowa to zostanie zapisana w bazie
        int[] pozycje = new int[Sekwencja.Length];
        bool[] użyte = new bool[Sekwencja.Length];
        bool ostatnie;
        for (int i = 0; i < Sekwencja.Length; i++)
        {
            pozycje[i] = i;
        }

        Łączenia łączenia = new Łączenia();

        do
        {
            for (int i = 0; i < Sekwencja.Length; i++)
            {
                Tablica_Charów[i] = Sekwencja[pozycje[i]];
            }
            if (łączenia.Sprawdź_Łączenia(MWag.Macierz,Tablica_Charów)==true)
            {
                Zapisz_W_Bazie.WriteLine(Metody_Statyczne.Zamień_Tablicę_Char_Na_String(Tablica_Charów)+";"+łączenia.waga); //Zapisanie wszystkich permutacji do pliku tekstowego
            }
            ostatnie = false;
            Int64 k = Sekwencja.Length - 2;
            while (k >= 0)
            {
                if (pozycje[k] < pozycje[k + 1])
                {
                    for (Int64 i = 0; i < Sekwencja.Length; i++)
                    {
                        użyte[i] = false;
                    }
                    for (Int64 i = 0; i < k; i++)
                    {
                        użyte[pozycje[i]] = true;
                    }
                    do
                    {
                        pozycje[k]++;
                    } while (użyte[pozycje[k]]);

                    użyte[pozycje[k]] = true;

                    for (int i = 0; i < Sekwencja.Length; i++)
                        if (!użyte[i]) 
                        {
                            pozycje[++k] = i;
                        }
                    break;
                }
                else k--;
            }
            ostatnie = (k < 0);
        } while (!ostatnie);
        Zapisz_W_Bazie.Close();
    }

    public void AnalizaWyników()
    {
        StreamReader Czytaj_Plik_Możliwości = new StreamReader(path);
        StreamWriter Analiza_Najgorszych_Wyników = new StreamWriter("Najmniej_Korzystne_Wyniki.txt");
        int Najmniej_Korzystna_Waga = 0;

        do
        {
            char [] Pojedyńcza_Linijka = Czytaj_Plik_Możliwości.ReadLine().ToCharArray();
            string Najmniej_Korzystna_Waga_String = "";
            for (int i = (int)Ilość_Wierzchołków+1; i < Pojedyńcza_Linijka.Length; i++)
			{
                Najmniej_Korzystna_Waga_String += Pojedyńcza_Linijka[i];
			}

            if (int.Parse(Najmniej_Korzystna_Waga_String)>Najmniej_Korzystna_Waga)
            {
                Najmniej_Korzystna_Waga = int.Parse(Najmniej_Korzystna_Waga_String);           
            }
        } while (Czytaj_Plik_Możliwości.EndOfStream==false);

        Analiza_Najgorszych_Wyników.Close();
        Czytaj_Plik_Możliwości.Close();
        Czytaj_Plik_Możliwości = new StreamReader(path);
        StreamWriter Analiza_Najlepszych_Wyników = new StreamWriter("Najlepsze_Wyniki.txt");
        int Najmniejsza_Waga = Najmniej_Korzystna_Waga;

        do
        {

            char[] Pojedyńcza_Linijka = Czytaj_Plik_Możliwości.ReadLine().ToCharArray();
            string Najmniejsza_Waga_String = "";

            for (int i = (int)Ilość_Wierzchołków + 1; i < Pojedyńcza_Linijka.Length; i++)
            {
                Najmniejsza_Waga_String += Pojedyńcza_Linijka[i];
            }


            if (int.Parse(Najmniejsza_Waga_String) < Najmniejsza_Waga)
            {
                Najmniejsza_Waga = int.Parse(Najmniejsza_Waga_String);
                Analiza_Najlepszych_Wyników.Close();
                Analiza_Najlepszych_Wyników = new StreamWriter("Najlepsze_Wyniki.txt");
                Analiza_Najlepszych_Wyników.WriteLine(Metody_Statyczne.Zamień_Tablicę_Char_Na_String(Pojedyńcza_Linijka));
            }

            else if (int.Parse(Najmniejsza_Waga_String) == Najmniejsza_Waga)
            {
                Analiza_Najlepszych_Wyników.WriteLine(Metody_Statyczne.Zamień_Tablicę_Char_Na_String(Pojedyńcza_Linijka));
            } 

            else 
            {}

        } while (Czytaj_Plik_Możliwości.EndOfStream == false);

        Analiza_Najlepszych_Wyników.Close();
        Czytaj_Plik_Możliwości.Close();

        Console.Write("\nNajkrótszy cykl Hamiltona: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(Najmniejsza_Waga);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" \n\nTrwa usuwanie powtórzeń i przygotowanie wyników do wyświetlenia...\n");
       

    }


}
