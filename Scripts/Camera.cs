using UnityEngine;

public class Camera : MonoBehaviour {
	private Transform lookAt;
	private Vector3 cameraStartOffset;
	private Vector3 moveVector;
    private AudioListener audioListener;

	// Use this for initialization
    private void Start () {
       
        //lookAt is the position of the player character on the scene
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;

        //cameraStartOffSet is the difference between the position of the camera
        //and the position of the player on the scene
		cameraStartOffset = transform.position - lookAt.position;
    }
	
	// Update is called once per frame
    private	void Update () {
        //set the new position of the camera to be corresponding to the player position
        //add the offset
		moveVector = lookAt.position + cameraStartOffset;

        //set the camera position to be in the center pane
		moveVector.x = 0;

        //assign the moveVector position to the camera
		transform.position = moveVector;
	}
}
