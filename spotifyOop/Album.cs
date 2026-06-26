using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace spotifyOop
{
    internal class Album : NumberCollection
    {
        public IReadOnlyList<Number> ReadAlbum
        {
            get {
                return this.Numbers.ToImmutableList(); 
            }
        }

        public List<String> Genre { get; }

        public Album(String name, List<String> genres, List<Number> numbers) : base(name)
        {
            this.Genre = genres;
            Add(numbers);
        }
        public void Play()

        {

            foreach (Number number in Numbers)

            {

                number.Play();

            }

        }

        public void ShowAlbum()
        {
            Console.WriteLine($"Album: {this.Name}");
            Console.WriteLine($"Artiest: {this.Numbers[0].Artist}");

            Console.WriteLine("Nummers:");
            foreach (Number number in this.Numbers)
            {
                Console.WriteLine($"- {number.Name}");
            }
        }

    }
}
