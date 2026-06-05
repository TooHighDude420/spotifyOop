using System;
using System.Collections.Generic;
using System.Text;

namespace spotifyOop
{

    internal class SpotifyFacade
    {
        private User mainUser = new("main");
        public List<Number> allNumbers { get; } = new List<Number>();

        public void addNumber(Number number)
        {
            mainUser.AddNumber(number);
        }
    }
}
