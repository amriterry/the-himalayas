using System.Collections.Generic;

namespace TheHimalayas.Core {

    public class Forecast {

        /// <summary>
        /// 
        /// Name of the city
        /// 
        /// </summary>
        public string cityName;

        /// <summary>
        /// 
        /// Location of the city
        /// 
        /// </summary>
        public Location location;

        /// <summary>
        /// 
        /// List of weathers
        /// 
        /// </summary>
        private List<WeatherMeta> weathers;

        /// <summary>
        /// 
        /// Create a forecast object
        /// 
        /// </summary>
        public Forecast() {
            weathers = new List<WeatherMeta>();
        }

        /// <summary>
        /// 
        /// Returns list of weather objects
        /// 
        /// </summary>
        /// <returns>List of weather objects</returns>
        public List<WeatherMeta> GetWeatherList() {
            return weathers;
        }

        /// <summary>
        /// 
        /// Adds weather to the end of the list.
        /// 
        /// </summary>
        /// <param name="weather">Weather to add to the list</param>
        public void AddWeather(WeatherMeta weather) {
            weathers.Add(weather);
        }
    }
}