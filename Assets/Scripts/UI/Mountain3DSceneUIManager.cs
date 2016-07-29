using TheHimalayas.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheHimalayas.UI {

    public class Mountain3DSceneUIManager : MonoBehaviour {

        /// <summary>
        /// 
        /// View Mode Selector Panel
        /// 
        /// </summary>
        public GameObject viewModeSelectorPanel;

        /// <summary>
        /// 
        /// Mountain Selector Panel Container
        /// 
        /// </summary>
        public GameObject mountainSelectorPanelContainer;

        /// <summary>
        /// 
        /// Detail Weather panel
        /// 
        /// </summary>
        public GameObject detailWeatherPanel;

        /// <summary>
        /// 
        /// Mountain Forecast Panel
        /// 
        /// </summary>
        public GameObject forecastPanel;

        /// <summary>
        /// 
        /// Network status text
        /// 
        /// </summary>
        public Text networkStatusText;

        /// <summary>
        /// 
        /// Network error panel
        /// 
        /// </summary>
        public GameObject networkErrorPanel;

        /// <summary>
        /// 
        /// Mountain Weather UI Manager
        /// 
        /// </summary>
        private MountainWeatherUIManager weatherUIManager;

        // When the script first awakens
        void Awake() {
            weatherUIManager = GetComponent<MountainWeatherUIManager>();
        }

        /// <summary>
        /// 
        /// Toggles View Mode Selector Panel
        /// 
        /// </summary>
        public void ToggleViewModeSelector() {
            viewModeSelectorPanel.SetActive(!viewModeSelectorPanel.activeInHierarchy);
        }

        /// <summary>
        /// 
        /// Toggles Mountain Selector Panel
        /// 
        /// </summary>
        public void ToggleMountainSelector() {
            mountainSelectorPanelContainer.SetActive(!mountainSelectorPanelContainer.activeInHierarchy);
        }

        /// <summary>
        /// 
        /// Updates Network Error Text
        /// 
        /// </summary>
        public void SetNetworkErrorText() {
            networkStatusText.text = "Ya'sure ur connected?";
        }

        /// <summary>
        /// 
        /// Shows Network Error Panel
        /// 
        /// </summary>
        public void ShowNetworkErrorPanel() {
            networkErrorPanel.SetActive(true);
        }

        /// <summary>
        /// 
        /// Hides network panel
        /// 
        /// </summary>
        public void HideNetworkPanel() {
            networkErrorPanel.SetActive(false);
        }

        /// <summary>
        /// 
        /// Loads Menu Scene
        /// 
        /// </summary>
        public void GoToMenuScene() {
            AppSceneManager.Instance.LoadMenuScene();
        }

        /// <summary>
        /// 
        /// Opens Detail Weather Panel
        /// 
        /// </summary>
        public void OpenDetailWeatherPanel() {
            detailWeatherPanel.SetActive(true);
        }

        /// <summary>
        /// 
        /// Closes Detail Weather Panel
        /// 
        /// </summary>
        public void CloseDetailWeatherPanel() {
            detailWeatherPanel.SetActive(false);
        }

        /// <summary>
        /// 
        /// Opens Forecast panel
        /// 
        /// </summary>
        public void OpenForecastPanel() {
            forecastPanel.SetActive(true);
        }

        /// <summary>
        /// 
        /// Closes Forecast panel
        /// 
        /// </summary>
        public void CloseForecastPanel() {
            forecastPanel.SetActive(false);
        }
    }
}