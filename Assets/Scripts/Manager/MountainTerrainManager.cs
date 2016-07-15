using UnityEngine;
using TerrainFactory;
using TheHimalayas.Core;
using TheHimalayas.Engine;

namespace TheHimalayas.Manager {

    public class MountainTerrainManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Number of tiles in X-axis
        /// 
        /// </summary>
        public int numTilesX = 254;

        /// <summary>
        /// 
        /// Number of tiles in Z-axis
        /// 
        /// </summary>
        public int numTilesZ = 254;

        /// <summary>
        /// 
        /// Size of each tile 
        /// 
        /// </summary>
        public float tileSize = 20f;

        /// <summary>
        /// 
        /// Height Multiplier
        /// 
        /// </summary>
        public float heightMultiplier = 1400f;

        /// <summary>
        /// 
        /// Material for mountains
        /// 
        /// </summary>
        public Material mountainMaterial;

        /// <summary>
        /// 
        /// Terrain Factory Instance.
        /// 
        /// </summary>
        private static TerrainFactory.Factory terrainFactory;

        /// <summary>
        /// 
        /// Cached Terrain instance.
        /// 
        /// </summary>
        private static HeightMapTerrain terrain;

        /// <summary>
        /// 
        /// Loads mountain terrain
        /// 
        /// </summary>
        /// <param name="mountain">Mountain of which the terrain is to be loaded</param>
        public void LoadMountainTerrain(Mountain mountain) {
            if (terrainFactory == null) {
                terrainFactory = new TerrainFactory.Factory();
            }

            TerrainFactory.TerrainData data = new TerrainFactory.TerrainData(numTilesX, numTilesZ, tileSize, heightMultiplier, mountain.GetHeightMap(), mountainMaterial);

            if (terrain == null) {
                terrain = terrainFactory.BuildMesh(data);

                DontDestroyOnLoad(terrain.gameObject);
            } else {
                terrainFactory.UpdateMesh(data, terrain);
            }

            terrain.name = mountain.name;
        }

        /// <summary>
        /// 
        /// Loads current pointed mountain
        /// 
        /// </summary>
        public void LoadCurrentMountainTerrain() {
            LoadMountainTerrain(AppEngine.Instance.GetMountainStore().GetPointedMountain());
        }
    }
}