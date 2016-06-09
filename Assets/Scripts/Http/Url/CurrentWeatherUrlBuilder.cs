using TheHimalayas.Core;

namespace TheHimalayas.Http.Url {

    public class CurrentWeatherUrlBuilder : OpenWeatherUrlBuilder {

        /// <summary>
        /// 
        /// Returns URL's main segment.
        /// 
        /// </summary>
        /// <returns>Main segment of URL.</returns>
        protected override string GetMainUrlSegment() {
            return "weather";
        }

        /// <summary>
        /// 
        /// Builds the URL for the latitude and longitude given.
        /// 
        /// </summary>
        /// <param name="location">The location for which the url is built.</param>
        /// <returns>API URL for the given location.</returns>
        public override string BuildUrl(Location location) {
            AddUrlOption("lat", location.Latitude.ToString());
            AddUrlOption("lon", location.Longitude.ToString());

            return this.Build();
        }
    }
}