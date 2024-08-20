
using UnityEngine;

public class trailrendererfix : MonoBehaviour
{
    public TrailRenderer tr;
    private void Awake()
    {
        tr.GetComponent<TrailRenderer>();
    }
    private void OnDisable()
    {
        tr.Clear();
    }

    
}
