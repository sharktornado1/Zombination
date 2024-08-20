using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject uzi;
    public GameObject ak;
    public GameObject shotgun;
    public GameObject pistol;
    
    public Image gunicon;
    public Sprite uzisprite;
    public Sprite aksprite;
    public Sprite pistolsprite;
    public Sprite shotgunsprite;
    public JoyButtonScript switchbutton;
    bool isswitcing;
    void Start()
    {
        pistol.SetActive(true);
        isswitcing = false;
        gunicon.sprite = pistolsprite;
    }

    
    void Update()
    {
        if (isswitcing == true)
        {
            return;
        }
        if (switchbutton.isPressed)
        {
            SwitchFunction();
            StartCoroutine(waiter());
        }
        if (GameManager.Instance.currentweapon == "uzi" && uzi.activeSelf == false)
        {
            pistol.SetActive(false);
            ak.SetActive(false);
            shotgun.SetActive(false);
            uzi.SetActive(true);
            gunicon.sprite = uzisprite;
        }
        if (GameManager.Instance.currentweapon == "ak" && ak.activeSelf == false)
        {
            pistol.SetActive(false);
            uzi.SetActive(false);
            shotgun.SetActive(false);
            ak.SetActive(true);
            gunicon.sprite = aksprite;
        }
        if (GameManager.Instance.currentweapon =="shotgun" && shotgun.activeSelf == false)
        {
            pistol.SetActive(false);
            uzi.SetActive(false);
            ak.SetActive(false);
            shotgun.SetActive(true);
            gunicon.sprite = shotgunsprite;
        }
    
    }
    IEnumerator waiter()
    {
        isswitcing = true;
        yield return new WaitForSeconds(0.5f);
        isswitcing = false;
    }
    public void SwitchFunction()
    {
        string secondaryweapon = GameManager.Instance.secondaryweapon;
        string currentweapon = GameManager.Instance.currentweapon;
        

        if (pistol.activeSelf == true && secondaryweapon == "uzi")
        {
            pistol.SetActive(false);
            uzi.SetActive(true);
            GameManager.Instance.currentweapon = "uzi";
            gunicon.sprite = uzisprite;
        }
        else if (pistol.activeSelf == true && secondaryweapon == "ak")
        {
            pistol.SetActive(false);
            ak.SetActive(true);
            GameManager.Instance.currentweapon = "ak";
            gunicon.sprite = aksprite;
        }
        else if (pistol.activeSelf == true && secondaryweapon == "shotgun")
        {
            pistol.SetActive(false);
            shotgun.SetActive(true);
            GameManager.Instance.currentweapon = "shotgun";
            gunicon.sprite = shotgunsprite;
        }
        else if (pistol.activeSelf == false)
        {
            uzi.SetActive(false);
            ak.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(true);
            GameManager.Instance.currentweapon = "pistol";
            gunicon.sprite = pistolsprite;
        }
    }
}
