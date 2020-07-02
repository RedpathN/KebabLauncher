using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skewer : MonoBehaviour
{

    public bool isFired = false;
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        if(isFired)
        {
            transform.position += transform.rotation * (Vector3.forward * speed) * Time.deltaTime;
        }
    }
}
