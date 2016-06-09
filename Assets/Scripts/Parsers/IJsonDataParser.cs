namespace TheHimalayas.Parsers {

    public interface IJsonDataParser<T> {
        
        /// <summary>
        /// 
        /// Parses a json string an returns T object.
        /// 
        /// </summary>
        /// <param name="json">JSON String to be parsed.</param>
        /// <returns>Object Built from the parsed JSON.</returns>
        T Parse(string json);
    }
}