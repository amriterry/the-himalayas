using System;
using TheHimalayas.Core;
using TheHimalayas.Engine;
using TheHimalayas.UI;
using UnityEngine;

namespace TheHimalayas.Manager {

    public class Mountain3DSceneManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Mountain Weather UI Manager
        /// 
        /// </summary>
        public MountainWeatherUIManager weatherUIManager;

        /// <summary>
        /// 
        /// Mountain Forecast UI Manager
        /// 
        /// </summary>
        public MountainForecastUIManager forecastUIManager;

        /// <summary>
        /// 
        /// Mountain Weather Manager Object
        /// 
        /// </summary>
        private MountainWeatherManager mountainWeatherManager;

        /// <summary>
        /// 
        /// Mountain Forecast manager object.
        /// 
        /// </summary>
        private MountainForecastManager mountainForecastManager;

        // When the script first awakens
        void Awake() {
            mountainWeatherManager = GetComponent<MountainWeatherManager>();
            mountainForecastManager = GetComponent<MountainForecastManager>();
        }

        // Use this for initialization
        void Start() {
            Mountain pointedMountain = AppEngine.Instance.GetMountainStore().GetPointedMountain();

            weatherUIManager.UpdateMountainTexts(pointedMountain);
            weatherUIManager.SetWeatherLoadingText();

            mountainWeatherManager.LoadMountainCurrentWeather(pointedMountain);
        }

        // When the script enables
        void OnEnable() {
            AppEngine.Instance.GetWeatherStore().AddOnStoreUpdateListener(OnWeatherStoreUpdated);
            AppEngine.Instance.GetForecastStore().AddOnStoreUpdateListener(OnForecastStoreUpdated);
        }

        // When the script disables
        void OnDisable() {
            AppEngine.Instance.GetWeatherStore().ForgetOnStoreUpdateListener(OnWeatherStoreUpdated);
            AppEngine.Instance.GetForecastStore().ForgetOnStoreUpdateListener(OnForecastStoreUpdated);
        }

        /// <summary>
        /// 
        /// Callback for when the weather store is updated.
        /// 
        /// </summary>
        /// <param name="key">Mountain for which the weather is updated.</param>
        /// <param name="value">Weather value that was updated</param>
        private void OnWeatherStoreUpdated(Mountain key, Weather value) {
            weatherUIManager.UpdateMountainWeather(value);

            mountainForecastManager.LoadMountainForecast(key);
        }

        /// <summary>
        /// 
        /// Callback for when the forecast store is updated
        /// 
        /// </summary>
        /// <param name="key">Mountain for which the forecasat was updated</param>
        /// <param name="value">Forecast value that was updated</param>
        private void OnForecastStoreUpdated(Mountain key, Forecast value) {
            forecastUIManager.UpdateForecastUI(value);
        }
    }
}