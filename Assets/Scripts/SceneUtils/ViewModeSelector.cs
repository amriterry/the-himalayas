using UnityEngine;
using TheHimalayas.Utils;
using UnityEngine.SceneManagement;

namespace TheHimalayas.SceneUtils {

    public class ViewModeSelector : MonoBehaviour {

        /// <summary>
        /// 
        /// Changes to 3D Mode
        /// 
        /// </summary>
        public void ChangeTo3DMode() {
            ChangeScene(AppScene.MOUNTAIN_3D_SCENE);
        }

        /// <summary>
        /// 
        /// Changes to AR Mode
        /// 
        /// </summary>
        public void ChangeToARMode() {
            ChangeScene(AppScene.MOUNTAIN_AR_SCENE);
        }

        /// <summary>
        /// 
        /// Changes to VR Mode
        /// 
        /// </summary>
        public void ChangeToVRMode() {
            ChangeScene(AppScene.MOUNTAIN_VR_SCENE);
        }

        /// <summary>
        /// 
        /// Changes the scene
        /// 
        /// </summary>
        private void ChangeScene(int buildIndex) {
            if(SceneManager.GetActiveScene().buildIndex != buildIndex) {
                SceneManager.LoadScene(buildIndex);
            }
        }
    }
}