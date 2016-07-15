using UnityEngine;
using TerrainFactory;

namespace TheHimalayas.Manager { 

    public class MountainARSceneManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Image Target to load
        /// 
        /// </summary>
        public Transform imageTarget;

	    // Use this for initialization
	    void Start () {
            HeightMapTerrain mountain = GameObject.FindObjectOfType<HeightMapTerrain>();

            if( mountain == null) {
                Debug.LogError("No HeightMapTerrain to load");
            } else {
                mountain.gameObject.transform.SetParent(imageTarget);
                mountain.gameObject.transform.localScale = new Vector3(1 / 2032f, 1 / 2032f, 1 / 2032f);
                mountain.gameObject.transform.localPosition = new Vector3(- 1.25f, 0 ,- 1.25f);
            }
        }
	 
    }
}