using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    GameObject cam;
    Transform camtr;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        camtr = cam.GetComponent<Transform>();
    }

    
    void LateUpdate()
    {
        transform.LookAt(transform.position + camtr.forward);
    }
}
