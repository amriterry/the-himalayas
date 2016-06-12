using TheHimalayas.Core;

namespace TheHimalayas.Store {

    public class MountainStore : Store<string,Mountain> {

        /// <summary>
        /// 
        /// Pointer to the mountain which is currently selected.
        /// 
        /// </summary>
        private int pointer;

        /// <summary>
        /// 
        /// Returns the mountain enumerator
        /// 
        /// </summary>
        /// <returns>Mountain dictionary enumerator</returns>
        public int GetPointer() {
            return pointer;
        }

        /// <summary>
        /// 
        /// Moves the pointer to next element
        /// 
        /// </summary>
        /// <returns>Pointer to selected mountain</returns>
        public int MovePointerToNext() {
            pointer = (pointer + 1) % this.GetStoreDictionary().Count;

            return pointer;
        }

        /// <summary>
        /// 
        /// Moves the pointer to previous element.
        /// 
        /// </summary>
        /// <returns>Pointer to selected mountain</returns>
        public int MovePointerToPrevious() {
            pointer = (pointer - 1) % this.GetStoreDictionary().Count;

            if(pointer < 0) {
                pointer = this.GetStoreDictionary().Count - 1;
            }

            return pointer;
        }

        /// <summary>
        /// 
        /// Returns pointed Mountain
        /// 
        /// </summary>
        /// <returns>Mountain pointed by the pointer</returns>
        public Mountain GetPointedMountain() {
            string[] keys = new string[this.GetStoreDictionary().Count];

            GetStoreDictionary().Keys.CopyTo(keys, 0);

            return GetValue(keys[pointer]);
        }
    }
}