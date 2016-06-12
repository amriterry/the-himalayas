using System.Collections.Generic;

namespace TheHimalayas.Store {

    public abstract class Store< T, U>{

        /// <summary>
        /// 
        /// Store Dictionary Object
        /// 
        /// </summary>
        private Dictionary<T, U> storeDictionary;

        /// <summary>
        /// 
        /// Store Update Action
        /// 
        /// </summary>
        /// <param name="key">Key that was updated</param>
        /// <param name="value">Value that was updated</param>
        public delegate void StoreUpdateAction(T key, U value);

        /// <summary>
        /// 
        /// OnStoreUpdate Event
        /// 
        /// </summary>
        public event StoreUpdateAction OnStoreUpdate;

        /// <summary>
        /// 
        /// Constructs a weather store
        /// 
        /// </summary>
        public Store() {
            storeDictionary = new Dictionary<T, U>();
        }

        /// <summary>
        /// 
        /// Initializes the store with existing dictionary
        /// 
        /// </summary>
        /// <param name="store">The store to copy</param>
        public void InitailizeStore(Dictionary<T, U> store) {
            this.storeDictionary = store;
        }

        /// <summary>
        /// 
        /// Sets an entry in store dictionary
        /// 
        /// </summary>
        /// <param name="key">Key for the value</param>
        /// <param name="value">Value of the key</param>
        public void SetToStore(T key, U value) {
            this.storeDictionary[key] = value;

            if (OnStoreUpdate != null) {
                OnStoreUpdate(key, value);
            }
        }

        /// <summary>
        /// 
        /// Returns a value for the key
        /// 
        /// </summary>
        /// <param name="key">Key for which the value is to be found</param>
        /// <returns>Value for the Key</returns>
        public U GetValue(T key) {
            return this.storeDictionary[key];
        }

        /// <summary>
        /// 
        /// Returns the store dictionary.
        /// 
        /// </summary>
        /// <returns>The store dictionary</returns>
        public Dictionary<T,U> GetStoreDictionary() {
            return this.storeDictionary;
        }

        /// <summary>
        /// 
        /// Adds OnStoreUpdate Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to add</param>
        public void AddOnStoreUpdateListener(StoreUpdateAction listener) {
            this.OnStoreUpdate += listener;
        }

        /// <summary>
        /// 
        /// Forgets OnStoreUpdate Event Listener
        /// 
        /// </summary>
        /// <param name="listener">Listener to forget</param>
        public void ForegetOnStoreUpdateListener(StoreUpdateAction listener) {
            this.OnStoreUpdate -= listener;
        }
    }
}