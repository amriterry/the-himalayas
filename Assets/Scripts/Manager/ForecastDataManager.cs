using UnityEngine;
using TheHimalayas.Http;
using TheHimalayas.Core;
using TheHimalayas.Parsers;

namespace TheHimalayas.Manager {

    public class ForecastDataManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Forecast Http Client to get Forecast Forecast information.
        /// 
        /// </summary>
        public ForecastHttpClient forecastClient;

        /// <summary>
        /// 
        /// Current Forecast Data Parser to parse current Forecast JSON data.
        /// 
        /// </summary>
        private ForecastDataParser forecastParser;

        /// <summary>
        /// 
        /// Forecast Loaded Event Delegate
        /// 
        /// </summary>
        /// <param name="Forecast">Forecast that was loaded</param>
        public delegate void ForecastLoaded(Forecast forecast);

        /// <summary>
        /// 
        /// Forecast Load error delegate
        /// 
        /// </summary>
        /// <param name="error">Error String From Server</param>
        public delegate void ForecastLoadError(string error);

        /// <summary>
        /// 
        /// Forecast Loaded Event
        /// 
        /// </summary>
        public event ForecastLoaded OnForecastLoaded;

        /// <summary>
        /// 
        /// Forecast Load Error Event
        /// 
        /// </summary>
        public event ForecastLoadError OnForecastLoadError;

        // Called when first the script awakes.
        void Awake() {
            forecastParser = new ForecastDataParser();
        }

        /// <summary>
        /// 
        /// Adds Listeners when script is enabled.
        /// 
        /// </summary>
        void OnEnable() {
            forecastClient.AddSuccessResponseListener(OnForecastDataSuccess);
            forecastClient.AddErrorResponseListener(OnForecastDataError);
        }

        /// <summary>
        /// 
        /// Removes Listeners when script is disabled.
        /// 
        /// </summary>
        void OnDisable() {
            forecastClient.ForgetSuccessResponseListener(OnForecastDataSuccess);
            forecastClient.ForgetErrorResponseListener(OnForecastDataError);
        }

        /// <summary>
        /// 
        /// Fetches current Forecast from Server and Updates the UI.
        /// 
        /// </summary>
        /// <returns>Current Forecast object.</returns>
        public void GetForecast(Location location) {
            forecastClient.SetLocation(location.Latitude, location.Longitude)
                         .GetData();
        }

        /// <summary>
        /// 
        /// Callback when Forecast data is pulled successfully.
        /// 
        /// </summary>
        /// <param name="response">Response text from the server</param>
        private void OnForecastDataSuccess(string response) {
            Forecast forecast = forecastParser.Parse(response);

            if (OnForecastLoaded != null) {
                OnForecastLoaded(forecast);
            }
        }

        /// <summary>
        /// 
        /// Callback when error occured during pulling Forecast data.
        /// 
        /// </summary>
        /// <param name="response">Response text from the server</param>
        private void OnForecastDataError(string error) {
            if (OnForecastLoadError != null) {
                OnForecastLoadError(error);
            }
        }

        /// <summary>
        /// 
        /// Adds ForecastLoaded Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to add</param>
        public ForecastDataManager AddOnForecastLoadedListener(ForecastLoaded listener) {
            this.OnForecastLoaded += listener;

            return this;
        }

        /// <summary>
        /// 
        /// Adds ForecastLoadError Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to add</param>
        public ForecastDataManager AddOnForecastLoadErrorListener(ForecastLoadError listener) {
            this.OnForecastLoadError += listener;

            return this;
        }

        /// <summary>
        /// 
        /// Removes ForecastLoaded Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to remove</param>
        public void ForgetOnForecastLoadedListener(ForecastLoaded listener) {
            this.OnForecastLoaded -= listener;
        }

        /// <summary>
        /// 
        /// Removes ForecastLoadError Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to remove</param>
        public void ForgetOnForecastLoadErrorListener(ForecastLoadError listener) {
            this.OnForecastLoadError -= listener;
        }
    }
}