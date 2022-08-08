using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;

    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);  
        
    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();
        if(resetPath)
        {
            coordinates = pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        
        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());  // look it up. It is a way to "yield" control of the processor.
        
        
    }
    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);

    }

    void FinishPath()
    {
        enemy.StealGold();
        this.gameObject.SetActive(false);
    }

    IEnumerator FollowPath()  //IEnumerator is "something" enumerable
    {
        for(int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            
            this.transform.LookAt(endPosition);
            
            while(travelPercent < 1f) 
            {
                travelPercent += Time.deltaTime * speed;
                this.transform.position = Vector3.Lerp(startPosition,endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
             
    }
}
