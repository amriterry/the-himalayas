namespace TheHimalayas.Utils {

    public class DateTime {

        /// <summary>
        /// 
        /// Converts UTC Timestamp to DateTime Object
        /// 
        /// </summary>
        /// <param name="unixTimeStamp">UTC Timestamp to convert</param>
        /// <returns>Converted DateTime Object.</returns>
        public static System.DateTime UnixTimeStampToDateTime(double unixTimeStamp) {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dateTime;
        }
    }
}