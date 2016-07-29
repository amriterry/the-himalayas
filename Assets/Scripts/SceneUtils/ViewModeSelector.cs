using UnityEngine;
using TheHimalayas.Manager;

namespace TheHimalayas.SceneUtils {

    public class ViewModeSelector : MonoBehaviour {

        /// <summary>
        /// 
        /// Camera for which the mode is to be selected.
        /// 
        /// </summary>
        public Camera mainCam;

        /// <summary>
        /// 
        /// Gvr Viewer instance.
        /// 
        /// </summary>
        public GvrViewer gvrViewer;

        /// <summary>
        /// 
        /// Root Canvas game object
        /// 
        /// </summary>
        public Canvas rootCanvas;

        /// <summary>
        /// 
        /// Flag to check if the mode is VR
        /// 
        /// </summary>
        private bool isInVRMode = false;

        /// <summary>
        /// 
        /// Property to isInVRMode flag
        /// 
        /// </summary>
        public bool IsInVRMode {
            get {
                return isInVRMode;
            }
        }

        /// <summary>
        /// 
        /// Cached camera position
        /// 
        /// </summary>
        private Vector3 cameraPosition;

        /// <summary>
        /// 
        /// Cached camera rotation
        /// 
        /// </summary>
        private Vector3 cameraRotation;      

        /// <summary>
        /// 
        /// Changes to 3D Mode
        /// 
        /// </summary>
        public void ChangeTo3DMode() {
            if(isInVRMode) {
                isInVRMode = false;

                gvrViewer.VRModeEnabled = false;
                gvrViewer.gameObject.SetActive(false);
                rootCanvas.gameObject.SetActive(true);

                mainCam.GetComponent<StereoController>().enabled = false;
                mainCam.GetComponent<GvrHead>().enabled = false;

                mainCam.transform.position = cameraPosition;
                mainCam.transform.rotation = Quaternion.Euler(cameraRotation);
            }
        }

        /// <summary>
        /// 
        /// Changes to AR Mode
        /// 
        /// </summary>
        public void ChangeToARMode() {
            AppSceneManager.Instance.LoadMountainARScene();
        }

        /// <summary>
        /// 
        /// Changes to VR Mode
        /// 
        /// </summary>
        public void ChangeToVRMode() {
            if(!isInVRMode) {
                isInVRMode = true;

                cameraPosition = mainCam.transform.position;
                cameraRotation = mainCam.transform.rotation.eulerAngles;

                rootCanvas.gameObject.SetActive(false);
                gvrViewer.gameObject.SetActive(true);
                gvrViewer.VRModeEnabled = true;

                StereoController stereo = mainCam.GetComponent<StereoController>();
                GvrHead head = mainCam.GetComponent<GvrHead>();

                if (stereo) {
                    stereo.enabled = true;
                }
                if(head) {
                    head.enabled = true;
                }

                mainCam.transform.position = new Vector3(2540f, 1400f, 2540f);
            }
        }
    }
}