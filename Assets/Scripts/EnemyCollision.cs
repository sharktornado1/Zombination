using System.Collections;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int maxhealth;
    
    public float health;
    public int bigzombscore;
    public int armorzombscore;
    public int fastzombscore;
    bool isinstakill;
    public int zombscore;
    bool isRed;
    public Material normalmaterial;
    public Material damagedmaterial;
    public ZombieHealthBar zHealthBar;
    public OrbSpawnerScript orbSpawnerScript;
    public GameObject destroyfx;
    Vector3 pos;
    Quaternion Rotation;
    
    
    void Start()
    {
        pos = gameObject.transform.position;
        
        health = maxhealth;
        if (gameObject.name.Contains("Big Zombie") || gameObject.name.Contains("ArmoredZombie"))
           {
               zHealthBar.setzombmaxhealth(maxhealth);
           }
        

        
    }
    
    void OnCollisionEnter(Collision collision)
   {
       
       if(isRed == true)
       {
           return;
       }
          
       
       if (collision.collider.tag == "Bullet")
       {
           health = health - 1;

           
           StartCoroutine(RedFlash());
           if (gameObject.name.Contains("Big Zombie") || gameObject.name.Contains("ArmoredZombie"))
           {
               zHealthBar.setzombhealth(health);
           }
           

       }
       if (collision.collider.tag == "UziBullet")
       {
           health = health - 0.75f;
           
           StartCoroutine(RedFlash());
           if (gameObject.name.Contains("Big Zombie") || gameObject.name.Contains("ArmoredZombie"))
           {
               zHealthBar.setzombhealth(health);
           }
       }
       if (collision.collider.tag == "ShotgunShell")
       {
           health = health - 4f;
           
           
           StartCoroutine(RedFlash());
           if (gameObject.name.Contains("Big Zombie") || gameObject.name.Contains("ArmoredZombie"))
           {
               zHealthBar.setzombhealth(health);
           }
       }



       if (collision.collider.tag == "zombie")
       {
           Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),collision.collider);
       }
    
   }
   
   void Update()
   {
       
       
       
       if(isRed == true)
       {
           return;
       }
       
       
       if(health<=0)
       {
           string gname = gameObject.name;
           Vector3 deadpos = gameObject.transform.position;
           orbSpawnerScript.DropOrb(deadpos);
           if (gname.Contains("Big Zombie"))
           {
               GameManager.Instance.Score += bigzombscore;
               GameManager.Instance.scorepopup = bigzombscore;
               
           }
           else if (gname.Contains("ArmoredZombie"))
           {
               GameManager.Instance.Score += armorzombscore;
               GameManager.Instance.scorepopup = armorzombscore;
               
           }
           else if (gname.Contains("FastZombie"))
           {
               GameManager.Instance.Score += fastzombscore;
               GameManager.Instance.scorepopup = fastzombscore;
               
           }
           else
           {
               GameManager.Instance.Score += 10;
               GameManager.Instance.scorepopup = 10;
               
           }
           health = maxhealth;
           Rotation = gameObject.transform.rotation;
           Rotation *= Quaternion.Euler(0, 90, 0);
           Instantiate(destroyfx,gameObject.transform.position,Rotation);
           gameObject.transform.position = new Vector3(0,-2,0);
           Destroy(gameObject,0.1f);
        }
        
        
        if(GameManager.Instance.instakill == true && isinstakill == false)
        {
            StartCoroutine(instakill());
        }
   }
   IEnumerator RedFlash()
   {
       isRed = true;
       GameObject cubechild = this.gameObject.transform.GetChild(1).gameObject;
       var MatRenderer = cubechild.GetComponent<Renderer>();      
       MatRenderer.material = damagedmaterial;
       yield return new WaitForSeconds(0.1f);
       MatRenderer.material = normalmaterial;
       isRed = false;  
   }
   IEnumerator instakill()
   {
       isinstakill = true;
       
       float lasthealth = health;
       health = 0.1f;
       yield return new WaitForSeconds(GameManager.Instance.instakilltimer);
       health = lasthealth;
       isinstakill = false;
       GameManager.Instance.instakill = false;

   }
   
}
