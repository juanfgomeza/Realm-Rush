using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitpoints = 0;
    
    void Start()
    {
        currentHitpoints = maxHitPoints;        
    }

  

    void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
    }

    void ProcessHit(GameObject other)
    {
        currentHitpoints--;        
        if(currentHitpoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
