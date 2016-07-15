using UnityEngine;
using TheHimalayas.Manager;
using System.Collections;
using TheHimalayas.Engine;

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
            StartCoroutine("LoadMountainTerrain");
        }

        /// <summary>
        /// 
        /// Coroutine to load the mountain terrain
        /// 
        /// </summary>
        /// <returns>IEnumerator instance</returns>
        IEnumerator LoadMountainTerrain() {
            var storeDict = AppEngine.Instance.GetMountainStore().GetStoreDictionary();

            if (!(storeDict != null && storeDict.Count > 0)) {
                yield return new WaitForEndOfFrame();
            }

            terrainManager.LoadCurrentMountainTerrain();
        }
    }
}