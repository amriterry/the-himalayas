using UnityEngine;
using Vuforia;

namespace TheHimalayas.Manager {

    [RequireComponent(typeof(TrackableBehaviour))]
    public class TrackerEventManager : MonoBehaviour, ITrackableEventHandler {

        /// <summary>
        /// 
        /// Delegate to handle trackable state changes
        /// 
        /// </summary>
        /// <param name="isTracking">Is Tracking Flag</param>
        public delegate void TrackableStateChanged(bool isTracking);

        /// <summary>
        /// 
        /// Event for TrackableStateChanged
        /// 
        /// </summary>
        public event TrackableStateChanged OnTrackingStateChanged;

        /// <summary>
        /// 
        /// Trackable Behaviour instance
        /// 
        /// </summary>
        private TrackableBehaviour trackableBehaviour;

        // Use this for initialization
        void Start() {
            trackableBehaviour = GetComponent<TrackableBehaviour>();

            if (trackableBehaviour) {
                trackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        /// <summary>
        /// 
        /// Trackable State Changed Event Handler
        /// 
        /// </summary>
        /// <param name="previousStatus"></param>
        /// <param name="newStatus"></param>
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
                if(OnTrackingStateChanged != null) {
                    OnTrackingStateChanged(true);
                }
            } else {
                if (OnTrackingStateChanged != null) {
                    OnTrackingStateChanged(false);
                }
            }
        }
    }
}