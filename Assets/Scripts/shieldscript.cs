using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscript : MonoBehaviour
{
    GameObject player;
    public int maxshieldhealth;
    public ZombieHealthBar shealthbar;
    public int shieldhealth;
    void Start()
    {
        player = GameObject.Find("Player");
        shieldhealth = maxshieldhealth;
        shealthbar.setzombmaxhealth(maxshieldhealth);
    }
    void shielddamage()
    {
        shieldhealth -=1;
        shealthbar.setzombhealth(shieldhealth);
        if(shieldhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag =="zombie")
        {
            InvokeRepeating("shielddamage",0.1f,0.5f);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.collider.tag == "zombie")
        {
            CancelInvoke("shielddamage");
        }
    }

    void LateUpdate()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 1f,player.transform.position.z);
    }
    
}
