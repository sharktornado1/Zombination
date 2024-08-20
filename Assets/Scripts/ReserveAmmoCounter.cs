using UnityEngine.UI;
using UnityEngine;

public class ReserveAmmoCounter : MonoBehaviour
{
    public shooting uziscript;
    public shooting akscript;
    public shooting shotgunscript;
    public Text reserveammotext;
    

    
    void Update()
    {
        
        if (GameManager.Instance.currentweapon == "uzi")
        {
            reserveammotext.text = uziscript.reserveAmmo.ToString();
        }
        if (GameManager.Instance.currentweapon == "ak")
        {
            reserveammotext.text = akscript.reserveAmmo.ToString();
        }
        if (GameManager.Instance.currentweapon == "pistol")
        {
            reserveammotext.text = "∞";
        }
        if (GameManager.Instance.currentweapon == "shotgun")
        {
            reserveammotext.text = shotgunscript.reserveAmmo.ToString();
        }
    }
}
