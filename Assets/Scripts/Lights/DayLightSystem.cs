using System;
using UnityEngine;

namespace TheHimalayas.Lights {

    [RequireComponent(typeof(Light))]
    public class DayLightSystem : MonoBehaviour {

        /// <summary>
        /// 
        /// Minutes in an hour
        /// 
        /// </summary>
        private const int HOUR = 60;

        /// <summary>
        /// 
        /// Minutes in a day
        /// 
        /// </summary>
        private const int DAY = 24 * HOUR;

        /// <summary>
        /// 
        /// Rotation per minute
        /// 
        /// </summary>
        private const float ROTATION_PER_MINUTE = 360f / DAY;

        /// <summary>
        /// 
        /// Sun rising hour
        /// 
        /// </summary>
        private const int SUN_RISE_HOUR = 6;

        /// <summary>
        /// 
        /// Lens flare of the light
        /// 
        /// </summary>
        private LensFlare flare;

        // When the script first awakes
        void Awake() {
            flare = GetComponent<LensFlare>();
        }

        // When the script initializes
        void Start() {
            UpdateDayLightSystem(Utils.DateTime.GetCurrentDateTimeAtKathmandu());
        }

        /// <summary>
        /// 
        /// Updates light's rotation to change the direction of light source
        /// 
        /// </summary>
        /// <param name="dateTime">Time from which the rotation is to be calculated</param>
        public void UpdateDayLightSystem(DateTime dateTime) {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);

            int minutes = (dateTime.Hour - SUN_RISE_HOUR) * HOUR + dateTime.Minute;

            float currentRotation = minutes * ROTATION_PER_MINUTE;

            transform.RotateAround(Vector3.zero, transform.right, currentRotation);

            UpdateFlareBrightness();
        }

        /// <summary>
        /// 
        /// Updates flare brightness based upon the time.
        /// 
        /// </summary>
        private void UpdateFlareBrightness() {
            float rotationAngle = transform.rotation.eulerAngles.magnitude;

            if (rotationAngle <= 0f || rotationAngle >= 270f) {
                flare.brightness = 0f;
            } else if (rotationAngle <= 30f || rotationAngle >= 150f) {
                flare.brightness = 0.7f;
            } else {
                flare.brightness = 1f;
            }
        }
    }
}