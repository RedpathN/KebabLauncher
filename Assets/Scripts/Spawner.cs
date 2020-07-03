using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float itemCount;


    private GameController gc;
    private ConveyorController cc;

    private float conveyorLength;
    private float spawnTimer = 0;

    private void Start()
    {
        gc = GameObject.FindObjectOfType<GameController>();
        cc = GameObject.FindObjectOfType<ConveyorController>();
        conveyorLength = cc.conveyorLength;

    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > gc.itemSpacing && itemCount < Mathf.Floor(conveyorLength / gc.itemSpacing))
        {
            SpawnItem();
        }
        
    }

    private void SpawnItem()
    {
        Instantiate(gc.FoodItems[Random.Range(0, gc.FoodItems.Count)]);
        spawnTimer = 0;
        itemCount++;
        
    }


}
