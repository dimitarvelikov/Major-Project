using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	private Transform lookAt;
	private Vector3 cameraStartOffset;
	private Vector3 moveVector;
	// Use this for initialization
    private void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		cameraStartOffset = transform.position - lookAt.position;
      //  RenderSettings.fog=true;
    //    RenderSettings.fogColor = new Color(0.22f, 0.65f, 0.75f, 0.5f);
      //  RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
     //   RenderSettings.fogDensity = 0.03f;
    }
	
	// Update is called once per frame
    private	void Update () {
		moveVector = lookAt.position + cameraStartOffset;
		moveVector.x = 0;
		transform.position = moveVector;
	}
}
