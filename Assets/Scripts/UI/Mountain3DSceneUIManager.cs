using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TheHimalayas.UI {

    public class Mountain3DSceneUIManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Mountain Selector Panel Container
        /// 
        /// </summary>
        public GameObject mountainSelectorPanelContainer;

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
        /// Loads Menu Scene
        /// 
        /// </summary>
        public void GoToMenuScene() {
            SceneManager.LoadScene("MenuScene");
        }
    }
}