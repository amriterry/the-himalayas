using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheHimalayas.Input {

    public class OneFingerRotationGestureInput : MonoBehaviour, IDragHandler {

        /// <summary>
        /// 
        /// Delegate for when the value of the rotation is changed
        /// 
        /// </summary>
        /// <param name="deltaChange">Changed value</param>
        public delegate void ValueChanged(float deltaChange);

        /// <summary>
        /// 
        /// Event when the rotation is detected
        /// 
        /// </summary>
        public event ValueChanged OnRotationDetected;

        // OnDrag Handler
        public void OnDrag(PointerEventData eventData) {
            if(OnRotationDetected != null) {
                OnRotationDetected(eventData.delta.x);
            }
        }
    }
}