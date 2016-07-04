using UnityEngine;
using TerrainFactory;
using TheHimalayas.Core;
using TheHimalayas.Engine;

namespace TheHimalayas.Manager {

    public class MountainTerrainManager : MonoBehaviour {

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

            TerrainFactory.TerrainData data = new TerrainFactory.TerrainData(254, 254, 20f, 1400f, mountain.GetHeightMap(), mountainMaterial);

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