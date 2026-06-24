using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace spotifyOop
{
    internal class User
    {
        public String Name;
        private List<Playlist> userPlaylists = [];
        public List<User> Friends = [];

        public User(String name)
        {
            this.Name = name;
        }

        

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
                Console.WriteLine();
            }
        }

        public void AddFriend(User user)
        {
            Friends.Add(user);
        }

      public void DeleteFriend (User user)
        {
            Friends.Remove(user);
        }


        public void CreatePlaylist(String name, Number? firstNumber)
        {
            userPlaylists.Add(new Playlist(name, this, firstNumber));
        }

        public Playlist? getPlayList(String name)
        {
            if (this.userPlaylists.Count > 0)
            {
                foreach (Playlist playlist in this.userPlaylists)
                {
                    if (playlist.Name == name)
                    {
                        return playlist;
                    }
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        public void addNumberOrAlbum(String name, Number? number, Album? album)
        {

        }
    }
}
