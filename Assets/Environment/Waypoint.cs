using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    /*public bool GetIsPlaceable()  //Another option to exposing a variable is with a method.
    {
        return isPlaceable;
    }*/

    void OnMouseDown() 
    {
        if(isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            //Instantiate(towerPrefab, transform.position,Quaternion.identity);
            isPlaceable = !isPlaced;
        }
        
    }
}
