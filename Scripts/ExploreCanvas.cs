using UnityEngine;
using UnityEngine.UI;

public class ExploreCanvas : MonoBehaviour
{
    public Text description;
    public Texture[] allImages;
    public RawImage img;
    public RawImage leftArrow;
    public RawImage rightArrow;

    private int currentFish;
    private const int MAX_FISH = 8;


    // Use this for initialization
    private void Start()
    {
        //disable the canvas at the beginning of the game
        gameObject.SetActive(false);

        //Set the current animal value to 0
        currentFish = 0;

        //set texture and text
        UpdateImgAndText();
        SwitchArrows();
    }

    //Change the texture and text
    public void LeftBtnClick()
    {
        if (currentFish > 0)
        {
            --currentFish;
            UpdateImgAndText();
            SwitchArrows();
        }
    }

    //Change the texture and text
    public void RightBtnClick()
    {
        if (currentFish < MAX_FISH)
        {
            ++currentFish;
            UpdateImgAndText();
            SwitchArrows();
        }
    }

    //Hardcoted text for each of the water animals
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
                return "Orca is a toothed whale belonging to the oceanic dolphin family, " +
                    "of which it is the largest member. They have a diverse diet, although " +
                    "individual populations often specialize in particular types of prey. " +
                    "Some feed exclusively on fish, while others hunt marine mammals such " +
                    "as sharks, seals and dolphins. Killer whales are found in all oceans " +
                    "and most seas. Due to their enormous range, numbers, and density, " +
                    "distributional estimates are difficult to compare, but they" +
                    " clearly prefer higher latitudes and coastal areas over pelagic environments.";
            case 5:
                return "Clownfish (Anemonefish) are native to warmer waters of the Indian and Pacific Oceans," +
                    " including the Great Barrier Reef and the Red Sea. While most species have " +
                    "restricted distributions, others are widespread. Anemonefish live at the " +
                    "bottom of shallow seas in sheltered reefs or in shallow lagoons. Anemonefish are omnivorous and " +
                    "primarily feed on small zooplankton.";
            case 6:
                return "The green sea turtle inhabits tropical and subtropical seas around the world," +
            " with two distinct populations in the Atlantic and Pacific Oceans, but it is" +
            " also found in the Indian Ocean. Like other sea turtles, green sea turtles migrate" +
            " long distances between feeding grounds and hatching beaches. Many islands " +
            "worldwide are known as Turtle Island due to green sea turtles nesting on their" +
            " beaches. Females crawl out on beaches, dig nests and lay eggs during the night." +
            " Later, hatchlings emerge and scramble into the water. Those that reach maturity" +
            " may live to 80 years in the wild.";
            case 7:
                return "Sea urchins are spiny, globular animals. About 950 species inhabit all oceans," +
                    " and zones from the intertidal to 5,000 metres deep. Their tests (hard shells)" +
                    " are round and spiny, typically from 3 to 10 cm (1.2 to 3.9 in) across. " +
                    "Sea urchins move slowly, crawling with their tube feet, and defended by" +
                    " their sharp spines, which are sometimes toxic. They feed primarily on " +
                    "algae but also eat slow-moving or sessile animals. Their predators " +
                    "include sea otters, starfish, wolf eels, and triggerfish.";
            case 8:
                return "Starfish are marine invertebrates that typically have a central" +
                    " disc and five arms. Their upper surface may be smooth, granular or spiny, and is " +
                    "covered with overlapping plates. Many species are brightly coloured in " +
                    "various shades of red, orange, while, blue, grey or brown. " +
                    "Starfish have tube feet operated by a hydraulic system and a mouth at" +
                    " the centre of the oral or lower surface. They are opportunistic feeders" +
                    " and are mostly predators on benthic invertebrates. They can reproduce both" +
                    " sexually and asexually. Most can regenerate damaged parts or lost arms.";
            default:
                return "";
        }
    }

    //Changes the UI Texture and UI Text
    private void UpdateImgAndText()
    {
        img.texture = allImages[currentFish];
        description.text = GetFishData(currentFish);
    }
    private void SwitchArrows()
    {
        if (currentFish == 0)
        {
            leftArrow.gameObject.SetActive(false);
        }
        else
        {
            leftArrow.gameObject.SetActive(true);
        }
        if (currentFish == MAX_FISH)
        {
            rightArrow.gameObject.SetActive(false);
        }
        else
        {
            rightArrow.gameObject.SetActive(true);
        }
    }

}
