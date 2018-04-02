using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackground : MonoBehaviour {
    //http://bestanimations.com/Nature/Water/underwater-ocean-gif.gif
    //this is the gif used for the animation

    public Texture[] frames;
    public RawImage explosion;
    private float frameRate = 0.0666f;

    private int currentImage;
    // Use this for initialization

    private void Start()
    {
        currentImage = 0;
        InvokeRepeating("ChangeImage", 0.0666f, frameRate);
    }

    private void ChangeImage()
    {
        explosion.texture = frames[currentImage];
        currentImage += 1;
        if (currentImage > 14) currentImage = 0;
    }
}