using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ThePianist
{
    class Song
    {
        public Song(string piece, string composer, string key)
        {
            this.Piece = piece;
            this.Composer = composer;
            this.Key = key;
        }

        public string Piece { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Song> songList = new List<Song>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)                       // Read data
            {
                string[] songPiece = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string piece = songPiece[0];
                string composer = songPiece[1];
                string key = songPiece[2];
                Song currentSong = new Song(piece, composer, key);
                songList.Add(currentSong);
            }

            string commands = Console.ReadLine();
            while (commands != "Stop")                  // Action
            {
                string[] commandArray = commands
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArray[0];

                if (command == "Add")
                {
                    string piece = commandArray[1];
                    string composer = commandArray[2];
                    string key = commandArray[3];

                    if (!songList.Any(x => x.Piece == piece))
                    {
                        Song newSong = new Song(piece, composer, key);
                        songList.Add(newSong);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    string piece = commandArray[1];

                    if (songList.Any(x => x.Piece == piece))
                    {
                        for (int i = 0; i < songList.Count; i++)
                        {
                            if (songList[i].Piece == piece)
                            {
                                songList.RemoveAll(x => x.Piece == piece);
                            }
                        }                       
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string piece = commandArray[1];
                    string newKey = commandArray[2];

                    if (songList.Any(x => x.Piece == piece))
                    {
                        foreach (Song item in songList)
                        {
                            if (item.Piece == piece)
                            {
                                item.Key = newKey;
                            }
                        }
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                commands = Console.ReadLine();
            }

            foreach (Song song in songList)                 // Print
            {
                Console.WriteLine($"{song.Piece} -> Composer: {song.Composer}, Key: {song.Key}");
            }
        }
    }
}
