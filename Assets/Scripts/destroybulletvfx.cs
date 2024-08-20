using System.Collections;
using UnityEngine;

public class destroybulletvfx : MonoBehaviour
{
    

    void Update()
    {
        StartCoroutine(destroy());
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1f);
        MyPooler.ObjectPooler.Instance.ReturnToPool("hiteffect",this.gameObject);
    }
}
