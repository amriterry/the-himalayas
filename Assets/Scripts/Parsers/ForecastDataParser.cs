using SimpleJSON;
using TheHimalayas.Core;

namespace TheHimalayas.Parsers {

    public class ForecastDataParser : IJsonDataParser<Forecast> {

        /// <summary>
        /// 
        /// Parses a JSON string an returns Forecast object.
        /// 
        /// </summary>
        /// <param name="json">JSON String to be parsed.</param>
        /// <returns>Forecast object built from the parsed JSON.</returns>
        public Forecast Parse(string json) {
            Forecast forecast = new Forecast();

            var parsed = JSON.Parse(json);

            forecast.cityName = parsed["city"]["name"];
            forecast.location = new Location(parsed["city"]["coord"]["lat"].AsFloat, parsed["city"]["coord"]["lon"].AsFloat);

            int cnt = parsed["cnt"].AsInt;

            for(int i = 0;i < cnt;i++) {
                forecast.AddWeather(ParseDailyForecast(parsed["list"][0]));
            }

            return forecast;
        }

        /// <summary>
        /// 
        /// Parses a daily forecast
        /// 
        /// </summary>
        /// <param name="parsed">JSON Parsed Object</param>
        /// <returns>WeatherMeta for the day</returns>
        private WeatherMeta ParseDailyForecast(JSONNode parsed) {
            WeatherMeta weatherMeta = new WeatherMeta();

            weatherMeta.temperature = ParseTemperature(parsed);
            weatherMeta.minTemperature = ParseMinTemperature(parsed);
            weatherMeta.maxTemperature = ParseMaxTemperature(parsed);
            weatherMeta.pressure = ParsePressure(parsed);
            weatherMeta.Cloudiness = ParseCloudiness(parsed);
            weatherMeta.dataCalculationTime = ParseDataCalculationTime(parsed);

            return weatherMeta;
        }

        /// <summary>
        /// 
        /// Parses Temperature
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Temperature</returns>
        private Temperature ParseTemperature(JSONNode parsed) {
            return new Temperature(parsed["temp"]["day"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Temperature
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Temperature</returns>
        private Temperature ParseMinTemperature(JSONNode parsed) {
            return new Temperature(parsed["temp"]["min"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Temperature
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse from</param>
        /// <returns>Parsed Temperature</returns>
        private Temperature ParseMaxTemperature(JSONNode parsed) {
            return new Temperature(parsed["temp"]["max"].AsFloat);
        }

        /// <summary>
        /// 
        /// Parses Pressure from the JSON Node
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse</param>
        /// <returns>Pressure Parsed From the JSON</returns>
        private float ParsePressure(JSONNode parsed) {
            return parsed["pressure"].AsFloat;
        }

        /// <summary>
        /// 
        /// Parses Cloudiness from the JSON Node
        /// 
        /// </summary>
        /// <param name="parsed">JSON Node to parse</param>
        /// <returns>Cloudiness got from the parsed JSON</returns>
        private float ParseCloudiness(JSONNode parsed) {
            return parsed["clouds"].AsFloat;
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