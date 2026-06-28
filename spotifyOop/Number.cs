using System;
using System.Collections.Generic;
using System.Text;

namespace spotifyOop
{
    internal class Number : IPlayable
    {
        public string Name;
        public string Genre;
        public string Artist;

        public Number(string name, string genre, string artist)
        {
            this.Name = name;
            this.Genre = genre;
            this.Artist = artist;
        }

        public void Play()
        {
            Console.WriteLine($"playing: {Name} by: {Artist} gnere: {Genre}");
        }
    }
}
