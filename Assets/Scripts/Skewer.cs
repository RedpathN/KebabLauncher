using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skewer : MonoBehaviour
{

    public bool isFired = false;
    public float speed = 5;

    Vector3 minPoint;
    Vector3 maxPoint;

    public float distance;

    private GameController gc;
    private Spawner spawner;

    public List<GameObject> skeweredObjects;

    // Update is called once per frame


    private void Start()
    {

        gc = FindObjectOfType<GameController>().GetComponent<GameController>();
        spawner = FindObjectOfType<Spawner>();
        minPoint = transform.GetChild(1).transform.position;
        maxPoint = transform.GetChild(2).transform.position;
        distance = Vector3.Distance(minPoint, maxPoint);
    }

    private void OnEnable()
    {
        skeweredObjects = new List<GameObject>();
    }

    void Update()
    {
        if(isFired)
        {
            transform.position += transform.rotation * (Vector3.forward * speed) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FoodItem")
        {


            collision.gameObject.GetComponent<MovementController>().isSkewered = true;
            skeweredObjects.Add(collision.gameObject);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();



            rb.detectCollisions = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;

            minPoint = transform.GetChild(1).transform.position;
            maxPoint = transform.GetChild(2).transform.position;
            Vector3 newPos = new Vector3(minPoint.x, minPoint.y, minPoint.z + ((distance / gc.recipeItemCount) * skeweredObjects.Count));

            collision.gameObject.transform.SetParent(gameObject.transform);
            collision.gameObject.transform.rotation = transform.rotation;
            collision.gameObject.transform.position = newPos;
            spawner.itemCount--;
        }

    }

}
