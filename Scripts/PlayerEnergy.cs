using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{

    private const float MAX_ENERGY = 100;
    public Slider currentSlider;
    //current_energy will be removed in later releases.
    //no point in keeping it since the value is stored in currentSlider.value
    private float current_energy;
    public bool isDead = false;


    private void Start()
    {
        current_energy = MAX_ENERGY;
        UpdateEnergySlider();
    }

    private void UpdateEnergySlider()
    {
        currentSlider.value = current_energy;
    }

    public void LoseEnergy(float amountEnergy)
    {
        if (current_energy > 0)
        {
            current_energy -= amountEnergy;
            UpdateEnergySlider();
        }
    }
    public void GainEnergy(float amountEnergy)
    {
        if (current_energy < 100)
        {
           // Debug.Log("Gain energy: "+currentSlider + " slider value: " + currentSlider.value);
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
    }

    private void Update()
    {
        if (!isDead)
        if (currentSlider.value > 0)
        {
           LoseEnergy(Time.deltaTime * 3);
           // LoseEnergy(20);
            UpdateEnergySlider();
        }
        else
        {
            //call that function and it will call OutOfEnergy otherwise endless loop
            GetComponent<Character>().Death();
        }
    }
    public void OutOfEnergy()
    {
        isDead=true;
        currentSlider.value = 0;
        current_energy = 0;
    }
}
