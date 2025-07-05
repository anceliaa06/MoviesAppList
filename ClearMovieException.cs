using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAppWithList
{
    internal class ClearMoviesException : Exception
    {
        public ClearMoviesException(string message) : base(message)
        {
        }
       
    }
}
