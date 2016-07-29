
using TheHimalayas.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheHimalayas.Manager {

    public class AppSceneManager: MonoBehaviour {

        private int currentSceneIndex;

        private int nextSceneIndex;

        private bool canLoadScene = false;

        /// <summary>
        /// 
        /// App Scene Manager instance
        /// 
        /// </summary>
        private static AppSceneManager instance;

        /// <summary>
        /// 
        /// Singleton Instance property
        /// 
        /// </summary>
        public static AppSceneManager Instance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<AppSceneManager>();
                }

                RemoveMultipleInstances();

                return instance;
            }
        }

        private static void RemoveMultipleInstances() {
            AppSceneManager[] managers = FindObjectsOfType<AppSceneManager>();

            if (managers.Length > 1) {
                foreach (AppSceneManager controller in managers) {
                    if (controller != instance) {
                        Destroy(controller.gameObject);
                    }
                }
            }
        }

        void Awake() {
            DontDestroyOnLoad(gameObject);
            RemoveMultipleInstances();
        }

        void Update() {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if(currentSceneIndex == AppScene.LOADING_SCENE && currentSceneIndex != nextSceneIndex && canLoadScene) {
                SceneManager.LoadSceneAsync(nextSceneIndex);
                canLoadScene = false;
            }
        }


        /// <summary>
        /// 
        /// Loads Menu Scene
        /// 
        /// </summary>
        public void LoadMenuScene() {
            LoadScene(AppScene.MENU_SCENE);
        }

        /// <summary>
        /// 
        /// Loads Mountain Scene
        /// 
        /// </summary>
        public void LoadMountainScene() {
            LoadScene(AppScene.MOUNTAIN_3D_SCENE);
        }

        /// <summary>
        /// 
        /// Loads Mountain AR Scene
        /// 
        /// </summary>
        public void LoadMountainARScene() {
            LoadScene(AppScene.MOUNTAIN_AR_SCENE);
        }

        /// <summary>
        /// 
        /// Loads a Scene
        /// 
        /// </summary>
        private void LoadScene(int buildIndex) {
            SceneManager.LoadScene(AppScene.LOADING_SCENE);

            canLoadScene = true;
            nextSceneIndex = buildIndex;
        }
    }
}