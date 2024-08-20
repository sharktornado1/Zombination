using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapondroptextscript : MonoBehaviour
{
    public Text weapondroptext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.weaponspawned == true)
        {


            weapondroptext.text = ("Weapon supply spotted at " + GameManager.Instance.weaponspawnlocation);
            GameManager.Instance.weaponspawned = false;
            StartCoroutine(removetext());
        }
    }
    IEnumerator removetext()
    {
        yield return new WaitForSeconds(5f);
        weapondroptext.text = "";
    }
}
