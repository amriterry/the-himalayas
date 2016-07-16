using TheHimalayas.Manager;
using TheHimalayas.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheHimalayas.UI {

    public class MountainARSceneUIManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Tracker Event Manager instance
        /// 
        /// </summary>
        public TrackerEventManager trackerManager;

        /// <summary>
        /// 
        /// Center panel which displays cursors.
        /// 
        /// </summary>
        public GameObject centerPanel;

        void OnEnable() {
            trackerManager.OnTrackingStateChanged += TrackingChanged;
        }

        void OnDisable() {
            trackerManager.OnTrackingStateChanged -= TrackingChanged;
        }

        void TrackingChanged(bool isTracking) {
            centerPanel.SetActive(!isTracking);
        }

        /// <summary>
        /// 
        /// Loads Mountain 3D Scene
        /// 
        /// </summary>
        public void LoadMountain3DScene() {
            SceneManager.LoadScene(AppScene.MOUNTAIN_3D_SCENE);
        }


    }
}