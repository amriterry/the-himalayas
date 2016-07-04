using UnityEngine;
using TheHimalayas.View;

namespace TheHimalayas.Manager {

    public class CameraViewManager : MonoBehaviour {
        
        /// <summary>
        /// 
        /// Camera Renderer instance
        /// 
        /// </summary>
        public CameraRenderer cameraRenderer;

        // Use this for initialization
        void Start() {
            cameraRenderer.gameObject.SetActive(true);
            cameraRenderer.Initialize();
        }
    }
}