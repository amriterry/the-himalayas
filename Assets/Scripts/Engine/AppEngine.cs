using UnityEngine;
using TheHimalayas.Store;

namespace TheHimalayas.Engine {

    public class AppEngine : MonoBehaviour {

        /// <summary>
        /// 
        /// WeatherStore Instance.
        /// 
        /// </summary>
        public WeatherStore weatherStore;

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
    }
}