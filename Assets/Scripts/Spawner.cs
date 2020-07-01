using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> FoodItems;

    public float itemSpacing;
    public float itemCount;

    private ConveyorController cc;

    private float conveyorLength;
    private float spawnTimer = 0;

    private void Start()
    {

        cc = GameObject.FindObjectOfType<ConveyorController>();
        conveyorLength = cc.conveyorLength;

    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > itemSpacing && itemCount <= Mathf.Floor(conveyorLength / itemSpacing))
        {
            SpawnItem();
        }
        
    }

    private void SpawnItem()
    {
        Instantiate(FoodItems[Random.Range(0, FoodItems.Count)]);
        spawnTimer = 0;
        itemCount++;
        
    }


}
