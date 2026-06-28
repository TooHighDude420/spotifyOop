using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace spotifyOop
{

    internal class SpotifyFacade
    {
        public List<Number> allNumbers { get; } = [];
        public List<Album> allAlbums { get; } = [];
        public List<User> allUsers { get; } = [];

        public SpotifyFacade()
        {
            List<Number> bad = [
                new Number("Another part of me", "Pop", "Michael Jackson"),
                new Number("Bad", "Pop", "Michael Jackson"),
                new Number("Dirty Diana", "Pop", "Michael Jackson"),
                new Number("Just good friends", "Pop", "Michael Jackson"),
                new Number("Leave me alone", "Pop", "Michael Jackson"),
                new Number("Liberain girl", "Pop", "Michael Jackson"),
                new Number("Man in the mirror", "Pop", "Michael Jackson"),
                new Number("Smooth Criminal", "Pop", "Michael Jackson"),
                new Number("Speed Demon", "Pop", "Michael Jackson"),
                new Number("The way you make me feel", "Pop", "Michael Jackson"),
                new Number("I just can't stop loving u", "Pop", "Michael Jackson")
            ];

            allNumbers.AddRange(bad);

            List<Album> tmppalbums = [
                new Album("bad", ["Pop"], bad),
                new Album("bad", ["Pop"], bad)
            ];

            allAlbums.AddRange(tmppalbums);

            List<User> tmpusers = [
                new User("main"),
                new User("friend"),
                new User("Nataro"),
                new User("Senna"),
                new User("Robbert"),
                new User("Jasmijn")
            ];

            allUsers.AddRange(tmpusers);
        }

        public User? GetUser(string username)
        {
            List<User> found = allUsers.Where((User) => { return User.Name == username; }).ToList();

            if (found.Count > 0 && found.Count < 2)
            {
                return found[0];
            }
            else
            {
                return null;
            }
        }

        public List<User> GetUsers(User cUser)
        {
            List<User> users = allUsers.Where<User>((User user) =>
            {
                return user.Name != cUser.Name && !cUser.Friends.Contains(user);
            }).ToList();

            return users;
        }

        public List<User> GetFriends(User user)
        {
            return user.Friends;
        }

        public void RemoveFriend(User user, User friend)
        {
            user.Friends.Remove(friend);
        }
        //public List<User> getUsers()
        //{
        //    return allUsers;
        //}

        public Album? GetAlbum(int index)
        {
            Album tmpalbum;

            try
            {
                tmpalbum = allAlbums[index];
            }
            catch (Exception ex)
            {
                return null;
            }

            return tmpalbum;
        }

        public void AddNumber(NumberCollection numberCollection, Number number)
        {
            numberCollection.Add(number);
        }

        public void AddNumbers(NumberCollection numberCollection, List<Number> numbers)
        {
            numberCollection.Add(numbers);
        }

        public void CreatePlaylist(User user, String name, Number? firstNumber = null)
        {
            user.CreatePlaylist(name, firstNumber);
        }
        public void CreatePlaylist(User user, String name, NumberCollection? firstNumbers = null)
        {
            user.CreatePlaylist(name, firstNumbers);
        }

        public void DeletePlaylist(User user, Playlist playlist)
        {
            user.userPlaylists.Remove(playlist);
        }

        public List<string> ShowAllPlaylists(User user, List<string>? addition = null)
        {
            List<String> returnstring = [];

            int index = 1;

            foreach (Playlist tmlist in user.userPlaylists)
            {
                returnstring.Add(tmlist.Name);
                index++;
            }

            if (addition != null)
            {
                returnstring.AddRange(addition);
            }

            return returnstring;
        }

        public List<string> ShowAllNumbers(NumberCollection numberCollection)
        {
            return numberCollection.ShowAllNumbers();
        }

        public void PlayPlayable(IPlayable playable)
        {
            playable.Play();
        }

        public Number? GetNumber(NumberCollection numberCollection, int index)
        {
            return numberCollection.GetNumber(index);
        }

        public Number? GetNumber(string name)
        {
            foreach (Number number in allNumbers)
            {
                if (name.Contains(','))
                {
                    name = name.Split(',')[0];
                }

                if (number.Name == name) return number;
            }

            return null;
        }

        public List<string> GetAllNumbers(List<string>? addition)
        {
            List<string> numbers = [];

            foreach (Number number in allNumbers)
            {
                numbers.Add($"{number.Name}, by {number.Artist}");
            }

            if (addition != null)
            {
                numbers.AddRange(addition);
            }

            return numbers;
        }

        public void ShowUserFriends(User user)
        {
            user.showFriends();
        }

        public void AddFriend(User user, User friend)
        {
            user.AddFriend(friend);
        }

        public Playlist? GetPlaylist(User user, String name)
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

        public List<Playlist> GetPlaylists(User user)
        {
            return user.userPlaylists;
        }

        public void AddPlaylist(Playlist playlist, User user)
        {
            user.CreatePlaylist(playlist.Name, playlist);
        }
    }
}
