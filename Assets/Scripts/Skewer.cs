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
    public float itemSize = 0.4f;

    private GameController gc;
    private Spawner spawner;

    public List<GameObject> skeweredObjects;

    // Update is called once per frame


    private void Start()
    {

        gc = FindObjectOfType<GameController>().GetComponent<GameController>();
        spawner = FindObjectOfType<Spawner>();
        minPoint = transform.GetChild(1).transform.localPosition;
        maxPoint = transform.GetChild(2).transform.localPosition;
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
            

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.detectCollisions = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;

            skeweredObjects.Add(collision.gameObject);
            collision.gameObject.transform.SetParent(gameObject.transform);

            UpdateFoodPos();
            spawner.itemCount--;
        }

    }

    void UpdateFoodPos()
    {
        foreach(GameObject foodItem in skeweredObjects){
            
            Vector3 newPos = new Vector3(minPoint.x, minPoint.y, minPoint.z - (itemSize * skeweredObjects.IndexOf(foodItem)));
            foodItem.transform.localPosition = newPos;
        }

    }

}
