
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health;
    int maxhealth;
    public GameObject destroyfx;
    public HealthBar healthBar;
    
    void Start()
    {
        healthBar.settingmaxhealth(health);
        maxhealth = health;
    }
    public void maximisehealth()
    {
        
        health = maxhealth;
        healthBar.SetHealth(health);
    }
    
    void healthminus()
    {
        health = health -1;
        healthBar.SetHealth(health);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag == "zombie")
            {
                InvokeRepeating("healthminus",0.1f,0.5f);                
            }
          
    }  
    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "zombie")
        {
            CancelInvoke("healthminus");
        }
    }
    void Update()
    {
        
        
        if (health<1)
        {
            Destroy(gameObject);
            Instantiate(destroyfx,transform.position,Quaternion.identity);
        }
   
    }
}
