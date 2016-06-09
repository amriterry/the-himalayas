namespace TheHimalayas.Core {

    public struct Temperature {
        /// <summary>
        /// 
        /// Temperature in Kelvin
        /// 
        /// </summary>
        public float temp;

        /// <summary>
        /// 
        /// Sets the temperature value
        /// 
        /// </summary>
        /// <param name="temp">Setting the temperature value</param>
        public Temperature(float temp) {
            this.temp = temp;
        }

        /// <summary>
        /// 
        /// Returns given temperature in celcius.
        /// 
        /// </summary>
        /// <returns>Temperature in celcius</returns>
        public float InCelcius() {
            return temp - 273.73f;
        }

        /// <summary>
        /// 
        /// Returns given temperature in fahernheit.
        /// 
        /// </summary>
        /// <returns>Temperature in fahernheit</returns>
        public float InFahernheit() {
            return temp - 180f;
        }

        /// <summary>
        /// 
        /// Returns Celcius temperature in string
        /// 
        /// </summary>
        /// <returns>Stringified Temperature</returns>
        public string ToCelciusString() {
            return InCelcius() + "\u00B0 C";
        }

        /// <summary>
        /// 
        /// Returns Fahernheit temperature in string
        /// 
        /// </summary>
        /// <returns>Stringified Temperature</returns>
        public string ToFahernheitString() {
            return InFahernheit() + "\u00B0 F";
        }
    }
}