using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.View {

    public class CameraRenderer : MonoBehaviour {

        /// <summary>
        /// 
        /// Initializes Camera Renderer
        /// 
        /// </summary>
        public void Initialize() {
            WebCamDevice[] devices = WebCamTexture.devices;

            string backCamName = "";

            for (int i = 0; i < devices.Length; i++) {
                if (!devices[i].isFrontFacing) {
                    backCamName = devices[i].name;
                }
            }

            var cameraTexture = new WebCamTexture(backCamName, 1600, 900, 30);

            cameraTexture.Play();

            gameObject.GetComponent<Image>().defaultMaterial.mainTexture = cameraTexture;
        }
    }
}