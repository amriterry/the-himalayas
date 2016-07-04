using UnityEngine;
using System.Collections;

public class MountainSceneNavigator : MonoBehaviour {

    /// <summary>
    /// 
    /// Look At Target during rotation
    /// 
    /// </summary>
    private Transform lookAtTarget;

    /// <summary>
    /// 
    /// One Finger Rotation gesture recognizer
    /// 
    /// </summary>
    private TKOneFingerRotationRecognizer recognizer;

    // When the script awakes
    void Awake() {
        lookAtTarget = transform.GetChild(0).transform;
    }

    // Use this for initialization
    void Start() {
        AddRotationRecognizer();
    }
	
	// Update is called once per frame
	void AddRotationRecognizer () {
        recognizer = new TKOneFingerRotationRecognizer();

        recognizer.gestureRecognizedEvent += RotateScene;

        TouchKit.addGestureRecognizer(recognizer);
    }

    /// <summary>
    /// 
    /// Event Listener for One Finger Rotation
    /// 
    /// </summary>
    /// <param name="r">Rotation data</param>
    void RotateScene(TKOneFingerRotationRecognizer r) {
        Camera.main.transform.RotateAround(lookAtTarget.position, Vector3.up, r.deltaRotation);
    }

    // When the script gets destroyed
    void OnDestroy() {
        recognizer.gestureRecognizedEvent -= RotateScene;
    }
}
