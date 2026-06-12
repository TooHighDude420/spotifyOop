using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace spotifyOop
{
    internal class Albums
    {
        private List<Number> Album = [];
        public IReadOnlyList<Number> ReadAlbum
        {
            get {
                return this.Album.ToImmutableList(); 
            }
        }

        public String Name { get; }
        public List<String> Genre { get; }

        public Albums(String name, List<String> genres, List<Number> numbers)
        {
            this.Name = name;
            this.Genre = genres;

            foreach (Number number in numbers)
            {
                Album.Add(number);
            }

        }
    }
}
