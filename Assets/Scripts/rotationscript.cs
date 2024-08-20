
using UnityEngine;

public class rotationscript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,45*Time.deltaTime,0);
    }
}
