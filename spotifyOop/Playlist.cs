using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace spotifyOop
{
    internal class Playlist : NumberCollection
    {
        public User user;

        public Playlist(String name, User user, Number? firstSong) : base(name)
        {
            this.user = user;

            if (firstSong != null)
            {
                AddNumber(firstSong);
            }
        }

        public void AddNumber(Number number)
        {
            this.Add(number);
        }

        public void AddNumbers(List<Number> numbers)
        {
            this.Add(numbers);
        }

        public void RemoveNumber(Number number)
        {
            this.Remove(number);
        }

        public void Play()
        {
            foreach (Number number in Numbers)
            {
                number.Play();
            }
        }
    }
}
