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

        // Use this for initialization
        void Awake() {
            factory = GetComponent<MountainFactory>();

            AppEngine.Instance.GetMountainStore().InitailizeStore(factory.GetMountains());
        }
    }
}