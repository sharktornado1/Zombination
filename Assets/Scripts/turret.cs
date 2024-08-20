using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform target;
    public Transform pointToRotate;
    public string pooltag;
    bool isturretshooting = false;
    public string muzzleflashtag;
    public Transform Firepoint;
    public Transform muzzlepoint;
    public float range = 5f;
    public float bulletForce = 20f;
    public string enemytag = "zombie";
    Vector3 firepointPosition;
    Quaternion firepointRotation;
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestdistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distancetoenemy = Vector3.Distance(transform.position,enemy.transform.position);
            if (distancetoenemy < shortestdistance)
            {
                shortestdistance = distancetoenemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestdistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {
        if (target == null)
        {
            CancelInvoke("TurretShoot");
            isturretshooting = false;
            return;
        }
        

        Vector3 dir =  target.position - transform.position;
        Quaternion Lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Lookrotation.eulerAngles;
        pointToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
        if (isturretshooting == false)
        {
            InvokeRepeating("TurretShoot",0f,0.75f);
            isturretshooting = true;
        }
        

    }
    void TurretShoot()
    {
        GameObject bullet = MyPooler.ObjectPooler.Instance.GetFromPool(pooltag,Firepoint.position,Firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        firepointRotation = Firepoint.rotation;
        firepointRotation *= Quaternion.Euler(0, 270, 0);
        firepointPosition = muzzlepoint.transform.position;
        MyPooler.ObjectPooler.Instance.GetFromPool(muzzleflashtag,firepointPosition,firepointRotation);
        rb.AddForce(Firepoint.forward*bulletForce,ForceMode.Impulse);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
