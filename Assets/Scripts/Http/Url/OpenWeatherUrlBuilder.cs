using System;
using System.Collections.Generic;
using TheHimalayas.Core;

namespace TheHimalayas.Http.Url {

    abstract public class OpenWeatherUrlBuilder : IUrlBuilder {

        /// <summary>
        /// 
        /// Base API URL
        /// 
        /// </summary>
        private string baseUrl = "http://api.openweathermap.org/data/2.5/";

        /// <summary>
        /// 
        /// URL Options
        /// 
        /// </summary>
        private Dictionary<string, string> urlOptions;

        /// <summary>
        /// 
        /// Creates an OpenWeatherUrlBuilder object.
        /// 
        /// </summary>
        public OpenWeatherUrlBuilder() {
            urlOptions = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// Adds an URL Option to the list.
        /// 
        /// </summary>
        /// <param name="key">Key of the option</param>
        /// <param name="value">Value for the key of option</param>
        /// <returns>Current URL Builder object for chaining</returns>
        public OpenWeatherUrlBuilder AddUrlOption(string key, string value) {
            urlOptions[key] = value;

            return this;
        }

        /// <summary>
        /// 
        /// Builds the API URl.
        /// 
        /// </summary>
        /// <returns>API URL that is built.</returns>
        public string Build() {
            string url = baseUrl;

            url = AppendMainUrlSegment(url);
            url = AppendUrlOptions(url);
            url = AppendAppId(url);

            return url;
        }

        /// <summary>
        /// 
        /// Appends Main URL Segment to the Base URL.
        /// 
        /// </summary>
        /// <param name="url">Base URL in which the URL Segment is to be appended.</param>
        /// <returns>Appened URL.</returns>
        private string AppendMainUrlSegment(string url) {
            return url + GetMainUrlSegment();
        }

        /// <summary>
        /// 
        /// Appends URL Options to the Base URL.
        /// 
        /// </summary>
        /// <param name="url">Base URl in which the options are to be appended.</param>
        /// <returns>Options Appened URL.</returns>
        private string AppendUrlOptions(string url) {
            return url + "?" + ParseOptions(urlOptions);
        }

        /// <summary>
        /// 
        /// Parses Dictonary of URL Options to be usable for URL string.
        /// 
        /// </summary>
        /// <param name="options">Options that are to be parsed.</param>
        /// <returns>URL consumable options.</returns>
        private string ParseOptions(Dictionary<string, string> options) {
            List<string> optionsArray = new List<string>();

            foreach (KeyValuePair<string, string> option in options) {
                optionsArray.Add(option.Key + "=" + option.Value);
            }

            return String.Join("&", optionsArray.ToArray());
        }

        /// <summary>
        /// 
        /// Appends App ID to the URL for server side authentication.
        /// 
        /// </summary>
        /// <param name="url">Base URL in which it is to be appended.</param>
        /// <returns>App ID appended URL.</returns>
        private string AppendAppId(string url) {
            return url + "&appid=" + GetAppId();
        }

        /// <summary>
        /// 
        /// Returns the App ID for authentatication.
        /// 
        /// </summary>
        /// <returns>App Id for OpenWeatherMap account.</returns>
        private string GetAppId() {
            // @todo Get App Id from a config file.
            return "2d0d994a089af8a60994fb35a187a923";
        }

        /// <summary>
        /// 
        /// Returns URL's main segment.
        /// 
        /// </summary>
        /// <returns>Main segment of URL.</returns>
        protected abstract string GetMainUrlSegment();

        /// <summary>
        /// 
        /// Builds the URL for the latitude and longitude given.
        /// 
        /// </summary>
        /// <param name="location">The location for which the url is built.</param>
        /// <returns>API URL for the given location.</returns>
        public abstract string BuildUrl(Location location);
    }
}