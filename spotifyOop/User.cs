using System;
using System.Collections.Generic;
using System.Text;

namespace spotifyOop
{
    internal class User(String name)
    {
        public String Name { get; } = name;
        public Dictionary<String, Playlist> userPlaylists = [];
        public List<User> Friends = [];

        public void showFriends()
        {
            if (Friends.Count > 0)
            {
                foreach (var friend in Friends)
                {
                    Console.WriteLine($"name:{friend.Name}, playlists count:{friend.userPlaylists.Count}");
                }
            }
            
            else
            {
                Console.WriteLine("no friends");
            }
        }

        public void AddFriend (User user)  
        {
            Friends.Add(user);
        }
        
        public void CreatePlaylist(String name, Number? firstNumber)
        {
            if (userPlaylists.ContainsKey(name)) 
            {
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

        public Playlist? getPlayList(String name)
        {
            if (this.userPlaylists.ContainsKey(name))
            {
                return this.userPlaylists[name];
            }

            else
            {
                return null;
            }
        }
    }
}
