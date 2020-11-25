using System;
using System.Collections.Generic;

namespace Internship_2_C_Sharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<int, string>()
            {
                {1, "Lose Yourself" },
                {2, "Circles" },
                {3, "Radioactive" },
                {4, "Ako me ostaviš" }
            };

            var runMenu = true;
            while (runMenu == true)
            {
                runMenu = false;
                Console.WriteLine("Odaberite akciju:");
                Console.WriteLine("1 - Ispis cijele liste");
                Console.WriteLine("2 - Ispis imena pjesme unosom rednog broja");
                Console.WriteLine("3 - Ispis rednog broja pjesme unosom pripadajućeg imena");
                Console.WriteLine("4 - Unos nove pjesme");
                Console.WriteLine("5 - Brisanje pjesme po rednom broju");
                Console.WriteLine("6 - Brisanje pjesme po imenu");
                Console.WriteLine("7 - Brisanje cijele liste");
                Console.WriteLine("8 - Uređivanje imena pjesme");
                Console.WriteLine("9 - Uređivanje rednog broja pjesme");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                var runProgram = true;
                while (runProgram == true)
                {
                    Console.WriteLine();
                    var pick = int.Parse(Console.ReadLine());
                    switch (pick)
                    {
                        case 0:
                            Console.WriteLine("Jeste li sigurni da želite izaći iz aplikacije? DA/NE");
                            var exitDefinied = false;
                            while (exitDefinied == false)
                            {
                                var exit = Console.ReadLine();
                                if (exit == "DA")
                                {
                                    runProgram = false;
                                    exitDefinied = true;
                                }
                                else if (exit == "NE")
                                {
                                    runProgram = false;
                                    runMenu = true;
                                    exitDefinied = true;
                                }
                                else
                                {
                                    Console.WriteLine("Molim ponovite unos!");
                                }
                            }
                            break;
                        case 1:
                            foreach (var song in dictionary)
                            {
                                Console.WriteLine(song.Key.ToString()+')'+' '+song.Value);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Izabrali ste ispis imena pjesme unosom rednog broja");
                            Console.WriteLine("Unesi redni broj");
                            var numDefinied = false;
                            while (numDefinied == false)
                            {
                                var num = int.Parse(Console.ReadLine());
                                foreach (var song in dictionary)
                                {
                                    if (song.Key == num)
                                    {
                                        Console.WriteLine(song.Value);
                                        numDefinied = true;
                                    }
                                }
                                if (numDefinied == false)
                                {
                                    Console.WriteLine("Molim ponovite unos!");
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("Izabrali ste ispis rednog broja pjesme unosom imena pjesme");
                            Console.WriteLine("Unesi ime pjesme");
                            var nameSongDefinied = false;
                            while (nameSongDefinied == false)
                            {
                                var songName = Console.ReadLine();
                                foreach (var song in dictionary)
                                {
                                    if (song.Value == songName)
                                    {
                                        Console.WriteLine(song.Key);
                                        nameSongDefinied = true;
                                    }
                                }
                                if (nameSongDefinied == false)
                                {
                                    Console.WriteLine("Molim ponovite unos!");
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Izabrali ste unos nove pjesme");
                            Console.WriteLine("Unesite ime nove pjesme");
                            var newSong = Console.ReadLine();
                            var lastSong = 0;
                            foreach (var song in dictionary)
                            {
                                if (song.Key > lastSong)
                                {
                                    lastSong = song.Key;
                                }
                            }
                            dictionary.Add(lastSong + 1, newSong);
                            break;
                        case 7:
                            Console.WriteLine("Jeste li sigurni da želite izbrisati cijelu playlistu? DA/NE");
                            var deleteDefinied = false;
                            while (deleteDefinied == false)
                            {
                                var delete = Console.ReadLine();
                                if (delete == "DA")
                                {
                                    deleteDefinied = true;
                                    dictionary.Clear();
                                }
                                else if (delete == "NE")
                                {
                                    deleteDefinied = true;
                                    runMenu = true;
                                    runProgram = false;
                                }
                                else
                                {
                                    Console.WriteLine("Molim ponovite unos!");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        
          
    }
}
