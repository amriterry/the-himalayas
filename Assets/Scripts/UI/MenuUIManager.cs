using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheHimalayas.UI {

    public class MenuUIManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Mountain Selector UI object
        /// 
        /// </summary>
        public MountainSelectorUI mountainSelector;

        /// <summary>
        /// 
        /// Mountain Locator Button
        /// 
        /// </summary>
        public Button mountainLocatorBtn;

        /// <summary>
        /// 
        /// Mountain Locator Scene Index
        /// 
        /// </summary>
        private const int MOUNTAIN_LOCATOR_SCENE = 2;

        // Called Each frame
        void Update() {
            if(UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        // When the script enables
        void OnEnable() {
            mountainSelector.viewMountainBtn.onClick.AddListener(HideInteractables);
            mountainLocatorBtn.onClick.AddListener(LoadMountainLocatorScene);
        }

        // When the script disables
        void OnDisable() {
            mountainSelector.viewMountainBtn.onClick.RemoveListener(HideInteractables);
            mountainLocatorBtn.onClick.RemoveListener(LoadMountainLocatorScene);
        }

        /// <summary>
        /// 
        /// Hides Interactable elements from UI
        /// 
        /// </summary>
        private void HideInteractables() {
            mountainSelector.HideInteractables();
            mountainLocatorBtn.gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// Loads Mountain Locator scene
        /// 
        /// </summary>
        private void LoadMountainLocatorScene() {
            SceneManager.LoadScene(MOUNTAIN_LOCATOR_SCENE);
        }
    }
}