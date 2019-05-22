using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Panacea.Modules.Weather.Models
{
    [DataContract]
    public class WeatherResponse
    {
        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "sys")]
        public Sys Sys { get; set; }

        [DataMember(Name = "weather")]
        public List<Weather> Weather { get; set; }

        [DataMember(Name = "main")]
        public Main Main { get; set; }

        public Uri Image
        {
            get
            {
                var clouds = Clouds.All;
                if (clouds < 33)
                {
                    return new Uri("pack://application:,,,/Panacea.Modules.Weather;component/Assets/clouds0.png",
                        UriKind.RelativeOrAbsolute);
                }
                if (clouds < 66)
                {
                    return new Uri("pack://application:,,,/Panacea.Modules.Weather;component/Assets/clouds1.png",
                        UriKind.RelativeOrAbsolute);
                }
                return new Uri("pack://application:,,,/Panacea.Modules.Weather;component/Assets/clouds2.png",
                    UriKind.RelativeOrAbsolute);

            }
        }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember(Name = "all")]
        public int All { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember(Name = "temp")]
        public double Temp { get; set; }

        [DataMember(Name = "temp_min")]
        public double TempMin { get; set; }

        [DataMember(Name = "temp_max")]
        public double TempMax { get; set; }

        [DataMember(Name = "humidity")]
        public double Humidity { get; set; }
    }
}
