using UnityEngine.UI;
using UnityEngine;

public class ZombieHealthBar : MonoBehaviour
{
    public Slider slider;
    public void setzombmaxhealth(float zombhealth)
    {
        slider.maxValue = zombhealth;
        slider.value = zombhealth;
    }

    
    public void setzombhealth(float zombhealth)
    {
        slider.value = zombhealth;
    }
}
