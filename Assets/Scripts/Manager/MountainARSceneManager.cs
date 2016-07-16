using UnityEngine;
using TerrainFactory;

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
                mountain.gameObject.transform.SetParent(transform);
                mountain.gameObject.transform.localScale = new Vector3(1 / 2032f, 1 / 2032f, 1 / 2032f);
                mountain.gameObject.transform.localPosition = new Vector3(- 1.25f, 0 ,- 1.25f);
            }

            placePointers = GameObject.FindGameObjectsWithTag("PlacePointer");
        }

        // When the script enables
        void OnStart() {
            trackerManager.OnTrackingStateChanged += TrackingStateChanged;
        }

        // Tracking State Changed Event Handler
        void TrackingStateChanged(bool isTracking) {
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