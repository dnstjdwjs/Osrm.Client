using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class Intersection
    {
        [JsonPropertyName("location")]
        public decimal[] LocationArr { get; set; }

        public Location Location
        {
            get
            {
                if (LocationArr == null)
                    return null;

                return new Location(LocationArr[0], LocationArr[1]);
            }
        }

        [JsonPropertyName("bearings")]
        public int[] Bearings { get; set; }

        [JsonPropertyName("entry")]
        public bool[] Entry { get; set; }

        [JsonPropertyName("in")]
        public int IndexIn { get; set; }

        [JsonPropertyName("out")]
        public int IndexOut { get; set; }

    }
}