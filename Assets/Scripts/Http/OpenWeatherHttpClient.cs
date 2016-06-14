using System;
using TheHimalayas.Core;
using TheHimalayas.Http.Url;

namespace TheHimalayas.Http {

    abstract public class OpenWeatherHttpClient : HttpClient {

        /// <summary>
        /// 
        /// Location for which the weather is to be found.
        /// 
        /// </summary>
        protected Location location;

        /// <summary>
        /// 
        /// Sets the Location information for which the weather information is to be fetched.
        /// 
        /// </summary>
        /// <param name="latitude">Latitude of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Current Object for chaining</returns>
        public OpenWeatherHttpClient SetLocation(float latitude, float longitude) {
            return this.SetLocation(new Location(latitude, longitude));
        }

        /// <summary>
        /// 
        /// Sets the Location information for which the weather information is to be fetched.
        /// 
        /// </summary>
        /// <param name="location">The location to store</param>
        /// <returns>Current Object for chaining</returns>
        public OpenWeatherHttpClient SetLocation(Location location) {
            this.location = location;

            return this;
        }

        /// <summary>
        /// 
        /// Fetches the weather data and calls appropriate response.
        /// 
        /// </summary>
        /// <param name="successResponse">Response Delegate to be called when the request is successful</param>
        /// <param name="errorResponse">Response Delegate to be called when the request is not successful</param>
        public void GetData(SuccessResponse successResponse, ErrorResponse errorResponse) {
            AddSuccessResponseListener(successResponse);
            AddErrorResponseListener(errorResponse);

            GetData();
        }

        /// <summary>
        /// 
        /// Get's weather data from server.
        /// 
        /// </summary>
        public void GetData() {
            this.CreateRequest(GetApiUrl()).SendRequest();
        }

        /// <summary>
        /// 
        /// Returns API URL from which the data is to be fetched.
        /// 
        /// </summary>
        /// <returns>API URL for fetching of data.</returns>
        public string GetApiUrl() {
            return GetUrlBuilder().BuildUrl(this.location);
        }

        /// <summary>
        /// 
        /// Returns OpenWeatherUrlBuilder object
        /// 
        /// </summary>
        /// <returns>OpenWeatherUrlBuilder object</returns>
        protected abstract OpenWeatherUrlBuilder GetUrlBuilder();
    }
}