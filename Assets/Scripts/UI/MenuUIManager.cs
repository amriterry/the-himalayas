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

        // Called Each frame
        void Update() {
            if(UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        // When the script enables
        void OnEnable() {
            mountainSelector.viewMountainBtn.onClick.AddListener(HideInteractables);
        }

        // When the script disables
        void OnDisable() {
            mountainSelector.viewMountainBtn.onClick.RemoveListener(HideInteractables);
        }

        /// <summary>
        /// 
        /// Hides Interactable elements from UI
        /// 
        /// </summary>
        private void HideInteractables() {
            mountainSelector.HideInteractables();
        }
    }
}