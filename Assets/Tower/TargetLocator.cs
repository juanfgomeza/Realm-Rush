using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;
    

    void Update()
    {
        FindClosestTarget();
        AimWeapon();    
    }
    
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        // This is intensive. If this game grows, put safeguards
        {
            float targetDistance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        
        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(this.transform.position,target.position);
        weapon.LookAt(target);
        Attack(targetDistance < range); // is this a good practice? or is more readable if I do the 'if' statement
        
    }

    void Attack(bool isActive)
    {
        ParticleSystem psWeapon =  weapon.GetComponentInChildren<ParticleSystem>();        
        var emissionModule = psWeapon.emission;
        emissionModule.enabled = isActive;
        
        
    }
}
