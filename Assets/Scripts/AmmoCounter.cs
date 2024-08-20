using UnityEngine.UI;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public shooting pistolscript;
    public shooting akscript;
    public shooting uziscript;
    public shooting shotgunscript;
    public Text ammotext;
    

    
    void Update()
    {
        if (GameManager.Instance.currentweapon == "pistol")
        {
            ammotext.text = pistolscript.currentAmmo.ToString();
        }
        if (GameManager.Instance.currentweapon == "uzi")
        {
            ammotext.text = uziscript.currentAmmo.ToString();
        }
        if (GameManager.Instance.currentweapon == "ak")
        {
            ammotext.text = akscript.currentAmmo.ToString();
        }
        if (GameManager.Instance.currentweapon == "shotgun")
        {
            ammotext.text = shotgunscript.currentAmmo.ToString();
        }
    }
}
