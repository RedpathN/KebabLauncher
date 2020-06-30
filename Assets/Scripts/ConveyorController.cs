using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> conveyorPositions;
    public bool isLooping;

    private LineRenderer lr;

    private void Awake() => lr = GameObject.Find("ConveyorLine").GetComponent<LineRenderer>();

    private void Start()
    {
        lr.positionCount = isLooping ? conveyorPositions.Count + 1 : conveyorPositions.Count;
        for(int i = 0; i < conveyorPositions.Count; i++)
        {
            
            lr.SetPosition(i, conveyorPositions[ i % lr.positionCount].transform.position);
        }
        
    }
}
