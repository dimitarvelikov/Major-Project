using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public int highScore;
    public int coins;
    private string FilePath;

    // Use this for initialization
    private void Awake()
    {
        //Set the path to the OS's data folder
        FilePath = Path.Combine(Application.persistentDataPath, "save.txt");
        //load - the file
        Load();
    }

    //Saves the collected coins and updates the highscore if it is a new one
    public void Save(int coinsCollected, float currentScore)
    {
        coins += coinsCollected;
        if (highScore < (int)currentScore)
        {
            highScore = (int)currentScore;
        }

        string jsonString = JsonUtility.ToJson(this);
        File.WriteAllText(FilePath, jsonString);
    }
    public void Load()
    {
        //If the file is found read it and overwrite this class
        if (File.Exists(FilePath)){
            string jsonString = File.ReadAllText(FilePath);
            JsonUtility.FromJsonOverwrite(jsonString, this);
        }
        //If the file is not found then this is the first start of the game
        else { Debug.Log("File not Found - save.txt"); }
    }
}
