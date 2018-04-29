using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    private const float MAX_ENERGY = 100;
    public Slider currentSlider;
    private float current_energy;
    public bool isDead = false;

    // Use this for initialization
    private void Start()
    {
        //Set the initial energy value to max
        current_energy = MAX_ENERGY;

        //Update the energy slider with the max energy value
        UpdateEnergySlider();
    }

    //This function updates the UI Slider
    private void UpdateEnergySlider()
    {
        currentSlider.value = current_energy;
    }

    //Remove amountEnergy from the player's current energy
    public void LoseEnergy(float amountEnergy)
    {
        if (current_energy > 0)
        {
            current_energy -= amountEnergy;
            UpdateEnergySlider();
        }
    }

    //Add amountEnergy to the player's current energy
    public void GainEnergy(float amountEnergy)
    {
        if (current_energy + amountEnergy > 100)
        {
            current_energy = 100;
        }
        else
        {
            current_energy += amountEnergy;
        }
        UpdateEnergySlider();
    }

    // Update is called once per frame
    private void Update()
    {
        //if the player is not dead
        if (!isDead)
            if (currentSlider.value > 0)
            {
                //Lose 2 energy every second
                LoseEnergy(Time.deltaTime * 2);

                //Update the energy slider every frame
                UpdateEnergySlider();
            }
            else
            {
                //Call the Character.cs and it will call OutOfEnergy() function
                //otherwise endless loop
                GetComponent<Character>().Death();
            }
    }

    public void OutOfEnergy()
    {
        isDead = true;
        currentSlider.value = 0;
        current_energy = 0;
    }
}
