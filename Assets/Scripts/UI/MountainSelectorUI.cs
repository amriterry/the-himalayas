using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TheHimalayas.UI {

    public class MountainSelectorUI : MonoBehaviour {

        /// <summary>
        /// 
        /// Mountain Text
        /// 
        /// </summary>
        public Text mountainText;

        /// <summary>
        /// 
        /// Previous Mountain Button
        /// 
        /// </summary>
        public Button previousMountainBtn;

        /// <summary>
        /// 
        /// Next Mountain Button
        /// 
        /// </summary>
        public Button nextMountainBtn;

        /// <summary>
        /// 
        /// View Mountain Button
        /// 
        /// </summary>
        public Button viewMountainBtn;

        // When the script enables
        void OnEnable() {
            viewMountainBtn.onClick.AddListener(LoadMountain3DScene);
        }

        // When the script disables
        void OnDisable() {
            viewMountainBtn.onClick.RemoveListener(LoadMountain3DScene);
        }

        /// <summary>
        /// 
        /// Loads Mountain 3D Scene
        /// 
        /// </summary>
        private void LoadMountain3DScene() {
            HideInteractables();
            UpdateMountainText("Pushing Lands...");

            SceneManager.LoadSceneAsync("Mountain3DScene");
        }

        /// <summary>
        /// 
        /// Updates the Mountain Text
        /// 
        /// </summary>
        /// <param name="text">Text to be updated</param>
        public void UpdateMountainText(string text) {
            mountainText.text = text;
        }

        /// <summary>
        /// 
        /// Hides Interactable Buttons on the UI
        /// 
        /// </summary>
        public void HideInteractables() {
            previousMountainBtn.gameObject.SetActive(false);
            nextMountainBtn.gameObject.SetActive(false);
            viewMountainBtn.gameObject.SetActive(false);
        }
    }
}