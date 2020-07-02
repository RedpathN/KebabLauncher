using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> conveyorPositions;
    public bool isLooping;

    public float conveyorLength = 0;
    public float speed = 1;

    private LineRenderer lr;

    private void Awake()
    {
        lr = GameObject.Find("ConveyorLine").GetComponent<LineRenderer>();
        lr.positionCount = isLooping ? conveyorPositions.Count + 1 : conveyorPositions.Count;
        for (int i = 0; i < conveyorPositions.Count; i++)
        {
            getPoint(i);
            lr.SetPosition(i, conveyorPositions[i % lr.positionCount].transform.position);
        }
    }


    void getPoint( int i )
    {
            Vector3 posA = conveyorPositions[i % conveyorPositions.Count].transform.position;
            Vector3 posB = conveyorPositions[(i + 1) % conveyorPositions.Count].transform.position;
            conveyorLength += Vector3.Distance(posA, posB);
    }

}
