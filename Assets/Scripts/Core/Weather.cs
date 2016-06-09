using System;

namespace TheHimalayas.Core {

    public class Weather {

        /// <summary>
        /// 
        /// Location of the weather
        /// 
        /// </summary>
        public Location location;

        /// <summary>
        /// 
        /// Temperature of the location
        /// 
        /// </summary>
        public Temperature temperature;

        /// <summary>
        /// 
        /// Minimum Temperature of the location
        /// 
        /// </summary>
        public Temperature minTemperature;

        /// <summary>
        /// 
        /// Maximum Temperature of the location
        /// 
        /// </summary>
        public Temperature maxTemperature;

        /// <summary>
        /// 
        /// Pressure in the location
        /// 
        /// </summary>
        public float pressure;

        /// <summary>
        /// 
        /// Cloudiness in percentage
        /// 
        /// </summary>
        private float cloudiness;

        /// <summary>
        /// 
        /// Cloudiness property
        /// 
        /// </summary>
        public float Cloudiness {
            get {
                return cloudiness;
            }

            set {
                cloudiness = value;

                if (value > 100f || value < 0f) {
                    cloudiness = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// City Name
        /// 
        /// </summary>
        public string cityName;
        

        /// <summary>
        /// 
        /// Last Data Calculation Time
        /// 
        /// </summary>
        public double dataCalculationTime;

        /// <summary>
        /// 
        /// Data Calculation Time Property to get date in DateTime format
        /// 
        /// </summary>
        public DateTime DataCalculationTime {
            get {
                return TheHimalayas.Utils.DateTime.UnixTimeStampToDateTime(dataCalculationTime);
            }
        }
    }
}