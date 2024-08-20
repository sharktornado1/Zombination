using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcollision : MonoBehaviour
{
    public GameObject hitEffect;
    public TrailRenderer trailRedn;
    public string pooltag;
    
    void OnCollisionEnter(Collision collision)
    {
        
        
        MyPooler.ObjectPooler.Instance.GetFromPool("hiteffect",transform.position,Quaternion.identity);
        
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        MyPooler.ObjectPooler.Instance.ReturnToPool(pooltag, this.gameObject);
        
        
    }
    void Update()
    {
        StartCoroutine(Destruct());
    }
    IEnumerator Destruct()
    {
        if(gameObject.name.Contains("ShotgunShells"))
        {
            yield return new WaitForSeconds(0.125f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        trailRedn.Clear();
        MyPooler.ObjectPooler.Instance.ReturnToPool(pooltag, this.gameObject);
    }
}
