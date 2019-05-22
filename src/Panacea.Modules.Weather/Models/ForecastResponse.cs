﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace Panacea.Modules.Weather.Models
{
    [DataContract]
    public class ForecastResponse
    {
        [DataMember(Name = "list")]
        public List<ForecastData> List { get; set; }
    }

    [DataContract]
    public class ForecastData
    {
        private DateTime dt;

        [DataMember(Name = "dt_txt")]
        public DateTime Date
        {
            get {
                return dt;
            }
            protected set
            {
                dt=new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, DateTimeKind.Utc).ToLocalTime();
            }
        }

        [DataMember(Name = "main")]
        public Main Main { get; set; }

        [DataMember(Name = "weather")]
        public List<Weather> WeatherMain { get; set; }

        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; set; }

        public Geometry Icon
        {
            get
            {
                //sunny
                if (WeatherMain[0].Description.Contains("clear"))
                {
                    return Geometry.Parse(
                        "F1 M 30.2854,42.8956L 20.6695,22.2386L 19.383,19.4769L 42.4311,30.613L 40.965,31.6878L 40.1668,32.32L 40.2384,32.3545L 38.7528,33.6078C 36.8218,35.2354 34.9715,37.128 33.3466,39.0798L 32.107,40.5636L 32.0718,40.4796L 31.357,41.3969L 30.2854,42.8956 Z M 23.7954,73.4061L 24.078,75.2121L 0,66.5721L 22.3749,58.5383L 24.0845,57.9249L 23.7954,59.7368L 23.6692,60.8201L 23.7733,60.7772L 23.5974,62.7225C 23.4843,64.0213 23.4243,65.3359 23.4243,66.6665C 23.4243,67.9217 23.4894,69.1744 23.5974,70.4244L 23.7681,72.3567L 23.6665,72.3241L 23.7954,73.4061 Z M 60.2668,23.9146L 59.1925,24.0443L 57.3996,24.336L 64.9413,2.88409L 65.9529,-3.05176e-005L 74.5038,24.3372L 72.7187,24.0456L 71.6417,23.9146L 71.6783,24.0228L 69.7682,23.845C 68.5038,23.7357 67.2343,23.6705 65.9543,23.6705C 64.6744,23.6705 63.4075,23.7357 62.1431,23.845L 60.2304,24.0228L 60.2668,23.9146 Z M 91.7773,32.3548L 90.9452,31.6907L 89.4791,30.6223L 109.894,20.7929L 112.638,19.4667L 101.611,42.8905L 100.551,41.3996L 99.8931,40.5597L 99.8854,40.576L 99.4362,40.0278C 98.8958,39.3358 98.2994,38.697 97.7161,38.0415C 96.604,36.7863 95.4218,35.5905 94.1731,34.4733C 93.4934,33.8599 92.8385,33.2199 92.1184,32.6523L 91.7682,32.3548L 91.7773,32.3548 Z M 107.823,75.3044L 108.113,73.5025L 108.242,72.4192L 108.138,72.458L 108.313,70.5181C 108.419,69.2446 108.486,67.958 108.486,66.6678C 108.486,65.3735 108.419,64.089 108.313,62.8142L 108.138,60.869L 108.242,60.912L 108.113,59.8293L 107.823,58.0239L 131.91,66.6574L 107.823,75.3044 Z M 71.6459,109.416L 72.7162,109.282L 74.5013,108.993L 65.9479,133.333L 58.0091,110.717L 57.4076,108.997L 59.1927,109.282L 60.2617,109.416L 60.2227,109.307L 62.1407,109.486C 63.4049,109.594 64.6719,109.661 65.9519,109.661C 67.2331,109.661 68.5013,109.594 69.7656,109.486L 71.6836,109.307L 71.6459,109.416 Z M 100.551,91.9268L 101.611,90.4503L 112.652,113.777L 89.5743,102.618L 91.0313,101.549L 91.8659,100.883C 92.7096,100.229 93.4713,99.4685 94.267,98.7524C 95.8178,97.3358 97.3191,95.7798 98.6524,94.1637L 99.8932,92.6626L 99.9246,92.7328L 100.551,91.9268 Z M 40.047,100.909L 40.9637,101.638L 42.4415,102.717L 19.3816,113.742L 29.517,92.1L 30.293,90.4438L 31.3569,91.9295L 32.0756,92.8539L 32.1134,92.7705L 33.3465,94.2524C 34.9454,96.1781 36.7605,98.014 38.6681,99.63L 40.1303,100.869L 40.047,100.909 Z M 96.2944,89.0909C 88.9324,99.2393 77.5105,104.622 65.948,104.621C 58.2397,104.621 50.4468,102.219 43.7605,97.264C 33.7149,89.824 28.3933,78.2771 28.3933,66.5902C 28.3933,58.7926 30.7592,50.9144 35.6747,44.1547C 43.0326,33.9997 54.4468,28.6208 66.0092,28.6208C 73.7201,28.6208 81.5015,31.0128 88.2058,35.9808C 98.2436,43.4248 103.567,54.9652 103.567,66.656C 103.567,74.4464 101.194,82.3123 96.2944,89.0909 Z ");
                }
                //cloudy
                if (WeatherMain[0].Description.Contains("cloud"))
                {
                    return Geometry.Parse(
                        "F1 M 103.945,73.5389L 15.0429,73.5389C 6.74802,73.5389 0,66.7902 0,58.4973C 0,51.4596 4.85745,45.5364 11.3945,43.9022C 14.3119,36.6106 21.0586,31.388 28.9264,30.4504C 29.7559,13.5208 43.7904,-1.52588e-005 60.9239,-1.52588e-005C 73.4792,-1.52588e-005 84.6875,7.38145 89.888,18.341C 94.1588,16.0077 98.9713,14.7656 103.945,14.7656C 120.148,14.7656 133.333,27.9478 133.333,44.1522C 133.333,60.3566 120.151,73.5389 103.945,73.5389 Z M 14.9453,53.8293C 12.416,53.8815 10.3731,55.9556 10.3731,58.4973C 10.3731,61.0728 12.4668,63.1653 15.041,63.1653L 103.945,63.1653C 114.43,63.1653 122.958,54.6366 122.958,44.1522C 122.958,33.6678 114.431,25.1405 103.945,25.1405C 99.0338,25.1405 94.3724,27.0116 90.8151,30.4101L 84.0208,36.9035L 82.1484,27.694C 80.1107,17.6574 71.1849,10.3736 60.9239,10.3736C 48.9799,10.3736 39.2611,20.091 39.2611,32.035C 39.2611,33.0051 39.3333,34.0116 39.4734,35.0299L 40.4467,42.0793L 33.4388,40.8475C 32.7748,40.7317 32.1145,40.6718 31.4734,40.6718C 26.1373,40.6718 21.5013,44.4621 20.4505,49.6809L 19.584,53.9842L 15.1972,53.8424C 15.1145,53.8385 15.0293,53.8333 14.9453,53.8293 Z");

                }
                //rain
                if (WeatherMain[0].Description.Contains("rain") && WeatherMain[0].Description.Contains("light"))
                {
                    return Geometry.Parse(
                        "F1 M 103.944,73.5417L 15.041,73.5417C 6.74802,73.5417 0,66.7929 0,58.4974C 0,51.4596 4.85614,45.5345 11.3932,43.9036C 14.3119,36.6093 21.0573,31.3893 28.925,30.4506C 29.7532,13.5202 43.7877,3.05176e-005 60.9239,3.05176e-005C 73.4765,3.05176e-005 84.6849,7.38284 89.8855,18.3438C 94.1588,16.0078 98.9688,14.7643 103.944,14.7643C 120.148,14.7643 133.333,27.9466 133.333,44.1536C 133.333,60.3542 120.148,73.5417 103.944,73.5417 Z M 14.9451,53.8283C 12.4146,53.8841 10.3703,55.9584 10.3703,58.4975C 10.3703,61.0704 12.4653,63.1655 15.0395,63.1655L 103.942,63.1655C 114.429,63.1655 122.955,54.6362 122.955,44.1537C 122.955,33.6707 114.429,25.1402 103.942,25.1402C 99.031,25.1402 94.3695,27.0132 90.8148,30.4083L 84.018,36.9024L 82.1456,27.6948C 80.1104,17.6604 71.182,10.3779 60.9223,10.3779C 48.9783,10.3779 39.2595,20.092 39.2595,32.0359C 39.2595,33.0066 39.3318,34.0119 39.4692,35.0346L 40.4438,42.0801L 33.4347,40.8498C 32.7732,40.7344 32.1118,40.6745 31.4704,40.6745C 26.1359,40.6745 21.4984,44.4643 20.449,49.6843L 19.5824,53.9896L 15.1944,53.8477L 14.9451,53.8283 Z M 39.2888,84.8764C 37.5226,91.6251 38.533,94.974 38.0409,102.225C 37.5662,109.253 30.4022,112.458 25.1222,109.412C 19.8397,106.362 19.0395,98.5587 24.8891,94.6302C 30.921,90.5835 34.3201,89.7827 39.2888,84.8764 Z M 75.5051,84.8763C 73.7395,91.625 74.7499,94.974 74.2577,102.225C 73.7837,109.253 66.6184,112.458 61.3398,109.412C 56.0572,106.362 55.6489,98.5586 61.4985,94.6302C 67.5337,90.5834 70.5363,89.7826 75.5051,84.8763 Z M 112.51,84.8763C 110.745,91.625 111.755,94.9739 111.263,102.225C 110.788,109.253 103.624,112.458 98.345,109.411C 93.0612,106.362 92.263,98.5586 98.1106,94.6302C 104.141,90.5834 107.539,89.7826 112.51,84.8763 Z ");

                }
                //heavy rain
                if (WeatherMain[0].Description.Contains("rain"))
                {
                    return
                        Geometry.Parse(
                            "F1 M 103.944,14.7643C 98.9713,14.7643 94.1588,16.0077 89.8855,18.3438C 84.6875,7.38283 73.4765,1.52588e-005 60.9239,1.52588e-005C 43.789,1.52588e-005 29.752,13.5215 28.925,30.4506C 21.0573,31.3893 14.3118,36.6093 11.3932,43.9036C 4.85614,45.5344 0,51.4596 0,58.4974C 0,66.7943 6.74933,73.5416 15.0411,73.5416L 52.1361,73.5416L 46.4851,84.8763L 55.1028,84.8763L 38.3744,110.562L 82.3047,79.4192L 68.0208,79.25L 73.3593,73.5429L 103.943,73.5429C 120.148,73.5429 133.332,60.3541 133.332,44.1536C 133.333,27.9479 120.148,14.7643 103.944,14.7643 Z M 103.944,63.1667L 15.0411,63.1667C 12.4655,63.1667 10.3717,61.0728 10.3717,58.4974C 10.3717,55.9583 12.4147,53.884 14.9454,53.8281C 15.028,53.8359 15.112,53.8398 15.196,53.8438L 19.584,53.987L 20.4505,49.681C 21.5,44.4616 26.1386,40.6719 31.472,40.6719C 32.1133,40.6719 32.776,40.7304 33.4375,40.8463L 40.4467,42.0787L 39.4734,35.0332C 39.3347,34.0118 39.2643,33.0052 39.2643,32.0344C 39.2643,20.0904 48.9824,10.3763 60.9264,10.3763C 71.1875,10.3763 80.1146,17.6588 82.1484,27.6934L 84.0235,36.901L 90.8178,30.4068C 94.3751,27.013 99.0364,25.1399 103.947,25.1399C 114.434,25.1399 122.961,33.6705 122.961,44.1536C 122.961,54.636 114.431,63.1667 103.944,63.1667 Z ");
                }
                //snow
                
                    return
                        Geometry.Parse(
                            "F1 M 103.944,73.543L 15.041,73.543C 6.74933,73.543 0,66.793 0,58.4974C 0,51.4597 4.85614,45.5358 11.3932,43.9037C 14.3119,36.6095 21.0573,31.3893 28.925,30.4505C 29.752,13.5202 43.7891,-1.52588e-005 60.9239,-1.52588e-005C 73.4765,-1.52588e-005 84.6849,7.38277 89.8855,18.3439C 94.1588,16.0079 98.9688,14.7644 103.944,14.7644C 120.148,14.7644 133.333,27.948 133.333,44.1537C 133.333,60.3555 120.148,73.543 103.944,73.543 Z M 14.9452,53.8282C 12.416,53.8842 10.3717,55.9584 10.3717,58.4962C 10.3717,61.0704 12.4654,63.1655 15.0409,63.1655L 103.944,63.1655C 114.431,63.1655 122.957,54.6362 122.957,44.1525C 122.957,33.668 114.431,25.1388 103.944,25.1388C 99.0337,25.1388 94.3723,27.0118 90.8149,30.4057L 84.0207,36.8998L 82.1458,27.6922C 80.1119,17.6577 71.1848,10.3752 60.9237,10.3752C 48.9797,10.3752 39.261,20.0893 39.261,32.0332C 39.261,33.004 39.3332,34.0093 39.4706,35.032L 40.4439,42.0775L 33.4348,40.8465C 32.7733,40.7319 32.1119,40.6719 31.4694,40.6719C 26.136,40.6719 21.4972,44.4617 20.4478,49.6811L 19.5812,53.9871L 15.1932,53.8439L 14.9452,53.8282 Z M 37.1236,95.9806C 40.8931,95.9806 40.8931,101.831 37.1236,101.831L 32.0787,101.831L 34.5891,106.189C 36.4823,109.458 31.4211,112.405 29.5357,109.142L 27.0089,104.763L 24.481,109.142C 22.5975,112.405 17.5357,109.458 19.4276,106.189L 21.94,101.831L 16.8944,101.831C 13.1237,101.831 13.1237,95.9806 16.8944,95.9806L 21.94,95.9806L 19.4276,91.629C 17.5357,88.353 22.5975,85.4103 24.481,88.6732L 27.0089,93.0535L 29.5357,88.6732C 31.4211,85.4103 36.4823,88.353 34.5891,91.629L 32.0787,95.9806L 37.1236,95.9806 Z M 76.7734,95.9805C 80.5507,95.9805 80.5507,101.831 76.7734,101.831L 71.7356,101.831L 74.2472,106.189C 76.1406,109.458 71.078,112.405 69.1926,109.142L 66.6666,104.763L 64.1399,109.142C 62.2467,112.405 57.1932,109.458 59.0865,106.189L 61.5975,101.831L 56.552,101.831C 52.7825,101.831 52.7825,95.9805 56.552,95.9805L 61.5975,95.9805L 59.0865,91.629C 57.1932,88.353 62.2467,85.4103 64.1399,88.6732L 66.6666,93.0535L 69.1926,88.6732C 71.078,85.4103 76.1406,88.353 74.2472,91.629L 71.7356,95.9805L 76.7734,95.9805 Z M 116.431,95.9805C 120.21,95.9805 120.21,101.831 116.431,101.831L 111.393,101.831L 113.906,106.189C 115.797,109.458 110.736,112.405 108.852,109.142L 106.324,104.763L 103.797,109.142C 101.904,112.405 96.8516,109.458 98.7448,106.189L 101.255,101.831L 96.2096,101.831C 92.4401,101.831 92.4401,95.9805 96.2096,95.9805L 101.255,95.9805L 98.7448,91.6289C 96.8516,88.3529 101.904,85.4103 103.797,88.6732L 106.324,93.0535L 108.852,88.6732C 110.736,85.4103 115.797,88.3529 113.906,91.6289L 111.393,95.9805L 116.431,95.9805 Z ");

                
            }
        }
    }
}