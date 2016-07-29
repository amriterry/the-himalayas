using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TheHimalayas.Engine;
using TheHimalayas.Store;
using TheHimalayas.Manager;

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

        /// <summary>
        /// 
        /// Mountain Store object.
        /// 
        /// </summary>
        private MountainStore store;

        // Use this to initailize
        void Start() {
            store = AppEngine.Instance.GetMountainStore();

            UpdateCurrentMountainText();
        }

        // When the script enables
        void OnEnable() {
            viewMountainBtn.onClick.AddListener(LoadMountain3DScene);
            nextMountainBtn.onClick.AddListener(GetNextMountain);
            previousMountainBtn.onClick.AddListener(GetPreviousMountain);
        }

        // When the script disables
        void OnDisable() {
            viewMountainBtn.onClick.RemoveListener(LoadMountain3DScene);
            nextMountainBtn.onClick.RemoveListener(GetNextMountain);
            previousMountainBtn.onClick.RemoveListener(GetPreviousMountain);
        }

        /// <summary>
        /// 
        /// Moves the pointer to next element and updates the UI.
        /// 
        /// </summary>
        private void GetNextMountain() {
            store.MovePointerToNext();

            UpdateCurrentMountainText();
        }

        /// <summary>
        /// 
        /// Moves the pointer to previous element and updates the UI.
        /// 
        /// </summary>
        private void GetPreviousMountain() {
            store.MovePointerToPrevious();

            UpdateCurrentMountainText();
        }

        /// <summary>
        /// 
        /// Updates Mountain text with current mountain's name
        /// 
        /// </summary>
        private void UpdateCurrentMountainText() {
            UpdateMountainText(store.GetPointedMountain().name);
        }

        /// <summary>
        /// 
        /// Loads Mountain 3D Scene
        /// 
        /// </summary>
        private void LoadMountain3DScene() {
            AppSceneManager.Instance.LoadMountainScene();
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