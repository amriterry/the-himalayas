using System.Collections.Generic;
using TerrainFactory;
using TheHimalayas.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TheHimalayas.Manager {

    public class MountainPlaceManager : MonoBehaviour {

        /// <summary>
        /// 
        /// Place Pointer prefab
        /// 
        /// </summary>
        public GameObject placePointerPrefab;

        /// <summary>
        /// 
        /// Place Pointer Width
        /// 
        /// </summary>
        public float placePointerWidth = 1200f;

        /// <summary>
        /// 
        /// Place Pointer Icon width
        /// 
        /// </summary>
        public float placePointerIconWidth = 200f;

        /// <summary>
        /// 
        /// Y Offset of the pointer's location
        /// 
        /// </summary>
        public float yOffset = 50f;

        /// <summary>
        /// 
        /// Cached Pointers
        /// 
        /// </summary>
        private static List<GameObject> cachedPointers;

        /// <summary>
        /// 
        /// Places the place pointers
        /// 
        /// </summary>
        /// <param name="places">Places in which the pointer is to be placed</param>
        /// <param name="mountain">Mountain Terrain Object</param>
        /// <param name="xSize">X Size of mountain object</param>
        /// <param name="ySize">Y Size of mountain object</param>
        /// <param name="zSize">Z Size of mountain object</param>
        public void SetPlacePointers(List<Place> places,HeightMapTerrain mountain, float xSize, float ySize, float zSize) {
            DestoryCachedPointers();

            List<GameObject> pointers = new List<GameObject>();

            foreach(Place place in places) {
                GameObject pointer = Instantiate(placePointerPrefab);

                pointer.name = place.name + " Pointer";
                pointer.GetComponentInChildren<Text>().text = place.name;

                pointer.transform.SetParent(mountain.transform);

                UpdatePointerPosition(pointer,place,xSize,ySize,zSize);

                pointers.Add(pointer);
            }

            cachedPointers = pointers;
        }

        /// <summary>
        /// 
        /// Destroys previous pointers
        /// 
        /// </summary>
        private void DestoryCachedPointers() {
            if(cachedPointers != null) {
                foreach (GameObject pointer in cachedPointers) {
                    if(pointer != null) {
                        pointer.SetActive(false);

                        DestroyImmediate(pointer);
                    }
                }
                cachedPointers.Clear();
            }
        }

        /// <summary>
        /// 
        /// Updates pointer position inside the Mountain Terrain
        /// 
        /// </summary>
        /// <param name="pointer">Actual Pointer Object</param>
        /// <param name="place">Place whose position is to be updated</param>
        /// <param name="xSize">X Size of mountain object</param>
        /// <param name="ySize">Y Size of mountain object</param>
        /// <param name="zSize">Z Size of mountain object</param>
        private void UpdatePointerPosition(GameObject pointer, Place place, float xSize, float ySize, float zSize) {
            float xOffset = placePointerWidth / 2 - placePointerIconWidth / 2;

            pointer.transform.localPosition = new Vector3(xSize * place.X + xOffset, ySize + yOffset, zSize * place.Y);
        }
    }
}