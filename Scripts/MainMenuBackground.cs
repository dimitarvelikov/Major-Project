using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackground : MonoBehaviour {
    //http://bestanimations.com/Nature/Water/underwater-ocean-gif.gif
    //this is the gif used for the animation

    public Texture[] frames;
    public RawImage explosion;
    private float frameRate;
    private const int LAST_IMAGE = 14;

    private int currentImage;

    // Use this for initialization
    private void Start()
    {
        //The first image is 0
        currentImage = 0;

        //ChangeImage function call time
        frameRate = 0.0666f;

        //Repeat the images endlessly on every 66 milliseconds
        InvokeRepeating("ChangeImage", frameRate, frameRate);
    }

    //Changes the image, updates the current image value
    //if the current image is last_image reset the animation
    private void ChangeImage()
    {
        explosion.texture = frames[currentImage];
        currentImage += 1;
        if (currentImage > LAST_IMAGE) currentImage = 0;
    }
}