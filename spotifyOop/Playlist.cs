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
                Add(firstSong);
            }
        }

        public Playlist(String name, User user, List<Number>? firstSong) : base(name)
        {
            this.user = user;

            if (firstSong != null)
            {
                Add(firstSong);
            }
        }
    }
}
