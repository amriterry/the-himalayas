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
        /// City Name
        /// 
        /// </summary>
        public string cityName;

        /// <summary>
        /// 
        /// Core Weather Data
        /// 
        /// </summary>
        public WeatherMeta weatherMeta;

        /// <summary>
        /// 
        /// Temperature Property
        /// 
        /// </summary>
        public Temperature temperature {
            get {
                return weatherMeta.temperature;
            }

            set {
                weatherMeta.temperature = value;
            }
        }

        /// <summary>
        /// 
        /// Minimum Temperature of the location
        /// 
        /// </summary>
        public Temperature minTemperature {
            get {
                return weatherMeta.minTemperature;
            }

            set {
                weatherMeta.minTemperature = value;
            }
        }

        /// <summary>
        /// 
        /// Maximum Temperature of the location
        /// 
        /// </summary>
        public Temperature maxTemperature {
            get {
                return weatherMeta.maxTemperature;
            }

            set {
                weatherMeta.maxTemperature = value;
            }
        }

        /// <summary>
        /// 
        /// Pressure in the location
        /// 
        /// </summary>
        public float pressure {
            get {
                return weatherMeta.pressure;
            }

            set {
                weatherMeta.pressure = value;
            }
        }

        /// <summary>
        /// 
        /// Cloudiness property
        /// 
        /// </summary>
        public float Cloudiness {
            get {
                return weatherMeta.Cloudiness;
            }

            set {
                weatherMeta.Cloudiness = value;
            }
        }

        /// <summary>
        /// 
        /// Last Data Calculation Time
        /// 
        /// </summary>
        public double dataCalculationTime {
            get {
                return weatherMeta.dataCalculationTime;
            }

            set {
                weatherMeta.dataCalculationTime = value;
            }
        }

        /// <summary>
        /// 
        /// Data Calculation Time Property to get date in DateTime format
        /// 
        /// </summary>
        public DateTime DataCalculationTime {
            get {
                return weatherMeta.DataCalculationTime;
            }
        }

        /// <summary>
        /// 
        /// Create a weather objet
        /// 
        /// </summary>
        public Weather() {
            weatherMeta = new WeatherMeta();
        }
    }
}