using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    Vector3 spawn1;
    Vector3 spawn2;
    Vector3 spawn3;
    Vector3 spawn4;
    Vector3 spawn5;
    public GameObject zombie;
    public GameObject bigzombie;
    public GameObject armoredzombie;
    public GameObject fastzombie;
    int c;
    GameObject chosenzombie;
    


    void Start()
    {
        spawn1 = new Vector3(-47.15f,2.5f,-23.4f);
        spawn2 = new Vector3(-47.15f,2.5f,10.54f);
        spawn3 = new Vector3(-37.7f,2.5f,10.54f);
        spawn4 = new Vector3(-19.44f,2.5f,-5.23f);
        spawn5 = new Vector3(-37.91f,2.5f,-14.52f);
        InvokeRepeating("zombieSpawner",5f,20f);
        c=0;
    }
    void zombieSpawner()
    {
        zombieChooser();
        Instantiate(chosenzombie,spawn1,Quaternion.identity);
        zombieChooser();
        Instantiate(chosenzombie,spawn2,Quaternion.identity);
        zombieChooser();
        Instantiate(chosenzombie,spawn3,Quaternion.identity);
        zombieChooser();
        Instantiate(chosenzombie,spawn4,Quaternion.identity);
        zombieChooser();
        Instantiate(chosenzombie,spawn5,Quaternion.identity);
        c=c+1;
        if (c==8)
        {
            CancelInvoke("zombieSpawner");
            InvokeRepeating("zombieSpawner",15f,15f);
        }
        if (c==14)
        {
            CancelInvoke("zombieSpawner");
            InvokeRepeating("zombieSpawner",10f,10f);
        }
        if (c==25)
        {
            CancelInvoke("zombieSpawner");
            InvokeRepeating("zombieSpawner",7f,7f);
        }
    }
    
    void zombieChooser()
    {
        int num1 = Random.Range(1,101);
        if(num1>=1 && num1<=5)
        {
            chosenzombie = armoredzombie;
        }
        if(num1>=6 && num1<=15)
        {
            chosenzombie = bigzombie;
        }
        if(num1>=16 && num1<=70)
        {
            chosenzombie = zombie;
        }
        if(num1>=71 && num1<=100)
        {
            chosenzombie = fastzombie;
        }
    }
}
