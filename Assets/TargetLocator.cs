using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
        //weapon = this.transform.GetChild(1);

    }

    void Update()
    {
        AimWeapon();    
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
