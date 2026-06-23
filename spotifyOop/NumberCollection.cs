using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace spotifyOop
{
    internal class NumberCollection
    {
        public String Name;
        public List<Number> Numbers = [];

        public NumberCollection(String name)
        {
            this.Name = name;
        }

        public void Add(Number number)
        {
            this.Numbers.Add(number);
        }

        public void Add(List<Number> numbers)
        {
            foreach (Number number in numbers)
            {
                this.Add(number);
            }
        }

        public void Remove(Number number)
        {
            this.Numbers.Remove(number);
        }
    }
}
