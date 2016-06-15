using TheHimalayas.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.UI {

    public class MountainForecastUIManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Loading Text
        /// 
        /// </summary>
        public Text loadingText;

        /// <summary>
        /// 
        /// Forecast UI Panels
        /// 
        /// </summary>
        public ForecastUI[] forecastPanels;

        // When the script starts
        void Start() {
            ResetForecastUI();
        }

        /// <summary>
        /// 
        /// Sets the loading text
        /// 
        /// </summary>
        public void SetLoadingText() {
            loadingText.text = "Fetching Forecast...";
        }

        /// <summary>
        /// 
        /// Removes the loading text
        /// 
        /// </summary>
        public void RemoveLoadingText() {
            loadingText.text = "";
        }

        /// <summary>
        /// 
        /// Resets Forecast UI
        /// 
        /// </summary>
        public void ResetForecastUI() {
            SetLoadingText();

            foreach(ForecastUI ui in forecastPanels) {
                ui.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 
        /// Updates Forecast UI with the forecast
        /// 
        /// </summary>
        /// <param name="forecast">Forecast object</param>
        public void UpdateForecastUI(Forecast forecast) {
            RemoveLoadingText();

            var weathers = forecast.GetWeatherList();

            for (int i = 0;i < weathers.Count;i++) {
                forecastPanels[i].gameObject.SetActive(true);

                forecastPanels[i].UpdateWeatherMeta(forecast.cityName, forecast.location, weathers[i]);
            }
        }
    }
}