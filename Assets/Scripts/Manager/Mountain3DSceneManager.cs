using UnityEngine;
using TheHimalayas.UI;
using TheHimalayas.Core;
using TheHimalayas.Utils;
using TheHimalayas.Engine;
using UnityEngine.SceneManagement;
using TheHimalayas.SceneUtils;

namespace TheHimalayas.Manager {

    public class Mountain3DSceneManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Time of refresh data.
        /// 
        /// </summary>
        public float dataRefreshTimeMin;

        /// <summary>
        /// 
        /// View Mode selector instance.
        /// 
        /// </summary>
        public ViewModeSelector modeSelector;

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
        /// Mountain 3D Scene UI Manager.
        /// 
        /// </summary>
        public Mountain3DSceneUIManager sceneUIManager;

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

        /// <summary>
        /// 
        /// Flag to determine if the first data is loaded
        /// 
        /// </summary>
        private bool isFirstDataLoaded = false;

        /// <summary>
        /// 
        /// Flag to determine if the data is loading
        /// 
        /// </summary>
        private bool isDataLoading = false;

        // When the script enables
        void OnEnable() {
            AppEngine.Instance.GetWeatherStore().AddOnStoreUpdateListener(OnWeatherStoreUpdated);
            AppEngine.Instance.GetForecastStore().AddOnStoreUpdateListener(OnForecastStoreUpdated);
        }

        // When the script first awakens
        void Awake() {
            mountainWeatherManager = GetComponent<MountainWeatherManager>();
            mountainForecastManager = GetComponent<MountainForecastManager>();
        }

        // Called each frame
        void Update() {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
                if(modeSelector.IsInVRMode) {
                    modeSelector.ChangeTo3DMode();
                } else {
                    SceneManager.LoadScene(AppScene.MENU_SCENE);
                }
            }
        }

        // updates each physics tick
        void FixedUpdate() {
            if (Application.internetReachability == NetworkReachability.NotReachable) {
                sceneUIManager.ShowNetworkErrorPanel();

                if(!isFirstDataLoaded) {
                    isDataLoading = false;
                }
            } else {
                sceneUIManager.HideNetworkPanel();

                if( ! isFirstDataLoaded && ! isDataLoading) {
                    LoadMountainWeather();
                }
            }
        }

        /// <summary>
        /// 
        /// Loads Mountain Weather
        /// 
        /// </summary>
        private void LoadMountainWeather() {
            if( ! isDataLoading) {
                isDataLoading = true;

                Mountain pointedMountain = AppEngine.Instance.GetMountainStore().GetPointedMountain();

                weatherUIManager.UpdateMountainTexts(pointedMountain);
                weatherUIManager.SetWeatherLoadingText();

                mountainWeatherManager.LoadMountainCurrentWeather(pointedMountain);
            }
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

            isFirstDataLoaded = true;
            isDataLoading = false;

            Invoke("LoadMountainWeather", dataRefreshTimeMin * 60f);
        }
    }
}