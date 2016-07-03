using TheHimalayas.Core;
using System.Collections.Generic;
using SimpleJSON;
using System;

namespace TheHimalayas.Parsers {

    public class MountainsParser : IJsonDataParser<Dictionary<string,Mountain>> {

        /// <summary>
        /// 
        /// Parses a JSON to get dictionary of Mountains
        /// 
        /// </summary>
        /// <param name="json">JSON String to parse</param>
        /// <returns>Dictionary of Mountains parsed from the JSON string</returns>
        public Dictionary<string, Mountain> Parse(string json) {
            JSONNode node = JSON.Parse(json);

            Dictionary<string, Mountain> mountains = new Dictionary<string, Mountain>();

            foreach(JSONNode mountainJson in node.Children) {
                mountains[mountainJson["key"]] = ParseMountain(mountainJson);
            }

            return mountains;
        }

        /// <summary>
        /// 
        /// Parses a single mountain from JSON
        /// 
        /// </summary>
        /// <param name="mountainJson">JSON to be parsed.</param>
        /// <returns>Parsed Mountain</returns>
        private static Mountain ParseMountain(JSONNode mountainJson) {
            Mountain mountain = new Mountain();

            mountain.name = ParseMountainName(mountainJson);
            mountain.elevation = ParseMountainElevation(mountainJson);
            mountain.wikipediaTitle = ParseMountainWikipediaTitle(mountainJson);
            mountain.coordinates = ParseMountainLocation(mountainJson);
            mountain.heightMapResource = ParseHeightMapResource(mountainJson);

            return mountain;
        }

        /// <summary>
        /// 
        /// Parse Mountain Name
        /// 
        /// </summary>
        /// <param name="mountainJson">JSON to be parsed</param>
        /// <returns>Parsed Mountain Name</returns>
        private static JSONNode ParseMountainName(JSONNode mountainJson) {
            return mountainJson["name"];
        }

        /// <summary>
        /// 
        /// Parse Mountain Elevation
        /// 
        /// </summary>
        /// <param name="mountainJson">JSON to be parsed</param>
        /// <returns>Parsed Mountain Elevation</returns>
        private static int ParseMountainElevation(JSONNode mountainJson) {
            return mountainJson["elevation"].AsInt;
        }

        /// <summary>
        /// 
        /// Parse Mountain Wikipedia Title
        /// 
        /// </summary>
        /// <param name="mountainJson">JSON to be parsed</param>
        /// <returns>Parsed Mountain Wikipedia Title</returns>
        private static JSONNode ParseMountainWikipediaTitle(JSONNode mountainJson) {
            return mountainJson["wikipedia_title"];
        }

        /// <summary>
        /// 
        /// Parse Mountain Location
        /// 
        /// </summary>
        /// <param name="mountainJson">JSON to be parsed</param>
        /// <returns>Parsed Mountain Location</returns>
        private static Location ParseMountainLocation(JSONNode mountainJson) {
            return new Location(mountainJson["coordinates"]["latitude"].AsFloat, mountainJson["coordinates"]["longitude"].AsFloat);
        }

        /// <summary>
        /// 
        /// Returns the height map resource path
        /// 
        /// </summary>
        /// <param name="mountainJson">JSON to be parsed</param>
        /// <returns>Parsed Height Map file path</returns>
        private static string ParseHeightMapResource(JSONNode mountainJson) {
            return mountainJson["terrain"]["heightMap"];
        }
    }
}