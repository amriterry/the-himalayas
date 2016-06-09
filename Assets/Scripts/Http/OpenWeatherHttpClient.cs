namespace TheHimalayas.Http {

    abstract public class OpenWeatherHttpClient : HttpClient {

        /// <summary>
        /// 
        /// Longitude of the location for which the weather information is to be fetched.
        /// 
        /// </summary>
        protected float longitude;

        /// <summary>
        /// 
        /// Latitude of the location for which the weather information is to be fetched.
        /// 
        /// </summary>
        protected float latitude;

        /// <summary>
        /// 
        /// Sets the Location information for which the weather information is to be fetched.
        /// 
        /// </summary>
        /// <param name="latitude">Latitude of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Current Object for chaining</returns>
        public OpenWeatherHttpClient SetLocation(float latitude, float longitude) {
            this.longitude = longitude;
            this.latitude = latitude;

            return this;
        }

        /// <summary>
        /// 
        /// Fetches the weather data and calls appropriate response.
        /// 
        /// </summary>
        /// <param name="successResponse">Response Delegate to be called when the request is successful</param>
        /// <param name="errorResponse">Response Delegate to be called when the request is not successful</param>
        public void GetWeatherData(SuccessResponse successResponse, ErrorResponse errorResponse) {
            AddSuccessResponseListener(successResponse);
            AddErrorResponseListener(errorResponse);

            this.CreateRequest(GetApiUrl()).SendRequest();
        }

        /// <summary>
        /// 
        /// Returns API URL from which the data is to be fetched.
        /// 
        /// </summary>
        /// <returns>API URL for fetching of data.</returns>
        abstract public string GetApiUrl();
    }
}