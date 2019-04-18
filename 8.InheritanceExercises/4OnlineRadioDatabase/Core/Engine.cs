using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] tokens = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length < 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artistName = tokens[0];
                    string songName = tokens[1];
                    string[] length = tokens[2]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);

                    int minutes = 0;
                    int seconds = 0;

                    bool isMinutes = int.TryParse(length[0], out minutes);
                    bool isSeconds = int.TryParse(length[1], out seconds);

                    if (!isMinutes)
                    {
                        throw new InvalidSongLengthException();
                    }

                    if (!isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintPlaylistLength();
        }

        private void PrintPlaylistLength()
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            int totalSeconds = songs.Sum(x => (x.Minutes * 60) + x.Seconds);
            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }
    }
}
