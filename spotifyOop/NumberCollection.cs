using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace spotifyOop
{
    internal class NumberCollection: IPlayable
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

        public List<string> ShowAllNumbers(List<string>? addition = null)
        {
            List<string> returnstring = [];

            foreach (Number tmpnum in this.Numbers)
            {
                returnstring.Add(tmpnum.Name);
            }

            if (addition != null)
            {
                returnstring.AddRange(addition);
            }

            return returnstring;
        }

        public Number? GetNumber(int index)
        {
            Number? tmpnum = null;

            if (index < this.Numbers.Count - 1)
            {
                tmpnum = this.Numbers[index];
            }

            return tmpnum;
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
