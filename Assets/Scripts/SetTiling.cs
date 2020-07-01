using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTiling : MonoBehaviour
{

    private ConveyorController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindObjectOfType<ConveyorController>();
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(cc.conveyorLength, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
