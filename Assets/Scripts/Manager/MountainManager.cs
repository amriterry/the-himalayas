using UnityEngine;
using TheHimalayas.Engine;
using TheHimalayas.Factory;
using TerrainFactory;
using TheHimalayas.Core;

namespace TheHimalayas.Manager {

    public class MountainManager : MonoBehaviour {

        /// <summary>
        /// 
        /// MountainFactory Instance
        /// 
        /// </summary>
        private static MountainFactory factory;

        /// <summary>
        /// 
        /// AppEngine Instance
        /// 
        /// </summary>
        private static MountainManager instance;

        // Use this for initialization
        void Awake() {
            DontDestroyOnLoad(gameObject);

            if (MountainManager.instance == null) {
                instance = GameObject.FindObjectOfType<MountainManager>();
            }

            MountainManager[] controllers = GameObject.FindObjectsOfType<MountainManager>();

            if (controllers.Length > 1) {
                foreach (MountainManager controller in controllers) {
                    if (controller != instance) {
                        Destroy(controller.gameObject);
                    }
                }
            }
        }

        // Use this when script first starts
        void Start() {
            factory = GetComponent<MountainFactory>();

            AppEngine.Instance.GetMountainStore().InitailizeStore(factory.GetMountains());
        }
    }
}