using System;
using TheHimalayas.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.UI {

    public class ForecastUI : MonoBehaviour {

        /// <summary>
        /// 
        /// Location of mountain text
        /// 
        /// </summary>
        public Text locationText;

        /// <summary>
        /// 
        /// Corrdinates of mountain text
        /// 
        /// </summary>
        public Text coordinatesText;

        /// <summary>
        /// 
        /// Temperature text
        /// 
        /// </summary>
        public Text temperatureText;

        /// <summary>
        /// 
        /// Minimum and Maximum Temperature text
        /// 
        /// </summary>
        public Text minMaxTempText;

        /// <summary>
        /// 
        /// Pressure Text
        /// 
        /// </summary>
        public Text pressureText;

        /// <summary>
        /// 
        /// Cloudiness text
        /// 
        /// </summary>
        public Text cloudinessText;

        /// <summary>
        /// 
        /// Last Data Calculation Time text
        /// 
        /// </summary>
        public Text dctText;

        /// <summary>
        /// 
        /// Updates Weather Meta in the UI
        /// 
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="location">Location of the mountain</param>
        /// <param name="weatherMeta">Weather meta Object</param>
        public void UpdateWeatherMeta(string cityName,Location location,WeatherMeta weatherMeta) {
            UpdateLocation(cityName);

            UpdateCoordinates(location.ToString());

            UpdateTemperature(weatherMeta.temperature.ToCelciusString());

            UpdateMinMaxTemperature(weatherMeta.minTemperature.ToCelciusString(), weatherMeta.maxTemperature.ToCelciusString());

            UpdatePressure(weatherMeta.pressure);

            UpdateCloudiness(weatherMeta.Cloudiness);

            UpdateDCT(weatherMeta.DataCalculationTime);
        }
       
        /// <summary>
        /// 
        /// Updates City location
        /// 
        /// </summary>
        /// <param name="city">City to be updated</param>
        private void UpdateLocation(string city) {
            locationText.text = "City: " + city;
        }

        /// <summary>
        /// 
        /// Updates Coordinates
        /// 
        /// </summary>
        /// <param name="coordinatesString">Coordinate to be updated</param>
        private void UpdateCoordinates(string coordinatesString) {
            coordinatesText.text = "Coordinates: " + coordinatesString;
        }

        /// <summary>
        /// 
        /// Updates temperature
        /// 
        /// </summary>
        /// <param name="temp">Temperature to be updated</param>
        private void UpdateTemperature(string temp) {
            temperatureText.text = "Temperature: " + temp;
        }

        /// <summary>
        /// 
        /// Updates Min Max Temperature
        /// 
        /// </summary>
        /// <param name="minTemp">Minimum Temperature</param>
        /// <param name="maxTemp">Maximum Temperature</param>
        private void UpdateMinMaxTemperature(string minTemp, string maxTemp) {
            minMaxTempText.text = "Min Temp: " + minTemp + ", Max Temp: " + maxTemp;
        }

        /// <summary>
        /// 
        /// Updates pressure
        /// 
        /// </summary>
        /// <param name="pressure">Pressure to be updated</param>
        private void UpdatePressure(float pressure) {
            pressureText.text = "Pressure: " + pressure + " hPa";
        }

        /// <summary>
        /// 
        /// Updates Cloudiness
        /// 
        /// </summary>
        /// <param name="cloudiness">Cloudiness to be updated</param>
        private void UpdateCloudiness(float cloudiness) {
            cloudinessText.text = "Cloudiness: " + cloudiness + "%";
        }

        /// <summary>
        /// 
        /// Updates Last Data Calculation Time
        /// 
        /// </summary>
        /// <param name="dct">Last Data Calculation Time</param>
        private void UpdateDCT(DateTime dct) {
            dctText.text = "Last DCT: " + string.Format("{0:g}", dct);
        }
    }
}