using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] List<Waypoint> path = new List<Waypoint>();  //This Waypoint is used instead of tags, not relying on strings
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
        
    void Start()
    {
        
        StartCoroutine(FollowPath());  // look it up. It is a way to "yield" control of the processor.
        
    }
    
    IEnumerator FollowPath()  //IEnumerator is "something" enumerable
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;
            
            this.transform.LookAt(endPosition);
            
            while(travelPercent < 1f) 
            {
                travelPercent += Time.deltaTime * speed;
                this.transform.position = Vector3.Lerp(startPosition,endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
            
            //this.transform.position = waypoint.transform.position;
            //yield return new WaitForSeconds(waitTime);
        }
    }
}
