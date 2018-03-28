using System;
using System.IO;
using System.Collections.Generic;

// Podajemy ciąg wierzchołków i sprawdzamy, czy istnieje kriawędź łącząca każde z nic, włączając pierwszy i ostatni
// Przy okazji zapisuje wagę

class Łączenia
{
    public Łączenia() { }
    public int waga;
    public bool Sprawdź_Łączenia(int[,] MWag, char[] Sekwencja)
    {
        bool wynik = true;
        waga = 0;

        int[] PrzepisanaSekwencja = Metody_Statyczne.Zmień_Zapis_Na_Liczbowy(Sekwencja) ; 
        
        int Wierzcholek_Poczatkowy, Wierzcholek_Koncowy;

        for (int i = 0; i < PrzepisanaSekwencja.Length; i++)
        {
            if (i == PrzepisanaSekwencja.Length - 1)
            {
                Wierzcholek_Poczatkowy = PrzepisanaSekwencja[i] - 1;
                Wierzcholek_Koncowy = PrzepisanaSekwencja[0] - 1;
            }
            else
            {
                Wierzcholek_Poczatkowy = PrzepisanaSekwencja[i] - 1;
                Wierzcholek_Koncowy = PrzepisanaSekwencja[i + 1] - 1;
            }

            if (MWag[Wierzcholek_Poczatkowy, Wierzcholek_Koncowy] == 0)
            {
                wynik = false;
            }
            else
            {
                waga += MWag[Wierzcholek_Poczatkowy, Wierzcholek_Koncowy];
            }
        }
        return wynik;
    }
}

