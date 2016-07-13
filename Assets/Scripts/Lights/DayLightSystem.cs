using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.Lights {

    [RequireComponent(typeof(Light))]
    public class DayLightSystem : MonoBehaviour {

        private const int HOUR = 60;
        private const int DAY = 24 * HOUR;
        private const float ROTATION_PER_MINUTE = 360f / DAY;

        private const int SUN_RISE_HOUR = 6;

        void Start() {
            UpdateDayLightSystem(Utils.DateTime.GetCurrentDateTimeAtKathmandu());
        }

        public void UpdateDayLightSystem(DateTime dateTime) {
            transform.rotation = Quaternion.identity;

            int minutes = (dateTime.Hour - SUN_RISE_HOUR) * HOUR + dateTime.Minute;

            float currentRotation = minutes * ROTATION_PER_MINUTE;

            transform.RotateAround(Vector3.zero, transform.right, currentRotation);
        }
    }
}