using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAppWithList
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int YearOfRelease { get; set; }
        public string Genre { get; set; }

        public double Rating { get; set; }

        // Default constructor
        public Movie()
        {
            Id = 0;
            Name = string.Empty;
            YearOfRelease = 0;
            Genre = string.Empty;
            Rating = 0.0;
        }



        public override string ToString()
        {
            return $"ID: {Id} NAME: {Name} YEAR: {YearOfRelease},  GENRE: {Genre}";
        }
    }
}
