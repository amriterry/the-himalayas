using UnityEngine;
using TheHimalayas.Engine;
using TheHimalayas.Factory;

namespace TheHimalayas.Manager {

    public class MountainManager : MonoBehaviour {

        /// <summary>
        /// 
        /// MountainFactory Instance
        /// 
        /// </summary>
        private MountainFactory factory;

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

            factory = GetComponent<MountainFactory>();

            AppEngine.Instance.GetMountainStore().InitailizeStore(factory.GetMountains());
        }
    }
}