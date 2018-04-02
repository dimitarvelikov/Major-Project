using UnityEngine;
using UnityEngine.UI;

public class ExploreCanvas : MonoBehaviour
{
    public Text description;
    public Texture[] allImages;
    public RawImage img;
    public Button leftBtn;
    public Button rightBtn;
    public RawImage leftArrow;
    public RawImage rightArrow;
    private int currentFish;
    private const int MAX_FISH = 9;

    // Use this for initialization
    private void Start()
    {
        gameObject.SetActive(false);
        currentFish = 0;
        img.texture = allImages[currentFish];
        leftBtn.onClick.AddListener(LeftBtnClick);
        rightBtn.onClick.AddListener(RightBtnClick);
    }

    public void LeftBtnClick()
    {
        if (currentFish > 0)
        {
            --currentFish;
            UpdateImgAndText();
            Debug.Log("left click, current fish is: " + currentFish);
        }
        else
        {
            Debug.Log("left click - current fish is: " + currentFish);
        }
    }

    public void RightBtnClick()
    {
        Debug.Log("right click inside");
        if (currentFish < MAX_FISH)
        {
            ++currentFish;
            UpdateImgAndText();
            Debug.Log("right click, current fish is: " + currentFish);
        }
        else
        {
            Debug.Log("right click - current fish is: " + currentFish);
        }
    }

    private string GetFishData(int fishNum)
    {
        switch (fishNum)
        {
            case 0:
                return "The great white shark, commonly known as the great white" +
                    " or the white shark, is a species of large mackerel shark " +
                    "which can be found in the coastal surface waters of all the" +
                    " major oceans.The great white shark is notable for its size," +
                    " with larger female individuals growing to 6.1 m (20 ft) in " +
                    "length and 1,905 kg (4,200 lb) in weight at maturity.";
            case 1:
                return "Lionfish are skilled hunters, using specialized bilateral" +
                    " swim bladder muscles to provide exquisite control of location" +
                    " in the water column, allowing the fish to alter its center of" +
                    " gravity to better attack prey. The lionfish then spreads its " +
                    "large pectoral fins and swallows its prey in a single motion.";
            case 2:
                return "Stingrays are a group of rays, which are cartilaginous fish" +
                    " related to sharks, and are one of the oceans deadliest creatures." +
                    " Most stingrays have one or more barbed stingers on their tails," +
                    " which are used exclusively for self-defense. ";
            case 3:
                return "The black jellyfish can be quite massive, with a bell diameter " +
                    "potentially up to 1 meter and oral arms extending to 5 or 6 meters." +
                    "The bell color is a distinctive opaque dark purple to nearly black.";
            case 4:
                return "five";
            case 5:
                return "six";
            case 6:
                return "seven";
            case 7:
                return "eight";
            case 8:
                return "nine";
            case 9:
                return "ten";
        }
        return "";
    }

    public void ImageClick()
    {
       // img.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        Debug.Log("image click");
    }

    private void UpdateImgAndText()
    {
        img.texture = allImages[currentFish];
        description.text = GetFishData(currentFish);
    }

}
