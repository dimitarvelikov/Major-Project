using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0.0f;
	public Text scoreText;
	public bool isDead = false;

	// Update is called once per frame
    private void Update ()
	{
        //If the player is not dead
        if (!isDead)
        {
            //Slightly increase the score value every frame
            score += Time.deltaTime * 50;

            //Update the Score UI text element 
            //Typecast to int to remove the floating point
            //Then convert to string because UI text value can be only a string.
            scoreText.text = ((int)score).ToString();
        }
	}
}
