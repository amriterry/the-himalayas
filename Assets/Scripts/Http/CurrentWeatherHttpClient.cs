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
        /// Returns API URL from which the data is to be fetched.
        /// 
        /// </summary>
        /// <returns>API URL for fetching of data.</returns>
        public override string GetApiUrl() {
            return urlBuilder.BuildUrl(this.location);
        }
    }
}
