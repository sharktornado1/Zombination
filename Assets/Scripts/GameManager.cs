using UnityEngine;
public class GameManager : MonoBehaviour {
    public int Score=0;
    public string currentweapon = "pistol";
    public string secondaryweapon = "none";
    public string weaponspawnlocation = "none";
    public bool weaponspawned = false;
    public bool instakill = false;
    public int scorepopup = 0;
    public bool orbreload = false;
    public int turretlife = 30;
    public float instakilltimer = 20f;
    public GameObject instatimer;
     
     
     public static GameManager Instance { get; private set; }              
  
     void Awake()     {
         if (Instance == null) {Instance = this; } else if (Instance != this) {Destroy(this); }
         DontDestroyOnLoad(gameObject);
     }
     void Update()
     {
         if (instakill == true && instatimer.activeSelf == false)
         {
             instatimer.SetActive(true);
         }
     }
     /* <Future Code Goes Here> */
 }