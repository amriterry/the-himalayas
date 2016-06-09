using TheHimalayas.Core;
using TheHimalayas.Parsers;
using System.Collections.Generic;
using UnityEngine;

namespace TheHimalayas.Factory {

    public class MountainFactory: MonoBehaviour {

        /// <summary>
        /// 
        /// Dictionary of Moutains created.
        /// 
        /// </summary>
        private Dictionary<string, Mountain> mountains;

        /// <summary>
        /// 
        /// Mountain Parser to build Moutain from.
        /// 
        /// </summary>
        private MountainsParser parser;

        /// <summary>
        /// 
        /// Mountains Resource File at "Assets/Resources/Mountains.json";
        /// 
        /// </summary>
        private string mountainsFile = "Mountains";

        // called when the script first awakes
        void Awake() {
            parser = new MountainsParser();
        }

        /// <summary>
        /// 
        /// Returns the mountains dictionary.
        /// 
        /// </summary>
        /// <returns>Mountains dictionary.</returns>
        public Dictionary<string,Mountain> GetMountains() {
            if(mountains == null) {
                BuildMountains();
            }

            return mountains;
        }

        /// <summary>
        /// 
        /// Returns a mountain object for the key.
        /// 
        /// </summary>
        /// <param name="key">Key of which the mountain is to be found.</param>
        /// <returns>Mountain of the given key.</returns>
        public Mountain GetMountain(string key) {
            if(mountains == null) {
                BuildMountains();
            }

            return mountains[key];
        }

        /// <summary>
        /// 
        /// Build Mountains by parsing the mountains info
        /// 
        /// </summary>
        private void BuildMountains() {
            mountains = parser.Parse(GetMountainsInfo());
        }

        /// <summary>
        /// 
        /// Returns mountains json string
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetMountainsInfo() {
            TextAsset mountains = Resources.Load(mountainsFile) as TextAsset;

            string json = mountains.text;

            Resources.UnloadAsset(mountains);

            return json;
        }
    }
}