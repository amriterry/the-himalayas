using TheHimalayas.Core;

namespace TheHimalayas.Http.Url {

    public class ForecastUrlBuilder : OpenWeatherUrlBuilder {

        /// <summary>
        /// 
        /// Number of Forecasts for which the URL is to be built
        /// 
        /// </summary>
        private const int FORECAST_COUNT = 2;

        /// <summary>
        /// 
        /// Builds URL for the given location parameter
        /// 
        /// </summary>
        /// <param name="location">Location object for which the URL is to be built.</param>
        /// <returns>Built URL String</returns>
        public override string BuildUrl(Location location) {
            AddUrlOption("lat", location.Latitude.ToString());
            AddUrlOption("lon", location.Longitude.ToString());
            AddUrlOption("cnt", FORECAST_COUNT.ToString());

            return this.Build();
        }

        /// <summary>
        /// 
        /// Returns Main Segment of the URL
        /// 
        /// </summary>
        /// <returns>Main Segment of the URL</returns>
        protected override string GetMainUrlSegment() {
            return "forecast/daily";
        }
    }
}