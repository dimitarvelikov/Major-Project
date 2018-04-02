using UnityEngine;

public class Camera : MonoBehaviour {
	private Transform lookAt;
	private Vector3 cameraStartOffset;
	private Vector3 moveVector;

	// Use this for initialization
    private void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		cameraStartOffset = transform.position - lookAt.position;
    }
	
	// Update is called once per frame
    private	void Update () {
		moveVector = lookAt.position + cameraStartOffset;
		moveVector.x = 0;
		transform.position = moveVector;
	}
}
