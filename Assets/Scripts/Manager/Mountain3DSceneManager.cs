using TheHimalayas.Core;
using TheHimalayas.Engine;
using UnityEngine;

namespace TheHimalayas.Manager {

    public class Mountain3DSceneManager : MonoBehaviour {

        private MountainWeatherManager mountainWeatherManager;

        void Awake() {
            mountainWeatherManager = GetComponent<MountainWeatherManager>();
        }

        // Use this for initialization
        void Start() {
            mountainWeatherManager.LoadMountainCurrentWeather(AppEngine.Instance.GetMountainStore().GetPointedMountain());
        }

        // When the script enables
        void OnEnable() {
            AppEngine.Instance.GetWeatherStore().AddOnStoreUpdateListener(OnWeatherStoreUpdated);
        }

        // When the script disables
        void OnDisable() {
            AppEngine.Instance.GetWeatherStore().ForgetOnStoreUpdateListener(OnWeatherStoreUpdated);
        }

        /// <summary>
        /// 
        /// Callback for when the weather store is updated.
        /// 
        /// </summary>
        /// <param name="key">Mountain for which the weather is updated.</param>
        /// <param name="value">Weather value that was updated</param>
        private void OnWeatherStoreUpdated(Mountain key, Weather value) {
            // Update Weather UI
            Debug.Log("Weather Updated for " + key.name + " with " + value.ToString());
        }
    }
}