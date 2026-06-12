using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace spotifyOop
{
    internal class Albums(String name, List<String> genres, List<Number> numbers)
    {
        private List<Number> Album = [];
        public IReadOnlyList<Number> ReadAlbum
        {
            get {
                return this.Album.ToImmutableList(); 
            }
        }

        public String Name { get; } = name;
        public List<String> Genre { get; } = genres;
    }
}
