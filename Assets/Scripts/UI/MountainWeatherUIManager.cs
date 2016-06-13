using TheHimalayas.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.UI {

    public class MountainWeatherUIManager : MonoBehaviour {

        public Text[] mountainTexts;

        public Text weatherStatusText;

        public Text locationText;

        public Text weatherText;

        public Text coordinatesText;

        public Text temperatureText;

        public Text minMaxTempText;

        public Text pressureText;

        public Text cloudinessText;

        public Text dctText;

        public GameObject detailWeatherPanel;


        public void OpenDetailWeatherPanel() {
            detailWeatherPanel.SetActive(true);
        }

        public void CloseDetailWeatherPanel() {
            detailWeatherPanel.SetActive(false);
        }

        public void UpdateMountainTexts(Mountain mountain) {
            foreach(Text t in mountainTexts) {
                t.text = mountain.name;
            }
        }

        public void UpdateMountainWeather(Weather weather) {
            weatherStatusText.text = "weather: at " + weather.temperature.ToCelciusString() + " in '" + weather.cityName + "'";

            locationText.text = "City: " +weather.cityName;

            weatherText.text = "weather";

            coordinatesText.text = "Coordinates: " +weather.location.ToString();

            temperatureText.text = "Temperature: " + weather.temperature.ToCelciusString();

            minMaxTempText.text = "Min Temp: " + weather.minTemperature.ToCelciusString() + ", Max Temp: " + weather.maxTemperature.ToCelciusString();

            pressureText.text = "Pressure: " + weather.pressure + "hPa";

            cloudinessText.text = "Cloudiness: " + weather.Cloudiness + "%";

            dctText.text = "Last DCT: " + weather.DataCalculationTime.ToShortDateString();  
        }
    }
}