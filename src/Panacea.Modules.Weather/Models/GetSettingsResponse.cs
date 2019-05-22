using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Panacea.Modules.Weather.Models
{
    [DataContract]
    public class GetSettingsResponse
    {
        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [DataMember(Name = "location")]
        public List<LocationSettings> Location { get; set; }

        [DataMember(Name = "apiCacheUrl")]
        public string ServerUrl { get; set; }

        public string TempratureSign
        {
            get
            {
                if (this.Unit == "imperial")
                    return "°F";
                else if (this.Unit == "metric")
                    return "°C";
                else
                    return "°K";
            }
        }
    }
}
