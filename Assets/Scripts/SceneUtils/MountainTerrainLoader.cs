using UnityEngine;
using TheHimalayas.Manager;

namespace TheHimalayas.SceneUtils {
    public class MountainTerrainLoader : MonoBehaviour {

        /// <summary>
        /// 
        /// Mountain terrain Manager instance.
        /// 
        /// </summary>
        public MountainTerrainManager terrainManager;

        // Use this for initialization
        void Start() {
            terrainManager.LoadCurrentMountainTerrain();
        }
    }
}