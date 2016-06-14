using UnityEngine;
using TheHimalayas.Store;

namespace TheHimalayas.Engine {

    public class AppEngine : MonoBehaviour {

        /// <summary>
        /// 
        /// WeatherStore Instance.
        /// 
        /// </summary>
        private WeatherStore weatherStore;

        /// <summary>
        /// 
        /// MountainStore Instance.
        /// 
        /// </summary>
        private MountainStore mountainStore;

        /// <summary>
        /// 
        /// ForecastStore Instance.
        /// 
        /// </summary>
        private ForecastStore forecastStore;

        /// <summary>
        /// 
        /// AppEngine Instance
        /// 
        /// </summary>
        private static AppEngine instance;

        /// <summary>
        /// 
        /// AppEngine Singleton property
        /// 
        /// </summary>
        public static AppEngine Instance {
            get {
                if (instance == null) {
                    instance = GameObject.FindObjectOfType<AppEngine>();
                }

                AppEngine[] controllers = GameObject.FindObjectsOfType<AppEngine>();

                if (controllers.Length > 1) {
                    foreach (AppEngine controller in controllers) {
                        if (controller != instance) {
                            Destroy(controller.gameObject);
                        }
                    }
                }

                return instance;
            }
        }

        // When the script awakens
        void Awake() {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 
        /// Returns WeatherStore Object
        /// 
        /// </summary>
        /// <returns>WeatherStore Object</returns>
        public WeatherStore GetWeatherStore() {
            if (weatherStore == null) {
                weatherStore = new WeatherStore();
            }

            return weatherStore;
        }

        /// <summary>
        /// 
        /// Retunrs the MountainStore object
        /// 
        /// </summary>
        /// <returns>MountainStore Object</returns>
        public MountainStore GetMountainStore() {
            if(mountainStore == null) {
                mountainStore = new MountainStore();
            }

            return mountainStore;
        }

        /// <summary>
        /// 
        /// Retunrs the ForecastStore object
        /// 
        /// </summary>
        /// <returns>ForecastStore Object</returns>
        public ForecastStore GetForecastStore() {
            if(forecastStore == null) {
                forecastStore = new ForecastStore();
            }

            return forecastStore;
        }
    }
}