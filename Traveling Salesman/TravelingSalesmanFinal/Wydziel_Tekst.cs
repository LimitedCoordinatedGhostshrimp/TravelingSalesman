using System;
using System.IO;


// Ta metoda jest po to, że gdy chcemy z linijki wyglądającej na przykład tak: 
//
// 0;1;10;10;10;10;10;10;10;10;10;
//
// Wydzielić po kolei każdą liczbę, bez średników, to po podaniu tej metodzie linijki oraz pozycji, gdzie ma zacząć, wydzieli liczbę i zwróci pozycję końcową.


 class Wydziel_Tekst
    {
        public int Indeks_Początkowy;
        public int Indeks_Końcowy;
        public string Wynik;
        public Wydziel_Tekst(char[] Linijka, int Liczba_Początkowa)
        {
            if (Liczba_Początkowa<Linijka.Length)
            {
                this.Indeks_Początkowy = Liczba_Początkowa;
                if (Linijka[Liczba_Początkowa] == ';')
                {
                    Liczba_Początkowa++;
                }
                Wynik = "";
                int i = Liczba_Początkowa;
                do
                {
                    Wynik += Linijka[i];
                    i++;
                } while (Linijka[i] != ';' || i >= Linijka.Length);
                Indeks_Końcowy = i + 1;
                if (Wynik==null)
                {
                    Indeks_Końcowy = Linijka.Length + 1;
                }
            }
            else { }
        }
    }

