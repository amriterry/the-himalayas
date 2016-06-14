using System;
using TheHimalayas.Http.Url;
using UnityEngine;

namespace TheHimalayas.Http {

    public class CurrentWeatherHttpClient : OpenWeatherHttpClient {

        /// <summary>
        /// 
        /// URL Builder to build API URL for current weather data.
        /// 
        /// </summary>
        private CurrentWeatherUrlBuilder urlBuilder;

        // Called when the script first awakes.
        void Awake() {
            urlBuilder = new CurrentWeatherUrlBuilder();
        }

        /// <summary>
        /// 
        /// Returns OpenWeatherUrlBuilder object
        /// 
        /// </summary>
        /// <returns>OpenWeatherUrlBuilder object</returns>
        protected override OpenWeatherUrlBuilder GetUrlBuilder() {
            return urlBuilder;
        }
    }
}
