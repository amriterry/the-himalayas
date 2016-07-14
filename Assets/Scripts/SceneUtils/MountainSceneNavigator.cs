using UnityEngine;
using TheHimalayas.Input;

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
    public OneFingerRotationGestureInput recognizer;

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
        recognizer.OnRotationDetected += RotateScene;
    }

    /// <summary>
    /// 
    /// Event Listener for One Finger Rotation
    /// 
    /// </summary>
    /// <param name="r">Rotation data</param>
    void RotateScene(float deltaRotation) {
        Camera.main.transform.RotateAround(lookAtTarget.position, Vector3.up, deltaRotation);
    }

    // When the script gets destroyed
    void OnDestroy() {
        recognizer.OnRotationDetected -= RotateScene;
    }
}
