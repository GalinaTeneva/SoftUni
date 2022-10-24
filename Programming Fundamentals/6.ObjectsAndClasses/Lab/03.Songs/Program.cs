using System;
using System.Collections.Generic;

namespace _03.Songs
{

    class Song
    {
        public Song (string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int curentSong = 1; curentSong <= songsNumber; curentSong++)
            {
                string[] songInfo = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries);

                string songTypeList = songInfo[0];
                string songName = songInfo[1];
                string songTime = songInfo[2];

                Song song = new Song(songTypeList, songName, songTime);

                songs.Add(song);
            }

            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (typeList == song.TypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}

