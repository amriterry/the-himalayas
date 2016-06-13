using System;
using TheHimalayas.Core;
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
        /// Weather text
        ///  
        /// </summary>
        public Text weatherText;

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
        /// Detail Weather panel
        /// 
        /// </summary>
        public GameObject detailWeatherPanel;

        /// <summary>
        /// 
        /// Opens Detail Weather Panel
        /// 
        /// </summary>
        public void OpenDetailWeatherPanel() {
            detailWeatherPanel.SetActive(true);
        }

        /// <summary>
        /// 
        /// Closes Detail Weather Panel
        /// 
        /// </summary>
        public void CloseDetailWeatherPanel() {
            detailWeatherPanel.SetActive(false);
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

        /// <summary>
        /// 
        /// Updates Weather information in UI for the mountain
        /// 
        /// </summary>
        /// <param name="weather">Weather information which is to be updated</param>
        public void UpdateMountainWeather(Weather weather) {
            weatherStatusText.text = "weather: at " + weather.temperature.ToCelciusString() + " in '" + weather.cityName + "'";

            locationText.text = "City: " +weather.cityName;

            weatherText.text = "weather";

            coordinatesText.text = "Coordinates: " +weather.location.ToString();

            temperatureText.text = "Temperature: " + weather.temperature.ToCelciusString();

            minMaxTempText.text = "Min Temp: " + weather.minTemperature.ToCelciusString() + ", Max Temp: " + weather.maxTemperature.ToCelciusString();

            pressureText.text = "Pressure: " + weather.pressure + " hPa";

            cloudinessText.text = "Cloudiness: " + weather.Cloudiness + "%";

            dctText.text = "Last DCT: " + string.Format("{0:g}", weather.DataCalculationTime);  
        }
    }
}