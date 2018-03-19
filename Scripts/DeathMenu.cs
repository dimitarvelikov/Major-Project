using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
    
    public Text endOfGameScoreText;

	// Use this for initialization
    private	void Start () {
        
        gameObject.SetActive(false);
	}

    public void ToggleEndOfGameMenu(float score){
   //     GetComponent<RawImage>().color=new Color32(0, 0, 0, 255);
        endOfGameScoreText.text = "Score: " + score.ToString();
    }
}
