using System;
using System.IO;
using System.Collections.Generic;
class Macierz_Wag
{
    public int[,] Macierz;
    public string path;

    public Macierz_Wag()
    {
        path = "wagi.txt";
        StreamReader Czytaj_Plik = new StreamReader(path);
        Macierz = new int[Liczba_Wierzchołków(path), Liczba_Wierzchołków(path)]; //Deklaracja mustej macierzy do przechowywania wyników

        int i = 0; //Liczba wierszy
        do
        {
            char[] Pojedyncza_Linijka = Czytaj_Plik.ReadLine().ToCharArray();
            int j = 0; //Liczba kolumn
            int k = 0; //Indeks na którym przestaliśmy eksplorować linię

            do //Przepisujemy wartość z pliku dopóki nie napotkamy średnika
            {
                Wydziel_Tekst tekst = new Wydziel_Tekst(Pojedyncza_Linijka, k);
                if (tekst.Wynik!=null)
                {
                    Macierz[i, j] = int.Parse(tekst.Wynik);//Zapisanie stringu w postaci inta w macierzy
                    k = tekst.Indeks_Końcowy;
                    j++;
                } 
                else 
                {
                    j = Int32.MaxValue - 1; //Jakaś wartość która na pewno nie zajdzie.
                }
            } while (j<Pojedyncza_Linijka.Length-1);
            i++;
        } while (Czytaj_Plik.EndOfStream==false);
        Czytaj_Plik.Close();
    }

    public Macierz_Wag(string path)
    {
        this.path = path;
        StreamReader Czytaj_Plik = new StreamReader(path);
        Macierz = new int[Liczba_Wierzchołków(path), Liczba_Wierzchołków(path)]; //Deklaracja mustej macierzy do przechowywania wyników

        int i = 0; //Liczba wierszy
        do
        {
            char[] Pojedyncza_Linijka = Czytaj_Plik.ReadLine().ToCharArray();
            int j = 0; //Liczba kolumn
            int k = 0; //Indeks na którym przestaliśmy eksplorować linię

            do //Przepisujemy wartość z pliku dopóki nie napotkamy średnika
            {
                Wydziel_Tekst tekst = new Wydziel_Tekst(Pojedyncza_Linijka, k);
                if (tekst.Wynik != null)
                {
                    Macierz[i, j] = int.Parse(tekst.Wynik);//Zapisanie stringu w postaci inta w macierzy
                    k = tekst.Indeks_Końcowy;
                    j++;
                }
                else
                {
                    j = Int32.MaxValue - 1; //Jakaś wartość która na pewno nie zajdzie.
                }
            } while (j < Pojedyncza_Linijka.Length - 1);
            i++;
        } while (Czytaj_Plik.EndOfStream == false);
        Czytaj_Plik.Close();
    }

    public int Liczba_Wierzchołków(string path) //liczy po prostu linijki w tekście
    {
        StreamReader Czytaj_Plik = new StreamReader(path);
        int liczba_linijek = 0;
        do //Sprawdzimy ile linii ma plik,czyli po ludzku ile jest wierzchołków
        {
            char[] linijka = Czytaj_Plik.ReadLine().ToCharArray();//Wczytujemy po kolei każdą linijkę i zapisujemy ją do tabeli charów
            liczba_linijek++; //Aktualizuj liczbę linijek.
        } while (Czytaj_Plik.EndOfStream == false); //Czytaj dopóki się da
        Czytaj_Plik.Close();
        return liczba_linijek;
    }

}
