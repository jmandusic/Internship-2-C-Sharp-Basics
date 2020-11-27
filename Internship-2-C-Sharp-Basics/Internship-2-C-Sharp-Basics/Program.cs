using System;
using System.Collections.Generic;
using System.Linq;

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

                var runProgramTime = 1;
                var runProgram = true;
                while (runProgram == true)
                {
                    Console.WriteLine();
                    if (runProgramTime > 1)
                    {
                        Console.WriteLine("Odaberite akciju:");
                    }
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
                                    runProgramTime = 1;
                                    exitDefinied = true;
                                }
                                else if (exit == "NE")
                                {
                                    runProgram = false;
                                    runProgramTime = 1;
                                    runMenu = true;
                                    exitDefinied = true;
                                }
                                else
                                {
                                    Console.WriteLine("Molim ponovite unos!");
                                }
                            }
                            Console.WriteLine();
                            break;
                        case 1:
                            Console.WriteLine("Izabrali ste ispis cijele playliste");
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
                        case 5:
                            Console.WriteLine("Izabrali ste brisanje pjesme unosom rednog broja pjesme");
                            var deleteSongDefinied = false;
                            Console.WriteLine("Unesite broj pjesme koju želite izbrisati");
                            var listOfKeys5 = dictionary.Keys.ToList();
                            var listOfValues5 = dictionary.Values.ToList();
                            dictionary.Clear();
                            while (deleteSongDefinied == false)
                            {
                                var deleteSongNumber = int.Parse(Console.ReadLine());
                                for (var i = 0; i < listOfKeys5.Count; i++)
                                {
                                    if (listOfKeys5[i] == deleteSongNumber)
                                    {
                                        listOfKeys5.Remove(listOfKeys5[i]);
                                        listOfValues5.Remove(listOfValues5[i]);
                                        Console.WriteLine("Pjesma uspješno izbrisana!");
                                        listOfKeys5[i] = listOfKeys5[i] - 1;
                                        deleteSongDefinied = true;
                                    }
                                    else if (listOfKeys5[i] > deleteSongNumber)
                                    {
                                        listOfKeys5[i] = listOfKeys5[i] - 1;
                                    }
                                }
                                if (deleteSongDefinied == false)
                                {
                                    Console.WriteLine("Ne postoji pjesma pod tim brojem. Molim ponovite unos!");
                                }
                            }
                            for (var i = 0; i < listOfKeys5.Count; i++)
                            {
                                dictionary.Add(listOfKeys5[i], listOfValues5[i]);
                            }
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
                            Console.WriteLine();
                            break;
                        case 8:
                            Console.WriteLine("Izabrali ste uređivanje imena pjesme");
                            Console.WriteLine("Unesite redni broj pjesme čije ime želite urediti");
                            var songNumberDefinied = false;
                            var listOfKeys8 = dictionary.Keys.ToList();
                            var listOfValues8 = dictionary.Values.ToList();
                            dictionary.Clear();
                            while (songNumberDefinied == false)
                            {
                                var songNumber = int.Parse(Console.ReadLine());
                                for (var i = 0; i < listOfKeys8.Count; i++)
                                {
                                    if (listOfKeys8[i] == songNumber)
                                    {
                                        Console.WriteLine("Unesi uređeno ime pjesme");
                                        var editedSongName = Console.ReadLine();
                                        listOfValues8[i] = editedSongName;
                                        Console.WriteLine("Pjesma uspješno uređena!");
                                        songNumberDefinied = true;
                                    }
                                }
                                if (songNumberDefinied == false)
                                {
                                    Console.WriteLine("Ne postoji pjesma pod tim brojem. Molim ponovite unos!");
                                }
                            }
                            for (var i = 0; i < listOfKeys8.Count; i++)
                            {
                                dictionary.Add(listOfKeys8[i], listOfValues8[i]);
                            }
                            break;
                        default:
                            break;
                    }
                    runProgramTime += 1;
                }
            }
        }    
    }
}
