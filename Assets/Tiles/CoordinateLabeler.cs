using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]  // This would allow to execute always, even in Edit mode
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();        
    }
    void Update()
    {
        if(!Application.isPlaying) //This will execute *only* in edit mode
        {   
            DisplayCoordinates();
            UpdateObjectName();            
        }
        
    }
    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(this.transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(this.transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
