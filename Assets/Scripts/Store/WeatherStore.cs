using System.Collections.Generic;
using TheHimalayas.Core;

namespace TheHimalayas.Store {

    public class WeatherStore {

        /// <summary>
        /// 
        /// Weathers for mountains
        /// 
        /// </summary>
        private Dictionary<Mountain, Weather> weathers;

        /// <summary>
        /// 
        /// Store Update Action
        /// 
        /// </summary>
        /// <param name="mountain">Mountain that was updated</param>
        /// <param name="weather">Weather that was updated</param>
        public delegate void StoreUpdateAction(Mountain mountain, Weather weather);

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
        public WeatherStore() {
            weathers = new Dictionary<Mountain, Weather>();
        }

        /// <summary>
        /// 
        /// Sets a Mountain Weather
        /// 
        /// </summary>
        /// <param name="mountain">Mountain for which the weather is to be set</param>
        /// <param name="weather">Weather for the mountain</param>
        public void SetWeather(Mountain mountain, Weather weather) {
            this.weathers[mountain] = weather;

            if (OnStoreUpdate != null) {
                OnStoreUpdate(mountain, weather);
            }
        }

        /// <summary>
        /// 
        /// Returns a weather for the mountain
        /// 
        /// </summary>
        /// <param name="mountain">Mountain for which the weather is to be found</param>
        /// <returns>Weather for the mountain</returns>
        public Weather GetWeather(Mountain mountain) {
            return this.weathers[mountain];
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