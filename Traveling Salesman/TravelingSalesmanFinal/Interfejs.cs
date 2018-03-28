using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;




class Interfejs
{
    Analizuj Macierz;
    public Macierz_Wag MWag;
    public string[] Opcje1 = new string[] { "1. Start", "Aby wyłączyć kliknij (Escape)" };
    public ConsoleColor[] KoloryKonsoli = new ConsoleColor[] { ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.White };
    public int ConsoleColorIndex;
    public string[] Czasy = new string[] { "< 1 sekunda", "< 1 sekunda", "< 1 sekunda", "< 1 sekunda", "< 1 sekunda", "< 1 sekunda", "< 1 sekunda", "około 1 sekundy", "około 15 sekund", "około 3 minuty", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć", "tak długo, że lepiej nie liczyć" };





    public Interfejs()
    {

        ConsoleColorIndex = 0;
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex]; 


        Console.WriteLine("Witaj w programie rozwiązującym PROBLEM KOMIWOJAŻERA\n");


        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex]; 


        Console.WriteLine("Pliki generowane przez program mogą ważyć nawet setki GB więc zalecamy program odpalać z dysku \nz dużą ilością wolnego miejsca i nie liczyć rozwiązania dla grafów z ilością wierzchołków większą niż 11.");

    }







    public void Start()
    {
        Console.WriteLine();
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];

        Console.WriteLine("---------------------------------------------------------------------------------------------\nWybierz co chcesz zrobić(klikając numer akcji) i podążaj za wskazówkami programu.");

        Metody_Statyczne.Wyświetl_Tablicę(Opcje1);
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex]; ConsoleKey answer = Console.ReadKey().Key;
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex]; Console.WriteLine();
        if (answer == ConsoleKey.Escape)
        {
            Environment.Exit(0);
        }
        else if (answer == ConsoleKey.D1)
        {
            Macierz_WagStat();
        }
        else
        {
            Start();
        }
    }











    public void Macierz_WagStat()
    {
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex]; Console.WriteLine("\nWpisz nazwę ścieżki do pliku z macierzą wag(jeżeli plik nazywa się \"wagi.txt\" naciśnij Enter nie wpisując nic.\n");
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex]; string path = Console.ReadLine();

        if (path == "" && File.Exists("wagi.txt") == true)
        {
            Console.WriteLine("Wczytana macierz wag:\n");
            MWag = new Macierz_Wag();

            ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
            Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];
            Metody_Statyczne.Wyświetl_Tabelę(MWag.Macierz);
            Analizuj();
        }
        else if (path == "" && File.Exists("wagi.txt") == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nie istnieje plik \"wagi.txt\" z którego można by było wczytać macierz. Spróbuj jeszcze raz.");
            ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
            Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];
            Macierz_WagStat();
        }
        else if (path != "" && File.Exists(@path) == true)
        {
            Console.WriteLine("Wczytana macierz wag:\n");
            MWag = new Macierz_Wag(path);

            ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
            Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];
            Metody_Statyczne.Wyświetl_Tabelę(MWag.Macierz);
            Analizuj();

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nie istnieje plik \"" + path + "\" z którego można by było wczytać macierz. Spróbuj jeszcze raz.");
            ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
            Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];
            Macierz_WagStat();
        }
    }












    public void Analizuj()
    {
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];

        Console.Write("\nWczytałeś macierz wag o {0} wierzchołkach.\nPrzewidywany czas liczenia rozwiązania wynosi {1}, \nlecz może się różnić w zależności od wydajności komputera i od prędkości zapisu/odczytu plików na dysku.\n", Metody_Statyczne.Liczba_Wierszy(MWag.Macierz), Czasy[Metody_Statyczne.Liczba_Wierszy(MWag.Macierz)]);
        Stopwatch stoper = new Stopwatch();
        stoper.Start();

        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];

        Macierz = new Analizuj(MWag);

        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];

        stoper.Stop();
        Console.WriteLine("\n\nObliczanie wstępne zakończone w czasie(godziny,minuty,sekundy,milisekundy): {0}", stoper.Elapsed);
        stoper.Reset();
        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];
        Macierz.AnalizaWyników();
        PrzygotujWyniki();
    }












    public void PrzygotujWyniki()
    {
        StreamReader Czytaj_Plik = new StreamReader("Najlepsze_Wyniki.txt");
        List<char[]> Ostateczne_Wyniki = new List<char[]> { };

        do
        {
            char[] Pojedyńcza_Linijka = Czytaj_Plik.ReadLine().Substring(0,(int)Macierz.Ilość_Wierzchołków).ToCharArray();
            bool Wrzuć_Jako_Wynik = false;
            List<char[]> Przesunięte_Linijki = Metody_Statyczne.Lista_Odwróconych_Macierzy(Pojedyńcza_Linijka);

            foreach (var  Przesunięta_Linijka in Przesunięte_Linijki)
            {
                foreach (var Linijka in Ostateczne_Wyniki)
                {
                    bool wynik_cząstkowy = true;
                    for (int i = 0; i < Przesunięta_Linijka.Length; i++)
                    {
                        if (Przesunięta_Linijka[i]!=Linijka[i])
                        {
                            wynik_cząstkowy = false;
                        }
                    }
                    if (wynik_cząstkowy==true)
                    {
                        Wrzuć_Jako_Wynik = true;
                    }
                }
            }
            if (Wrzuć_Jako_Wynik==false)
            {
                Ostateczne_Wyniki.Add(Pojedyńcza_Linijka);
            }

        } while (Czytaj_Plik.EndOfStream==false);

        Czytaj_Plik.Close();

        ConsoleColorIndex = KolejnyKolor(ConsoleColorIndex);
        Console.ForegroundColor = KoloryKonsoli[ConsoleColorIndex];

        foreach (var item in Ostateczne_Wyniki)
        {
            Console.WriteLine(Metody_Statyczne.Do_Tablicy_Wyników(item));
        }
        File.Delete("Najlepsze_Wyniki.txt");
        File.Delete("możliwosci.txt");
        File.Delete("Najmniej_Korzystne_Wyniki.txt");

        Start();
    }











    public int KolejnyKolor(int i)
    {
        Random rand = new Random();
        int r = rand.Next(0, 4);
        if (r!=i)
        {
            return r;
            
        }
        return KolejnyKolor(i);
    }
}


