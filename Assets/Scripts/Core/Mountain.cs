using UnityEngine;

namespace TheHimalayas.Core {

    public class Mountain {

        /// <summary>
        /// 
        /// Name of the Mountain
        /// 
        /// </summary>
        public string name;

        /// <summary>
        /// 
        /// Elevation of the Mountain
        /// 
        /// </summary>
        public int elevation;

        /// <summary>
        /// 
        /// Wikipedia Title of the Mountain to fetch Information about the mountain
        /// 
        /// </summary>
        public string wikipediaTitle;

        /// <summary>
        /// 
        /// Coordinates of the Moutain
        /// 
        /// </summary>
        public Location coordinates;

        /// <summary>
        /// 
        /// Height Map Resource
        /// 
        /// </summary>
        public string heightMapResource;

        /// <summary>
        /// 
        /// Actual Height ap texture
        /// 
        /// </summary>
        private Texture2D heightMap;

        /// <summary>
        /// 
        /// Returns heightmap texture loaded from the disk
        /// 
        /// </summary>
        /// <returns>Heightmap texture</returns>
        public Texture2D GetHeightMap() {
            if(heightMap == null) {
                heightMap = Resources.Load(heightMapResource) as Texture2D;
            }

            return heightMap;
        }
    }
}