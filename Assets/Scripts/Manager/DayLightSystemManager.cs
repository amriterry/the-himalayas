using System;
using UnityEngine;
using UnityEngine.UI;
using TheHimalayas.Lights;

namespace TheHimalayas.Manager {

    public class DayLightSystemManager : MonoBehaviour {

        /// <summary>
        /// 
        /// DayLightSystem instance
        /// 
        /// </summary>
        public DayLightSystem lightSystem;

        /// <summary>
        /// 
        /// DayLight System Slider
        /// 
        /// </summary>
        public Slider lightSystemSlider;

        /// <summary>
        /// 
        /// Time Marker Text
        /// 
        /// </summary>
        private Text timeMarkerText;

        // When the script first enables
        void OnEnable() {
            lightSystemSlider.onValueChanged.AddListener(SliderUpdated);
        }

        // When the script disables
        void OnDisable() {
            lightSystemSlider.onValueChanged.RemoveListener(SliderUpdated);
        }

        // When the script first initializes
        void Start() {
            timeMarkerText = lightSystemSlider.transform.GetComponentInChildren<Text>();

            UpdateDayLightSystem();
        }

        /// <summary>
        /// 
        /// Updates day light system based upon current date time
        /// 
        /// </summary>
        private void UpdateDayLightSystem() {
            DateTime currentTime = Utils.DateTime.GetCurrentDateTimeAtKathmandu();

            lightSystem.UpdateDayLightSystem(currentTime);

            float hourValue = currentTime.Hour + currentTime.Minute / 60f;

            lightSystemSlider.value = hourValue;

            timeMarkerText.text = currentTime.Hour + ":" + currentTime.Minute;
        }

        /// <summary>
        /// 
        /// Updates Day Light System from given hour value
        /// 
        /// </summary>
        /// <param name="hourValue">Hour Value of the day</param>
        private void UpdateDayLightSystem(float hourValue) {
            int hour = Mathf.FloorToInt(hourValue);

            int min = Mathf.FloorToInt((hourValue - (float) hour) * 60);

            DateTime datetime = new DateTime();

            datetime = datetime.AddHours(hour).AddMinutes(min);

            lightSystem.UpdateDayLightSystem(datetime);

            timeMarkerText.text = datetime.Hour + ":" + datetime.Minute;
        }

        /// <summary>
        /// 
        /// Called when the slider is updated
        /// 
        /// </summary>
        /// <param name="value">New value that was updated</param>
        private void SliderUpdated(float value) {
            UpdateDayLightSystem(value);
        }
    }
}