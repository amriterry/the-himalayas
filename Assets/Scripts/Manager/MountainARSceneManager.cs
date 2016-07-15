using UnityEngine;
using TerrainFactory;
using Vuforia;
using System;

namespace TheHimalayas.Manager {

    public class MountainARSceneManager : MonoBehaviour, ITrackableEventHandler {

        /// <summary>
        /// 
        /// Trackable Behaviour instance
        /// 
        /// </summary>
        private TrackableBehaviour trackableBehaviour;

        // Use this for initialization
        void Start () {
            HeightMapTerrain mountain = GameObject.FindObjectOfType<HeightMapTerrain>();

            if( mountain == null) {
                Debug.LogError("No HeightMapTerrain to load");
            } else {
                mountain.gameObject.transform.SetParent(transform);
                mountain.gameObject.transform.localScale = new Vector3(1 / 2032f, 1 / 2032f, 1 / 2032f);
                mountain.gameObject.transform.localPosition = new Vector3(- 1.25f, 0 ,- 1.25f);
            }

            trackableBehaviour = GetComponent<TrackableBehaviour>();

            if(trackableBehaviour) {
                trackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
                OnTrackingFound();
            } else {
                OnTrackingLost();
            }
        }

        private void OnTrackingFound() {
            foreach(Transform pointer in gameObject.transform.GetChild(0)) {
                pointer.gameObject.SetActive(true);
            }
        }

        private void OnTrackingLost() {
            foreach(Transform pointer in gameObject.transform.GetChild(0)) {
                pointer.gameObject.SetActive(false);
            }
        }
    }
}