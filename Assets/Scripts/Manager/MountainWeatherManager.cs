using TheHimalayas.Core;
using TheHimalayas.Engine;
using TheHimalayas.Factory;
using UnityEngine;

namespace TheHimalayas.Manager {

    public class MountainWeatherManager: MonoBehaviour {

        /// <summary>
        /// 
        /// Current Weather Data Manager to load current weather data.
        /// 
        /// </summary>
        public CurrentWeatherDataManager weatherManager;

        /// <summary>
        /// 
        /// Mountain for which the weather is to be found.
        /// 
        /// </summary>
        private Mountain mountain;

        // When the script enables
        void OnEnable() {
            weatherManager.AddOnWeatherLoadedListener(OnCurrentWeatherLoaded);
            weatherManager.AddOnWeatherLoadErrorListener(OnCurrentWeatherLoadError);
        }

        // When the script disables
        void OnDisable() {
            weatherManager.ForgetOnWeatherLoadedListener(OnCurrentWeatherLoaded);
            weatherManager.ForgetOnWeatherLoadErrorListener(OnCurrentWeatherLoadError);
        }

        /// <summary>
        /// 
        /// Current Mountain Weather Load Error event callback
        /// 
        /// </summary>
        /// <param name="error">Error Response Text</param>
        private void OnCurrentWeatherLoadError(string error) {
            //AppEngine.Instance.weatherUIManager.SetLoadErrorText();
        }

        /// <summary>
        /// 
        /// Current Mountain Weather Loaded Event Callback
        /// 
        /// </summary>
        /// <param name="weather">Weather Object that was parsed</param>
        private void OnCurrentWeatherLoaded(Weather weather) {
            AppEngine.Instance.GetWeatherStore().SetToStore(mountain, weather);
        }

        /// <summary>
        /// 
        /// Returns current weather information for given mountain key.
        /// 
        /// </summary>
        /// <param name="mountainKey">Key from which the mountain object is to be selected.</param>
        /// <returns>Current Weather Object.</returns>
        public void LoadMountainCurrentWeather(string mountainKey) {
            this.mountain = AppEngine.Instance.GetMountainStore().GetValue(mountainKey);

            if(mountain != null) {
                this.LoadMountainCurrentWeather(this.mountain);
            }
        }

        /// <summary>
        /// 
        /// Returns current weather information for given mountain object.
        /// 
        /// </summary>
        /// <param name="mountain">Mountain object for which the weather is to be found.</param>
        public void LoadMountainCurrentWeather(Mountain mountain) {
            this.mountain = mountain;

            weatherManager.GetCurrentWeather(mountain.coordinates);
        }
    }
}