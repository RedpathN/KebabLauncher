using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{

    public float rotationSpeed = 30;
    public GameObject skewer;
    GameObject skewer_inst;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSkewer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(new Vector3(0,-rotationSpeed*Time.deltaTime,0));
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(new Vector3(0,rotationSpeed*Time.deltaTime,0));
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireSkewer();
            SpawnSkewer();
        }
    }

    void FireSkewer()
    {
        skewer_inst.transform.parent = null;
        skewer_inst.GetComponent<Skewer>().isFired = true;
    }

    void SpawnSkewer()
    {
        skewer_inst = Instantiate(skewer, transform.position, transform.rotation);
        skewer_inst.transform.SetParent(gameObject.transform);
    }
}
