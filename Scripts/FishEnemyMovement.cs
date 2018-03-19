using UnityEngine;

public class FishEnemyMovement : MonoBehaviour {

    private Vector3 movement;

    public bool isTurtle;
    public bool isCrownFish;
    public bool isButterflyFish;
    public bool isPenguin;
  
    private void Start()
    {
        if (isTurtle){
            movement = new Vector3(-0.01f, 0, 0);
        }
        else if(isCrownFish){
            
        }
        else if(isButterflyFish){
            
        }
        else if (isPenguin){
            
        }
    }

    // Update is called once per frame
    void Update () {
        // transform.Translate(-0.01f, 0, 0); //for turtle
      //  transform.Translate(movement);
	}
}