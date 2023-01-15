using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisServe.Database
{
    public class PredictedServe
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public string Sets { get; set; }

        public string Games { get; set; }

        public string Points { get; set; }

        public string Side { get; set; }

        public string Position { get; set; }

        //public byte[] CourtImage { get; set; }
    }
}
