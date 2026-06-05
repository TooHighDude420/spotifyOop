using System;
using System.Collections.Generic;
using System.Text;

namespace spotifyOop
{
    internal class Playlist
    {
        public List<Number> playlist = [];

        public void addNumber(Number number)
        {
            playlist.Add(number);
        }

    }
}
