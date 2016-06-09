namespace TheHimalayas.Core {

    public struct Location {
        /// <summary>
        /// 
        /// Latitude of the location.
        /// 
        /// </summary>
        public float Latitude;

        /// <summary>
        /// 
        /// Longitude of the location.
        /// 
        /// </summary>
        public float Longitude;

        /// <summary>
        /// 
        /// Creates a Location structure
        /// 
        /// </summary>
        /// <param name="latitude">Latitude of the Location</param>
        /// <param name="longitude">Longitue of the Location</param>
        public Location(float latitude, float longitude) {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// 
        /// Converts the location to string
        /// 
        /// </summary>
        /// <returns>Stringified Location</returns>
        public override string ToString() {
            return this.Latitude + "\u00B0 N, " + this.Longitude + "\u00B0 E";
        }
    }
}