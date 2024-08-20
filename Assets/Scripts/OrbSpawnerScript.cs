using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawnerScript : MonoBehaviour
{
    public GameObject AmmoOrb;
    public GameObject HealthOrb;
    public GameObject TurretOrb;
    public GameObject InstaOrb;
    public GameObject ShieldOrb;
    Vector3 shieldorbpos;


    public void DropOrb(Vector3 spawnpos)
    {
        int num1= Random.Range(1,101);
        if (num1>=1 && num1<=2)
        {
            Instantiate(AmmoOrb,spawnpos,Quaternion.identity);
        }
        if (num1>=3 && num1<=4)
        {
            Instantiate(HealthOrb,spawnpos,Quaternion.identity);
        }
        if (num1>=5 && num1<=6)
        {
            Instantiate(TurretOrb,spawnpos,Quaternion.identity);
        }
        if (num1>=7 && num1<=8)
        {
            Instantiate(InstaOrb,spawnpos,Quaternion.identity);
        }
        if (num1>=9 && num1<=10)
        {
            shieldorbpos =new Vector3(spawnpos.x,spawnpos.y + 0.5f,spawnpos.z);
            Instantiate(ShieldOrb,shieldorbpos,Quaternion.identity);
        }

    }
}
