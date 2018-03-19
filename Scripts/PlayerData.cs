using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour {
    public int highScore;
    public int coins;
    private string FilePath;

    // Use this for initialization
    private void Awake()
    {
        FilePath = Path.Combine(Application.persistentDataPath, "save.txt");
        Load();
        Debug.Log("Loaded highscore: " + highScore + ", coins: " + coins);
    }
  //  void Start () {
		//load
        //path combine takes the application path and takes the desired filename to store the data
        //it is important to use it because takes into account the platform that is being used
        //for example if we use app.datapath/save.txt, this may work for Windows
        //but not for Unix/MacOS because of the / \ differences etc.
       // FilePath = Path.Combine(Application.dataPath, "save.txt");
//	}
    public void Save(int coinsCollected, float currentScore)
    {
        coins += coinsCollected;
        if(highScore<(int)currentScore){
            highScore = (int)currentScore;
        }
        Debug.Log("saved highscore: " + highScore + " coins: " + coins);
        string jsonString = JsonUtility.ToJson(this);
        File.WriteAllText(FilePath, jsonString);
    }
    public void Load(){

        string jsonString = File.ReadAllText(Path.Combine(Application.persistentDataPath, "save.txt"));
        JsonUtility.FromJsonOverwrite(jsonString,this);
    }
}
