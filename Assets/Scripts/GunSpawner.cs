using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject akorb;
    public GameObject shotgunorb;
    public GameObject uziorb;
    public float timeforfirstgun;
    public float gunspawntime;
    void Start()
    {
        InvokeRepeating("SpawnWeapon",timeforfirstgun,gunspawntime);
    }
    void SpawnWeapon()
    {
        GameManager.Instance.weaponspawned = true;
        int num1 = Random.Range(1,4); //4 is not inclusive
        int num2 = Random.Range(1,4);
        if (num1 == 1f)
        {
            if (num2==1) //roadside
            {
                Instantiate(shotgunorb,new Vector3(-50.7f,2.958f,-8.248f),Quaternion.identity);
                
            }
            else if (num2 == 2)
            {
                Instantiate(uziorb,new Vector3(-51.77f,3.404f,-8.721f),Quaternion.identity);
                
            }
            else if (num2 == 3)
            {
                Instantiate(akorb,new Vector3(-50.56f,2.69f,-8.091f),Quaternion.identity);
                
            }
            GameManager.Instance.weaponspawnlocation = "Roadside stands";
        }
        if (num1 == 2) //graveyard
        {
            if (num2==1)
            {
                Instantiate(shotgunorb,new Vector3(-30f,2.711f,-18.6f),Quaternion.identity);
                
            }
            else if (num2 == 2)
            {
                Instantiate(uziorb,new Vector3(-30.59f,3.338f,-18.84f),Quaternion.identity);
                
            }
            else if (num2 == 3)
            {
                Instantiate(akorb,new Vector3(-29.824f,2.39f,-18.284f),Quaternion.identity);
                
            }
            GameManager.Instance.weaponspawnlocation = "Graveyard";
        }
        if (num1 == 3) //park Gazebo
        {
            if (num2==1)
            {
                Instantiate(shotgunorb,new Vector3(-19.227f,2.77f,8.88f),Quaternion.identity);
                
            }
            else if (num2 == 2)
            {
                Instantiate(uziorb,new Vector3(-20.337f,3.366f,8.53f),Quaternion.identity);
                
            }
            else if (num2 == 3)
            {
                Instantiate(akorb,new Vector3(-19.13f,2.789f,9.09f),Quaternion.identity);
                
            }
            GameManager.Instance.weaponspawnlocation = "Park Gazebo";
        }
    }
    
    
}
