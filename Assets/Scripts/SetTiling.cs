using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTiling : MonoBehaviour
{
    private LineRenderer line;
    private ConveyorController cc;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        cc = GameObject.FindObjectOfType<ConveyorController>();
    }

    void Update()
    {
        line.material.SetTextureOffset("_MainTex", new Vector2(-Time.time, 0f));
        line.material.SetTextureScale("_MainTex", new Vector2(cc.conveyorLength * 3, 1f));
    }

}
