using TheHimalayas.Http.Url;

namespace TheHimalayas.Http {

    public class ForecastHttpClient : OpenWeatherHttpClient {

        /// <summary>
        /// 
        /// Builds the URL for forecast
        /// 
        /// </summary>
        private ForecastUrlBuilder urlBuilder;

        // When the script first awakens
        void Awake() {
            urlBuilder = new ForecastUrlBuilder();
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