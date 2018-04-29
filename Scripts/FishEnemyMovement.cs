using UnityEngine;

public class FishEnemyMovement : MonoBehaviour {
    
    public bool isTurtle;
    public bool isLionFish;
    public bool isOrca;
    public bool isStingray;

    private Vector3 movement;
  
    private void Start()
    {
        if (isTurtle){
            movement = new Vector3(-0.01f, 0, 0);
        }
        else if(isOrca || isOrca){
            movement = new Vector3(0, 0, -0.01f);
        }
        else if(isLionFish){
            movement = new Vector3(0, 0, -0.01f);
        }
        else if(isStingray){
            movement = new Vector3(0.01f, 0, 0); 
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(movement);
	}
}