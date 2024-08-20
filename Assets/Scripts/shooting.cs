using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public Text reloadingtext;
    
    public Image gunicon;
    public Sprite pistolicon;
    Animator animator;
    public GameObject player;
    public GameObject pistol;
    public GameObject uzi;
    public GameObject ak;
    public GameObject shotgun;
    public string pooltag;
    public string shellpooltag;
    public string muzzleflashtag;
    public Transform Firepoint;
    public float bulletForce = 20f;
    public Joystick joystick;
    public JoyButtonScript joyButton;
    public float timePeriod = 0.3f;
    public float nextActionTime = 0.1f;
    public GameObject muzzlepoint;
    bool isshooting = false;

    public int maxAmmo = 10;
    public int currentAmmo;
    public int reserveAmmo = 1;
    public int maxreserveAmmo =1;
    public float reloadTime = 1.5f;
    public bool isReloading = false;
    
    Quaternion firepointRotation;
    
    Vector3 firepointPosition;
    public Transform shotgunfp1;
    public Transform shotgunfp2;
    public Transform shotgunfp3;
    public Transform shotgunfp4;



    void Start()
    {
        currentAmmo = maxAmmo;
        animator  = player.GetComponent<Animator>();
        maxreserveAmmo = reserveAmmo;
        string gname = gameObject.name;
    }
    void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        if (reserveAmmo == 0 && currentAmmo == 0)
        {
            CancelInvoke("Shoot");
            CancelInvoke("ShotgunShoot");
            isshooting = false;
            ak.SetActive(false);
            uzi.SetActive(false);
            pistol.SetActive(true);
            shotgun.SetActive(false);
            
            GameManager.Instance.currentweapon = "pistol";
            GameManager.Instance.secondaryweapon = "none";
            gunicon.sprite = pistolicon;

        }
        if (isReloading)
        {
            return;
        }
        if (currentAmmo<=0)
        {
            CancelInvoke("Shoot");
            CancelInvoke("ShotgunShoot");
            isshooting = false;
            StartCoroutine(Reload());
            return;
        }
        if (joyButton.isPressed && currentAmmo!=maxAmmo && reserveAmmo!=0)
        {
            CancelInvoke("Shoot");
            CancelInvoke("ShotgunShoot");
            isshooting = false;
            StartCoroutine(Reload());
            return;
        }
        if (isshooting==false)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                isshooting = true;
                if (gameObject.name == "Shotgun")
                {
                    InvokeRepeating("ShotgunShoot",nextActionTime,timePeriod);
                }
                else
                {
                    InvokeRepeating("Shoot",nextActionTime,timePeriod);
                }
                
                
            }
        }
        if (isshooting == true)
        {
            if (joystick.Horizontal == 0 && joystick.Vertical == 0)
            {
                CancelInvoke("Shoot");
                CancelInvoke("ShotgunShoot");
                isshooting = false;
            }
        }
        if (GameManager.Instance.orbreload == true)
        {          
            reserveAmmo = maxreserveAmmo;
            currentAmmo = maxAmmo;
            GameManager.Instance.orbreload = false;          
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("isReloading",true);
        reloadingtext.text = "Reloading...";
        yield return new WaitForSeconds(reloadTime);
        if (GameManager.Instance.currentweapon != "pistol")
        {
            int reloadamount = maxAmmo - currentAmmo;
            if (reserveAmmo >= reloadamount)
            {
                currentAmmo = currentAmmo + reloadamount;
                reserveAmmo = reserveAmmo - reloadamount;
            }
            else if(reserveAmmo > 0 && reserveAmmo < reloadamount)
            {
                currentAmmo = currentAmmo + reserveAmmo;
                reserveAmmo = 0;
            }
        }
        else
        {
            currentAmmo = maxAmmo;
        }
        isReloading = false;
        animator.SetBool("isReloading",false);
        reloadingtext.text = "";
    }
    void Shoot()
    {
        currentAmmo --;
        GameObject bullet = MyPooler.ObjectPooler.Instance.GetFromPool(pooltag,Firepoint.position,Firepoint.rotation);
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        firepointRotation = Firepoint.rotation;
        firepointRotation *= Quaternion.Euler(0, 270, 0);
        firepointPosition = muzzlepoint.transform.position;
        MyPooler.ObjectPooler.Instance.GetFromPool(muzzleflashtag,firepointPosition,firepointRotation);
        rb.AddForce(Firepoint.forward*bulletForce,ForceMode.Impulse);
        
    }
    void ShotgunShoot()
    {
        currentAmmo--;
        firepointRotation = Firepoint.rotation;
        firepointRotation *= Quaternion.Euler(0, 270, 0);
        firepointPosition = muzzlepoint.transform.position;
        GameObject bullet1 = MyPooler.ObjectPooler.Instance.GetFromPool(shellpooltag,Firepoint.position,Firepoint.rotation);
        GameObject bullet2 = MyPooler.ObjectPooler.Instance.GetFromPool(shellpooltag,Firepoint.position,Firepoint.rotation);
        GameObject bullet3 = MyPooler.ObjectPooler.Instance.GetFromPool(shellpooltag,Firepoint.position,Firepoint.rotation);
        GameObject bullet4 = MyPooler.ObjectPooler.Instance.GetFromPool(shellpooltag,Firepoint.position,Firepoint.rotation);
        Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
        Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
        Rigidbody rb3 = bullet3.GetComponent<Rigidbody>();
        Rigidbody rb4 = bullet4.GetComponent<Rigidbody>();
        MyPooler.ObjectPooler.Instance.GetFromPool(muzzleflashtag,firepointPosition,firepointRotation);
        rb1.AddForce(shotgunfp1.forward*bulletForce,ForceMode.Impulse);
        rb2.AddForce(shotgunfp2.forward*bulletForce,ForceMode.Impulse);
        rb3.AddForce(shotgunfp3.forward*bulletForce,ForceMode.Impulse);
        rb4.AddForce(shotgunfp4.forward*bulletForce,ForceMode.Impulse);
        

    }
}
