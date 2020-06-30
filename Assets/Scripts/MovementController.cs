using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed = 5;

    private bool onConveyor = false;
    private int checkpoint = 0;
    private float progress;

    private ConveyorController cc;

    private Vector3 posA;
    private Vector3 posB;
    private float pointDist;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindObjectOfType<ConveyorController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Conveyor")
        {
            getPoints();
            onConveyor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Conveyor")
        {
            onConveyor = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onConveyor)
        {
            progress += (1/pointDist) * (speed * Time.fixedDeltaTime);
            gameObject.transform.position = Vector3.Lerp(posA, posB, progress );
            if(progress >= 1)
            {
                checkpoint++;
                if(cc.isLooping || checkpoint < cc.conveyorPositions.Count - 1)
                {
                    getPoints();
                }
                
                    
            }
        }

    }

    void getPoints() 
    {
        progress = 0;
        pointDist = 0;
        posA = cc.conveyorPositions [checkpoint % cc.conveyorPositions.Count].transform.position;
        posB = cc.conveyorPositions [(checkpoint + 1) % cc.conveyorPositions.Count].transform.position;
        pointDist = Vector3.Distance(posA, posB);
    }
}
