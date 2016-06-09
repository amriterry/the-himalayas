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
        /// <param name="latitude">Latitude of the location.</param>
        /// <param name="longitude">Longitude of the location.</param>
        /// <returns>API URL for the given location.</returns>
        public override string BuildUrl(float latitude,float longitude) {
            AddUrlOption("lat", latitude.ToString());
            AddUrlOption("lon", longitude.ToString());

            return this.Build();
        }
    }
}