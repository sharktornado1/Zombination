using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public GameObject player;
    
    public NavMeshAgent agent_;
    bool active = false;
    
    
    
    void Start()
    {
        player=GameObject.Find("Player");
    }

    void OnEnable()
    {
        active=true;
    }
    void OnDisable()
    {
        active = false;
    }
    
    void Update()
    {
        if(active == true)
        {
            agent_.SetDestination(player.transform.position);
        }
        
        
    }
}
