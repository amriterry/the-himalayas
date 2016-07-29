using System;
using TheHimalayas.Core;
using TheHimalayas.Engine;
using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.UI {

    public class MountainWeatherUIManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Array of Mountain Texts
        /// 
        /// </summary>
        public Text[] mountainTexts;

        /// <summary>
        /// 
        /// Weather status text
        /// 
        /// </summary>
        public Text weatherStatusText;

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

        // When the script first starts
        void Start() {
            SetWeatherLoadingText();

            Invoke("SetCurrentMountainTexts", 0.05f);
        }

        /// <summary>
        /// 
        /// Set's the Loading text
        /// 
        /// </summary>
        public void SetWeatherLoadingText() {
            TruncateWeatherUITexts();

            weatherStatusText.text = "Fetching Weather data...";
            temperatureText.alignment = TextAnchor.MiddleCenter;
            temperatureText.text = "Fetching Weather data...";
        }

        /// <summary>
        /// 
        /// Removes all Weather UI Texts
        /// 
        /// </summary>
        private void TruncateWeatherUITexts() {
            locationText.text = "";
            coordinatesText.text = "";
            temperatureText.text = "";
            minMaxTempText.text = "";
            pressureText.text = "";
            cloudinessText.text = "";
            dctText.text = "";
            temperatureText.alignment = TextAnchor.MiddleLeft;
        }

        /// <summary>
        /// 
        /// Updates Mountain Texts
        /// 
        /// </summary>
        /// <param name="mountain">Mountain for which the mountain text is to be updated</param>
        public void UpdateMountainTexts(Mountain mountain) {
            foreach(Text t in mountainTexts) {
                t.text = mountain.name;
            }
        }

        public void SetCurrentMountainTexts() {
            UpdateMountainTexts(AppEngine.Instance.GetMountainStore().GetPointedMountain());
        }

        /// <summary>
        /// 
        /// Updates Weather information in UI for the mountain
        /// 
        /// </summary>
        /// <param name="weather">Weather information which is to be updated</param>
        public void UpdateMountainWeather(Weather weather) {
            TruncateWeatherUITexts();

            weatherStatusText.text = "Weather: at " + weather.temperature.ToCelciusString() + " in '" + weather.cityName + "'";

            UpdateLocation(weather.cityName);

            UpdateCoordinates(weather.location.ToString());

            UpdateTemperature(weather.temperature.ToCelciusString());

            UpdateMinMaxTemperature(weather.minTemperature.ToCelciusString(), weather.maxTemperature.ToCelciusString());

            UpdatePressure(weather.pressure);

            UpdateCloudiness(weather.Cloudiness);

            UpdateDCT(weather.DataCalculationTime);
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