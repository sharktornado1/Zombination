using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TurretTimerScript : MonoBehaviour
{
    public Slider slider;
    public GameObject turret;
    public GameObject destroyfx;
    void Start()
    {
        slider.maxValue = GameManager.Instance.turretlife;
        slider.value = GameManager.Instance.turretlife;
        InvokeRepeating("timer",0f,1f);
        StartCoroutine(destroyturret());
    }

    void timer()
    {
        slider.value = slider.value -1;
    }
    void Update()
    {
        
    }
    IEnumerator destroyturret()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(destroyfx,turret.transform.position,Quaternion.identity);
        Destroy(turret,0f);
        
    }
}
