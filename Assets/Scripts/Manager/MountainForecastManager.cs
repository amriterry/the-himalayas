using TheHimalayas.Core;
using TheHimalayas.Engine;
using UnityEngine;

namespace TheHimalayas.Manager {

    public class MountainForecastManager : MonoBehaviour {
        /// <summary>
        /// 
        /// Forecast Data Manager to load  forecast data.
        /// 
        /// </summary>
        public ForecastDataManager forecastManager;

        /// <summary>
        /// 
        /// Mountain for which the forecast is to be found.
        /// 
        /// </summary>
        private Mountain mountain;

        // When the script enables
        void OnEnable() {
            forecastManager.AddOnForecastLoadedListener(OnForecastLoaded);
            forecastManager.AddOnForecastLoadErrorListener(OnForecastLoadError);
        }

        // When the script disables
        void OnDisable() {
            forecastManager.ForgetOnForecastLoadedListener(OnForecastLoaded);
            forecastManager.ForgetOnForecastLoadErrorListener(OnForecastLoadError);
        }

        /// <summary>
        /// 
        ///  Mountain Forecast Load Error event callback
        /// 
        /// </summary>
        /// <param name="error">Error Response Text</param>
        private void OnForecastLoadError(string error) {
            //AppEngine.Instance.forecastUIManager.SetLoadErrorText();
        }

        /// <summary>
        /// 
        ///  Mountain Forecast Loaded Event Callback
        /// 
        /// </summary>
        /// <param name="forecast">Forecast Object that was parsed</param>
        private void OnForecastLoaded(Forecast forecast) {
            AppEngine.Instance.GetForecastStore().SetToStore(mountain, forecast);
        }

        /// <summary>
        /// 
        /// Returns  forecast information for given mountain key.
        /// 
        /// </summary>
        /// <param name="mountainKey">Key from which the mountain object is to be selected.</param>
        /// <returns> Forecast Object.</returns>
        public void LoadMountainForecast(string mountainKey) {
            this.mountain = AppEngine.Instance.GetMountainStore().GetValue(mountainKey);

            if (mountain != null) {
                this.LoadMountainForecast(this.mountain);
            }
        }

        /// <summary>
        /// 
        /// Returns  forecast information for given mountain object.
        /// 
        /// </summary>
        /// <param name="mountain">Mountain object for which the forecast is to be found.</param>
        public void LoadMountainForecast(Mountain mountain) {
            this.mountain = mountain;

            forecastManager.GetForecast(mountain.coordinates);
        }
    }
}
