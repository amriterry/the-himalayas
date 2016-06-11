using UnityEngine;
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
            mountainLocatorBtn.gameObject.SetActive(false);
        }
    }
}