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
                            var addNewSong = true;
                            foreach (var song in dictionary)
                            {
                                if (song.Key > lastSong)
                                {
                                    lastSong = song.Key;
                                }
                                if (song.Value == newSong)
                                {
                                    addNewSong = false;
                                }
                            }
                            if (addNewSong)
                            {
                               dictionary.Add(lastSong + 1, newSong);
                            }
                            else
                            {
                                Console.WriteLine("Ova pjesma se ne mmože dodati jer već postoji na playlisti.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Izabrali ste brisanje pjesme unosom rednog broja pjesme");
                            var deleteSongDefinied = false;
                            Console.WriteLine("Ako niste sigurni u odluci, za povratak na izbornik unesite: izbornik");
                            Console.WriteLine("Za nastavak unijeti bilo što");
                            var backToMenu = Console.ReadLine();
                            if (backToMenu == "izbornik")
                            {
                                Console.WriteLine();
                                deleteSongDefinied = true;
                                runProgram = false;
                                runMenu = true;
                            }
                            var listOfKeys5 = dictionary.Keys.ToList();
                            var listOfValues5 = dictionary.Values.ToList();
                            while (deleteSongDefinied == false)
                            {
                                dictionary.Clear();
                                Console.WriteLine("Unesite broj pjesme koju želite izbrisati");
                                var deleteSongNumber = int.Parse(Console.ReadLine());
                                for (var i = 0; i < listOfKeys5.Count; i++)
                                {
                                    if (deleteSongNumber == listOfKeys5[listOfKeys5.Count - 1])
                                    {
                                        listOfKeys5.Remove(listOfKeys5[listOfKeys5.Count - 1]);
                                        listOfValues5.Remove(listOfValues5[listOfValues5.Count - 1]);
                                        Console.WriteLine("Pjesma uspješno izbrisana!");
                                        deleteSongNumber = 999;
                                        deleteSongDefinied = true;
                                    }
                                    else if (listOfKeys5[i] == deleteSongNumber)
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
                                for (var i = 0; i < listOfKeys5.Count; i++)
                                {
                                    dictionary.Add(listOfKeys5[i], listOfValues5[i]);
                                }
                            }
                            break;
                        case 6:
                            Console.WriteLine("Izabrali ste brisanje pjesme unosom imena pjesme");
                            var deleteSongByNameDefinied = false;
                            Console.WriteLine("Ako niste sigurni u odluci, za povratak na izbornik unesite: izbornik");
                            Console.WriteLine("Za nastavak unijeti bilo što");
                            backToMenu = Console.ReadLine();
                            if (backToMenu == "izbornik")
                            {
                                Console.WriteLine();
                                deleteSongByNameDefinied = true;
                                runProgram = false;
                                runMenu = true;
                            }
                            var listOfKeys6 = dictionary.Keys.ToList();
                            var listOfValues6 = dictionary.Values.ToList();
                            while (deleteSongByNameDefinied == false)
                            {
                                dictionary.Clear();
                                Console.WriteLine("Unesite ime pjesme koju želite izbrisati");
                                var deleteSong = Console.ReadLine();
                                var deletedSongNumber = 999;
                                for (var i = 0; i < listOfKeys6.Count; i++)
                                {
                                    if (deleteSong == listOfValues6[listOfValues6.Count - 1])
                                    {
                                        listOfKeys6.Remove(listOfKeys6[listOfKeys6.Count - 1]);
                                        listOfValues6.Remove(listOfValues6[listOfValues6.Count - 1]);
                                        Console.WriteLine("Pjesma uspješno izbrisana!");
                                        deleteSongByNameDefinied = true;
                                    }
                                    else if (listOfValues6[i] == deleteSong)
                                    {
                                        deletedSongNumber = listOfKeys6[i];
                                        listOfKeys6.Remove(listOfKeys6[i]);
                                        listOfValues6.Remove(listOfValues6[i]);
                                        Console.WriteLine("Pjesma uspješno izbrisana!");
                                        listOfKeys6[i] = listOfKeys6[i] - 1;
                                        deleteSongByNameDefinied = true;
                                    }
                                    else if (listOfKeys6[i] > deletedSongNumber)
                                    {
                                        listOfKeys6[i] = listOfKeys6[i] - 1;
                                    }
                                }
                                if (deleteSongByNameDefinied == false)
                                {
                                    Console.WriteLine("Ne postoji pjesma pod tim imenom. Molim ponovite unos!");
                                }
                                for (var i = 0; i < listOfKeys6.Count; i++)
                                {
                                    dictionary.Add(listOfKeys6[i], listOfValues6[i]);
                                }
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
                            var songNumberDefinied = false;
                            Console.WriteLine("Ako niste sigurni u odluci, za povratak na izbornik unesite: izbornik");
                            Console.WriteLine("Za nastavak unijeti bilo što");
                            backToMenu = Console.ReadLine();
                            if (backToMenu == "izbornik")
                            {
                                Console.WriteLine();
                                songNumberDefinied = true;
                                runProgram = false;
                                runMenu = true;
                            }
                            var listOfKeys8 = dictionary.Keys.ToList();
                            var listOfValues8 = dictionary.Values.ToList();
                            while (songNumberDefinied == false)
                            {
                                dictionary.Clear();
                                Console.WriteLine("Unesite redni broj pjesme čije ime želite urediti");
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
                                for (var i = 0; i < listOfKeys8.Count; i++)
                                {
                                    dictionary.Add(listOfKeys8[i], listOfValues8[i]);
                                }
                            }
                            break;
                        case 9:
                            var listOfKeys9 = dictionary.Keys.ToList();
                            var listOfValues9 = dictionary.Values.ToList();
                            var listOfNewValues = new List<string>();
                            Console.WriteLine("Izabrali ste premještanje pjesama");
                            var songPositionDefinied = false;
                            Console.WriteLine("Ako niste sigurni u odluci, za povratak na izbornik unesite: izbornik");
                            Console.WriteLine("Za nastavak unijeti bilo što");
                            backToMenu = Console.ReadLine();
                            if (backToMenu == "izbornik")
                            {
                                Console.WriteLine();
                                songPositionDefinied = true;
                                runProgram = false;
                                runMenu = true;
                            }
                            while (songPositionDefinied == false)
                            {
                                dictionary.Clear();
                                Console.WriteLine("Unesite broj pjesme koju želite premjestiti");
                                var songNumberPos = int.Parse(Console.ReadLine());
                                Console.WriteLine("Na koje mjesto ju želite premjestiti");
                                var newSongPosition = int.Parse(Console.ReadLine());
                                if (newSongPosition <= listOfKeys9.Count & songNumberPos <= listOfKeys9.Count)
                                {
                                    newSongPosition = newSongPosition - 1;
                                    songNumberPos = songNumberPos - 1;
                                    songPositionDefinied = true;
                                    for (var i = 0; i < listOfValues9.Count; i++)
                                    {
                                        listOfNewValues.Add("*");
                                    }
                                    listOfNewValues[newSongPosition] = listOfValues9[songNumberPos];
                                    listOfValues9.Remove(listOfValues9[songNumberPos]);
                                }
                                else
                                {
                                    Console.WriteLine("Molim ponovite unose");
                                }
                                for (var i = 0; i < listOfNewValues.Count; i++)
                                {
                                    if (listOfNewValues[i] == "*")
                                    {
                                        listOfNewValues[i] = listOfValues9[0];
                                        listOfValues9.Remove(listOfValues9[0]);
                                    }
                                    dictionary.Add(listOfKeys9[i], listOfNewValues[i]);
                                }
                            }
                           
                            break;
                        default:
                            Console.WriteLine("Molim ponovite unos");
                            break;
                    }
                    runProgramTime += 1;
                }
            }
        }    
    }
}
