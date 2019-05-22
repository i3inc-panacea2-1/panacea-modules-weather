using System.Runtime.Serialization;
using System;


namespace Panacea.Modules.Weather.Models
{
    [DataContract]
    public class LocationSettings
    {
        [DataMember(Name = "country")]
        public String Country { get; set; }

        [DataMember(Name = "city")]
        public String City { get; set; }
    }
}
