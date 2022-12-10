using System;
using System.Collections.Generic;

namespace BirdsApi.Models
{
    public class Bird
    {
        public int BirdId { get; set; }
        public string Species { get; set; }
        public string Binomial_name { get; set; }
        public string Conservation_status { get; set; }


        public List<Sighting> Sightings { get; set; } = new List<Sighting>();

    }

}
 
