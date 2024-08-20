using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destromuzzleflash : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destruct());
    }
    IEnumerator destruct()
    {
        yield return new WaitForSeconds(0.05f);
        MyPooler.ObjectPooler.Instance.ReturnToPool("muzzleflash",this.gameObject);
    }
}


