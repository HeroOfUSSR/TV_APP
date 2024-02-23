using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TV_APP.OpenWeather
{
    class OpenWeather
    {
        [JsonProperty("base")]
        public string Base;

        public double visibility;

        public double dt;

        public string name;

        public int cod;

        public weather weather;

        public main main;

    }
}
