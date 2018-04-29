using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
    
    public Text endOfGameScoreText;

	// Use this for initialization
    private	void Start () {
        //deactivate the Canvas at the start of the game
        gameObject.SetActive(false);
	}

    public void ToggleEndOfGameMenu(float score){
        //update the UI text with the player's score
        endOfGameScoreText.text = "Score: " + score.ToString();
    }
}
