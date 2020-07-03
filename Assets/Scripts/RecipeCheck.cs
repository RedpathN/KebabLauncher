using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCheck : MonoBehaviour
{

    private GameController gc;
    int correctItems = 0;
    private void Start() => gc = GameObject.FindObjectOfType<GameController>();

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Skewer")
        {

            Skewer skewer = collision.gameObject.GetComponent<Skewer>();
            
            for(int i = 0; i < Mathf.Min(gc.recipeItemCount, skewer.skeweredObjects.Count); i++)
            {
                if(skewer.skeweredObjects[i].GetComponent<VegeType>().type == gc.currentRecipe[i].GetComponent<VegeType>().type)
                {
                    correctItems++;
                    if (correctItems >= gc.recipeItemCount)
                    {
                        Debug.Log("Recipe Made!");  
                        gc.MakeRecipe();
                        gc.AddScore();
                    }
                }
            }

            Destroy(collision.gameObject);
            correctItems = 0;

        }
    }
}
