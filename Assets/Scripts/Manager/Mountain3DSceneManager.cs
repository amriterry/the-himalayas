using TheHimalayas.Core;
using TheHimalayas.Engine;
using TheHimalayas.UI;
using UnityEngine;

namespace TheHimalayas.Manager {

    public class Mountain3DSceneManager : MonoBehaviour {

        public MountainWeatherUIManager uiManager;

        /// <summary>
        /// 
        /// Mountain Weather Manager Object
        /// 
        /// </summary>
        private MountainWeatherManager mountainWeatherManager;

        // When the script first awakens
        void Awake() {
            mountainWeatherManager = GetComponent<MountainWeatherManager>();
        }

        // Use this for initialization
        void Start() {
            Mountain pointedMountain = AppEngine.Instance.GetMountainStore().GetPointedMountain();

            uiManager.UpdateMountainTexts(pointedMountain);
            mountainWeatherManager.LoadMountainCurrentWeather(pointedMountain);
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
            uiManager.UpdateMountainWeather(value);
        }
    }
}