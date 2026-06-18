using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace spotifyOop
{
    internal class Album
    {
        private List<Number> Albums = [];
        public IReadOnlyList<Number> ReadAlbum
        {
            get {
                return this.Albums.ToImmutableList(); 
            }
        }

        public String Name { get; }
        public String Genre { get; }

        public Album(String name, String genre, List<Number> numbers)
        {
            this.Name = name;
            this.Genre = genre;

            foreach (Number number in numbers)
            {
                Albums.Add(number);
            }

        }
    }
}
