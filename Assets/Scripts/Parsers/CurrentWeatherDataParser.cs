using SimpleJSON;
using TheHimalayas.Core;

namespace TheHimalayas.Parsers {

    public class CurrentWeatherDataParser : IJsonDataParser<Weather> {

        /// <summary>
        /// 
        /// Parses a JSON string an returns Weather object.
        /// 
        /// </summary>
        /// <param name="json">JSON String to be parsed.</param>
        /// <returns>Weather object built from the parsed JSON.</returns>
        public Weather Parse(string json) {
            Weather weather = new Weather();

            var parsed = JSON.Parse(json);

            weather.location = ParseLocation(parsed);
            weather.temperature = ParseTemperature(parsed);
            weather.minTemperature = ParseMinTemperature(parsed);
            weather.maxTemperature = ParseMaxTemperature(parsed);
            weather.pressure = ParsePressure(parsed);
            weather.Cloudiness = ParseCloudiness(parsed);
            weather.cityName = ParseCityName(parsed);
            weather.dataCalculationTime = ParseDataCalculationTime(parsed);

            return weather;
        }

        /// <summary>
        /// 
        /// Parses location from the JSON Node
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse</param>
        /// <returns>Location got from the parsed JSON</returns>
        private Location ParseLocation(JSONNode parsed) {
            return new Location(parsed["coord"]["lat"].AsFloat, parsed["coord"]["lon"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Temperature
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Temperature</returns>
        private Temperature ParseTemperature(JSONNode parsed) {
            return new Temperature(parsed["main"]["temp"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Temperature
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Temperature</returns>
        private Temperature ParseMinTemperature(JSONNode parsed) {
            return new Temperature(parsed["main"]["temp_min"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Temperature
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Temperature</returns>
        private Temperature ParseMaxTemperature(JSONNode parsed) {
            return new Temperature(parsed["main"]["temp_max"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Pressure from the JSON Node
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse</param>
        /// <returns>Pressure Parsed From the JSON</returns>
        private float ParsePressure(JSONNode parsed) {
            return parsed["main"]["pressure"].AsFloat;
        }

        /// <summary>
        /// 
        /// Parses Cloudiness from the JSON Node
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse</param>
        /// <returns>Cloudiness got from the parsed JSON</returns>
        private float ParseCloudiness(JSONNode parsed) {
            return parsed["clouds"]["all"].AsFloat;
        }

        /// <summary>
        /// 
        /// Parses City Name
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed City Name</returns>
        private JSONNode ParseCityName(JSONNode parsed) {
            return parsed["name"];
        }

        

        /// <summary>
        /// 
        /// Parses Data Calculation Time
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Data Calculation Time</returns>
        private double ParseDataCalculationTime(JSONNode parsed) {
            return parsed["dt"].AsDouble;
        }
    }
}
