using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour {
    public Text highscoreText;
    private void Start(){
        GetComponent<PlayerData>().Load();
        highscoreText.text = "Highscore " +  GetComponent<PlayerData>().highScore;
    }
}
