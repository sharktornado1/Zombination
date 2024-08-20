using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class InstakillTimerScript : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.maxValue = GameManager.Instance.instakilltimer;
        slider.value = GameManager.Instance.instakilltimer;
    }
    void OnEnable()
    {
        
        slider.value = GameManager.Instance.instakilltimer;
        slider.value = slider.value - 1;
        InvokeRepeating("itimer",0f,1f);
    }

    void itimer()
    {
        
        slider.value = slider.value - 1;
        if(slider.value == 0f)
        {
            GameManager.Instance.instakill = false;
            gameObject.SetActive(false);
        }
    }

    
}
