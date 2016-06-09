using System.Collections;
using UnityEngine;

namespace TheHimalayas.Http {

    abstract public class HttpClient : MonoBehaviour {

        /// <summary>
        /// 
        /// URL string in which the request is to be sent.
        /// 
        /// </summary>
        private string url;

        /// <summary>
        /// 
        /// WWW Request Object.
        /// 
        /// </summary>
        private WWW request;

        /// <summary>
        /// 
        /// Delegate for Success HTTP Response.
        /// 
        /// </summary>
        /// <param name="text">Response Text</param>
        public delegate void SuccessResponse(string text);

        /// <summary>
        /// 
        /// Delegate for Error HTTP Response.
        /// 
        /// </summary>
        /// <param name="text"></param>
        public delegate void ErrorResponse(string text);

        /// <summary>
        /// 
        /// On Success Event.
        /// 
        /// </summary>
        public event SuccessResponse OnSuccess;

        /// <summary>
        /// 
        /// On Error Event.
        /// 
        /// </summary>
        public event ErrorResponse OnError;

        /// <summary>
        /// 
        /// Stores request URL to start a Request.
        /// 
        /// </summary>
        /// <param name="url">URL to which GET Reqeuest is to be sent.</param>
        /// <returns>HttpClient Object.</returns>
        public HttpClient CreateRequest(string url) {
            this.url = url;

            return this;
        }

        /// <summary>
        /// 
        /// Returns WWW Request Object.
        /// 
        /// </summary>
        /// <returns>WWW Request Object.</returns>
        public WWW GetRequest() {
            return this.request;
        }

        /// <summary>
        /// 
        /// Sends a Request to the defined URL.
        /// 
        /// </summary>
        public void SendRequest() {
            StartCoroutine(InvokeRequest());  
        }

        /// <summary>
        /// 
        /// Coroutine which Invokes a Request.
        /// 
        /// </summary>
        /// <returns>WWW IEnumerator.</returns>
        private IEnumerator InvokeRequest() {
            request = new WWW(this.url);

            yield return request;

            if (request.error != null) {
                RespondWithError(request.error);
            } else {
                Respond(request.text);
            }
        }

        /// <summary>
        /// 
        /// Calls error response listeners.
        /// 
        /// </summary>
        /// <param name="text">Error Response Text.</param>
        protected void RespondWithError(string text) {
            if(OnError != null) {
                OnError(text);
            }
        }

        /// <summary>
        /// 
        /// Calls success response listeners.
        /// 
        /// </summary>
        /// <param name="text">Success Reponse Text.</param>
        protected void Respond(string text) {
            if (OnSuccess != null) {
                OnSuccess(text);
            }
        }

        /// <summary>
        /// 
        /// Adds a success response listener.
        /// 
        /// </summary>
        /// <param name="listener">Success Response Listener</param>
        public void AddSuccessResponseListener(SuccessResponse listener) {
            this.OnSuccess += listener;
        }

        /// <summary>
        /// 
        /// Adds a error response listener.
        /// 
        /// </summary>
        /// <param name="listener">Error Response Listener</param>
        public void AddErrorResponseListener(ErrorResponse listener) {
            this.OnError += listener;
        }

        /// <summary>
        /// 
        /// Removes a success response listener.
        /// 
        /// </summary>
        /// <param name="listener">Listener to forget.</param>
        public void ForgetSuccessResponseListener(SuccessResponse listener) {
            this.OnSuccess -= listener;
        }

        /// <summary>
        /// 
        /// Removes an error respnose listener.
        /// 
        /// </summary>
        /// <param name="listener">Listener to forget.</param>
        public void ForgetErrorResponseListener(ErrorResponse listener) {
            this.OnError -= listener;
        }
    }
}