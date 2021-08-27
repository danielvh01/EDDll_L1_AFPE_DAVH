using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EDDll_L1_AFPE_DAVH.Models
{
    public class MovieModel : IComparable
    {
        public string Director { get; set; }
        public double IMBDRating { get; set; }
        public string Genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string Title { get; set; }

        public int CompareTo(object obj)
        {
            var comparer = ((MovieModel)obj).Title;
            return Title.CompareTo(comparer);
        }

    }
}
