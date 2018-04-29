using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsCanvas : MonoBehaviour
{
    //the variable is public in order to be successfully serialized
    public bool isChecked;
    public static float volume;
    public float volumeVal;
    private Toggle checkBox;
    private string FilePath;
    private Slider volumeSlider;

    // Use this for initialization
    void Start()
    {
        volume = 0;
        volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        checkBox = FindObjectOfType<Toggle>();
     
        //Assign the path of the OS's data folder to a variable
        FilePath = Path.Combine(Application.persistentDataPath, "settings.txt");

        //Load the state of the settings.txt to the game - overwrite the class
        Load();
        if (checkBox.isOn)
        {
            Debug.Log("on");
        }
        else if (!checkBox.isOn)
        {
            Debug.Log("off");
        }
        //Disable the canvas and its children on start
        //it is important to disable it after the toggle object is found
        gameObject.SetActive(false);
    }

    public void OnSliderValueChanged()
    {
        if (volumeSlider == null)
        {
            Debug.Log("Null");
        }
        else
        {
            volumeVal= volume = volumeSlider.value;
            Save();
        }
    }
    public void OnCanvasEnabled(){
        gameObject.SetActive(true);
        Load();

    }
    //When the checkbox is clicked update the application framerate and save its
    //value to a file
    public void OnTouchInput()
    {
        if (isChecked)
        {
            Application.targetFrameRate = 60;
            isChecked = false;
            Debug.Log("touch input: is checked - framerate 60");
        }
        else
        {
            Application.targetFrameRate = 30;
            isChecked = true;
            Debug.Log("touch input: is checked - framerate 30");
        }
        Save();
    }

    //This function saves the value of this class's instance variables to a file
    //serialization via JsonUtility
    private void Save()
    {
        string jsonString = JsonUtility.ToJson(this);
        Debug.Log("Saving: " + jsonString);
        File.WriteAllText(FilePath, jsonString);
    }

    private void Load()
    {
        //If the file exists
        if (File.Exists(FilePath))
        {
            //Read the file content and assign it to a string
            string jsonString = File.ReadAllText(FilePath);

            //Overwrite this class's instance variables with the string data
            JsonUtility.FromJsonOverwrite(jsonString, this);
            Debug.Log("Loading: " + jsonString);
            //Change the application target framerate
            //With a value corresponding to the checkbox status
            if (isChecked)
            {
                checkBox.isOn = true;
                Application.targetFrameRate = 30;
                volumeSlider.value = volume = volumeVal;
            }
            else
            {
                checkBox.isOn = false;
                Application.targetFrameRate = 60;
                volumeSlider.value = volume = volumeVal;
            }
        }
        else
        {
            //If the file doesn't exists this usually means that this is the
            //First execution of the game
            Debug.Log("loading: File not found - settings.txt");
            volumeSlider.value = volume = volumeVal = 0.5f;
        }
    }
}
