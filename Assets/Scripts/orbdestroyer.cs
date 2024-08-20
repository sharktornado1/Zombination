using System.Collections;
using UnityEngine;

public class orbdestroyer : MonoBehaviour
{
    public GameObject shockwave;
    public float instakilltime;
    public float orblifetime = 45f;
    public playerHealth healthscript;
    public WeaponSwitcher weaponSwitcher;
    public GameObject turret;
    public GameObject shield;
    GameObject player;
    
    
    void Start()
    {
        player = GameObject.Find("Player");
        
        healthscript = player.GetComponent<playerHealth>();
        Destroy(gameObject,orblifetime);
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),collision.collider);
            return;
        }
        Destroy(gameObject);

        
        Instantiate(shockwave,player.transform.position,Quaternion.identity);
        
        
        string gname = gameObject.name;
        if (gname.Contains("UziOrb2.0"))
        {
            GameManager.Instance.secondaryweapon = "uzi";
            GameManager.Instance.currentweapon = "uzi";
            GameManager.Instance.orbreload = true;
        }
        if (gname.Contains("AkOrb"))
        {
            GameManager.Instance.secondaryweapon = "ak";
            GameManager.Instance.currentweapon = "ak";
            GameManager.Instance.orbreload = true;
        }
        if (gname.Contains("HeartOrb"))
        {
            healthscript.maximisehealth();       
        }
        if (gname.Contains("ShieldOrb"))
        {           
            Instantiate(shield);
        }
        if (gname.Contains("TurretOrb"))
        {
            Instantiate(turret,transform.position,Quaternion.identity);
        }
        if (gname.Contains("ShotgunOrb"))
        {
            GameManager.Instance.secondaryweapon = "shotgun";
            GameManager.Instance.currentweapon = "shotgun";
            GameManager.Instance.orbreload = true;
        }
        if (gname.Contains("BulletOrb"))
        {
            GameManager.Instance.orbreload = true;
            
            if (GameManager.Instance.currentweapon == "pistol")
            {
                weaponSwitcher.SwitchFunction();
            }
            
            GameManager.Instance.orbreload = true;
        }
        if (name.Contains("InstaKillOrb"))
        {
            GameManager.Instance.instakill = true;
            
        }
    }
    
}
