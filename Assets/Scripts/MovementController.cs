using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private bool onConveyor = false;
    private int checkpoint = 0;
    private float progress;

    private ConveyorController cc;

    private Vector3 posA;
    private Vector3 posB;
    private float pointDist;
    public bool isSkewered = false;

    private GameController gc;

    private int numPos;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindObjectOfType<GameController>();
        cc = GameObject.FindObjectOfType<ConveyorController>();
        numPos = cc.conveyorPositions.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Conveyor")
        {
            SetNext();
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
        if (onConveyor && !isSkewered)
        {
            progress += (1/pointDist) * (gc.speed * Time.fixedDeltaTime);
            gameObject.transform.position = Vector3.Lerp(posA, posB, progress );
            if(progress >= 1)
            {
                checkpoint++;
                if(cc.isLooping || checkpoint < numPos - 1)
                {
                    SetNext();
                }
                
                    
            }
        }

    }

    void SetNext()
    {
        posA = cc.conveyorPositions[checkpoint % numPos].transform.position;
        posB = cc.conveyorPositions[(checkpoint + 1) % numPos].transform.position;
        //Debug.Log(checkpoint % numPos + ":" + (checkpoint + 1) % numPos);
        pointDist = Vector3.Distance(posA, posB);
        progress = 0;
    }

}
