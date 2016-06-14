using UnityEngine;
using TheHimalayas.Http;
using TheHimalayas.Core;
using TheHimalayas.Parsers;

namespace TheHimalayas.Manager {

    public class CurrentWeatherDataManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Current Weather Http Client to get current weather information.
        /// 
        /// </summary>
        public CurrentWeatherHttpClient weatherClient;

        /// <summary>
        /// 
        /// Current Weather Data Parser to parse current weather JSON data.
        /// 
        /// </summary>
        private CurrentWeatherDataParser weatherParser;

        /// <summary>
        /// 
        /// Weather Loaded Event Delegate
        /// 
        /// </summary>
        /// <param name="weather">Weather that was loaded</param>
        public delegate void WeatherLoaded(Weather weather);

        /// <summary>
        /// 
        /// Weather Load error delegate
        /// 
        /// </summary>
        /// <param name="error">Error String From Server</param>
        public delegate void WeatherLoadError(string error);

        /// <summary>
        /// 
        /// Weather Loaded Event
        /// 
        /// </summary>
        public event WeatherLoaded OnWeatherLoaded;

        /// <summary>
        /// 
        /// Weather Load Error Event
        /// 
        /// </summary>
        public event WeatherLoadError OnWeatherLoadError;

        // Called when first the script awakes.
        void Awake() {
            weatherParser = new CurrentWeatherDataParser();
        }

        /// <summary>
        /// 
        /// Adds Listeners when script is enabled.
        /// 
        /// </summary>
        void OnEnable() {
            weatherClient.AddSuccessResponseListener(OnWeatherDataSuccess);
            weatherClient.AddErrorResponseListener(OnWeatherDataError);
        }

        /// <summary>
        /// 
        /// Removes Listeners when script is disabled.
        /// 
        /// </summary>
        void OnDisable() {
            weatherClient.ForgetSuccessResponseListener(OnWeatherDataSuccess);
            weatherClient.ForgetErrorResponseListener(OnWeatherDataError);
        }

        /// <summary>
        /// 
        /// Fetches current weather from Server and Updates the UI.
        /// 
        /// </summary>
        /// <returns>Current weather object.</returns>
        public void GetCurrentWeather(Location location) {
            weatherClient.SetLocation(location.Latitude, location.Longitude)
                         .GetData();
        }

        /// <summary>
        /// 
        /// Callback when weather data is pulled successfully.
        /// 
        /// </summary>
        /// <param name="response">Response text from the server</param>
        private void OnWeatherDataSuccess(string response) {
            Weather weather = weatherParser.Parse(response);

            if(OnWeatherLoaded != null) {
                OnWeatherLoaded(weather);
            }
        }

        /// <summary>
        /// 
        /// Callback when error occured during pulling weather data.
        /// 
        /// </summary>
        /// <param name="response">Response text from the server</param>
        private void OnWeatherDataError(string error) {
            if (OnWeatherLoadError != null) {
                OnWeatherLoadError(error);
            }
        }

        /// <summary>
        /// 
        /// Adds WeatherLoaded Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to add</param>
        public CurrentWeatherDataManager AddOnWeatherLoadedListener(WeatherLoaded listener) {
            this.OnWeatherLoaded += listener;

            return this;
        }

        /// <summary>
        /// 
        /// Adds WeatherLoadError Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to add</param>
        public CurrentWeatherDataManager AddOnWeatherLoadErrorListener(WeatherLoadError listener) {
            this.OnWeatherLoadError += listener;

            return this;
        }

        /// <summary>
        /// 
        /// Removes WeatherLoaded Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to remove</param>
        public void ForgetOnWeatherLoadedListener(WeatherLoaded listener) {
            this.OnWeatherLoaded -= listener;
        }

        /// <summary>
        /// 
        /// Removes WeatherLoadError Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to remove</param>
        public void ForgetOnWeatherLoadErrorListener(WeatherLoadError listener) {
            this.OnWeatherLoadError -= listener;
        }
    }
}