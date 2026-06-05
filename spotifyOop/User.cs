using System;
using System.Collections.Generic;
using System.Text;

namespace spotifyOop
{
    internal class User(String name)
    {
        public String Name { get; } = name;
        public Dictionary<String, Playlist> userPlaylists = [];

        public void CreatePlaylist(String name, Number? firstNumber)
        {
            if (userPlaylists.ContainsKey(name)) {
                throw new ArithmeticException("playlist with that name already in use");
            }

            if (firstNumber != null)
            {
                userPlaylists[name] = new Playlist();
                userPlaylists[name].addNumber(firstNumber);
            }
            
            else
            {
                userPlaylists[name] = new Playlist();
            }
        }

        public void AddNumber(String playlistName, Number number) {
            if (userPlaylists.ContainsKey(playlistName))
            {
                userPlaylists[playlistName].addNumber(number);
            } else
            {
                throw new ArgumentException("playlist does not excists");
            }
        }
    }
}
