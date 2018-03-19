using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0.0f;
    //private  int highScore;
	public Text scoreText;

	public bool isDead = false;


    private void Awake(){
  
        //read from file - highscore and other user data coins etc.
    }

	// Update is called once per frame
    private void Update ()
	{
        if (!isDead)
        {
            score += Time.deltaTime * 50;
            scoreText.text = ((int)score).ToString();
        }
	}
}
