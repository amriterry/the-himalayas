using UnityEngine;
using TerrainFactory;
using TheHimalayas.Utils;
using UnityEngine.SceneManagement;

namespace TheHimalayas.Manager {

    public class MountainARSceneManager : MonoBehaviour {

        /// <summary>
        /// 
        /// TrackerEventManager instance
        /// 
        /// </summary>
        public TrackerEventManager trackerManager;

        /// <summary>
        /// 
        /// Place Pointers in the scene
        /// 
        /// </summary>
        private GameObject[] placePointers;

        // Use this for initialization
        void Start () {
            HeightMapTerrain mountain = FindObjectOfType<HeightMapTerrain>();

            if( mountain == null) {
                Debug.LogError("No HeightMapTerrain to load");
            } else {
                mountain.gameObject.transform.SetParent(trackerManager.transform);
                mountain.gameObject.transform.localScale = new Vector3(1 / 2032f, 1 / 2032f, 1 / 2032f);
                mountain.gameObject.transform.localPosition = new Vector3(- 1.25f, 0 ,- 1.25f);
            }

            trackerManager.OnTrackingStateChanged += TrackingStateChanged;
        }

        // Called each frame
        void Update() {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene(AppScene.MOUNTAIN_3D_SCENE);
            }
        }

        // Tracking State Changed Event Handler
        void TrackingStateChanged(bool isTracking) {
            if(placePointers == null) {
                placePointers = GameObject.FindGameObjectsWithTag("PlacePointer");
            }

            if(isTracking) {
                foreach(var pointer in placePointers) {
                    pointer.SetActive(true);
                }
            } else {
                foreach (var pointer in placePointers) {
                    pointer.SetActive(false);
                }
            }
        }
    }
}