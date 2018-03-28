using System;
using System.Diagnostics;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {

        Console.WindowWidth = 120;
        Console.WindowHeight = 50;


        Interfejs Program = new Interfejs();
        Program.Start();


        Console.ReadKey();
    }
}