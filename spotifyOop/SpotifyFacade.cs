using System;
using System.Collections.Generic;
using System.Text;

namespace spotifyOop
{

    internal class SpotifyFacade
    {
        public List<Number> allNumbers { get; } = new List<Number>();

        public void addNumber(User user, Playlist playlist, Number number)
        { 
            if (playlist != null)
            {
                playlist.addNumber(number);
            }
        }

        public void createPlaylist(User user, String name, Number? firstNumber)
        {
            user.CreatePlaylist(name, firstNumber);
        }

        public void showUserFriends(User user)
        {
            user.showFriends();
        }

        public void addFriend(User user)
        {
            user.AddFriend(user);
        }

        public Playlist? getPlaylist(User user, String name) 
        {
            if (user.getPlayList(name) != null)
            {
                return user.getPlayList(name);
            }

            else
            {
                throw new ArithmeticException("playlist does not exsist");
            }
        }
    }
}
