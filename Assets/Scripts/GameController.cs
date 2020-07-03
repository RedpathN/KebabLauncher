using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public List<GameObject> FoodItems;
    public List<GameObject> currentRecipe = new List<GameObject>();
    public Text recipeText;
    public Text correctText;
    private int correctRecipes = 0;

    public float speed = 5;
    public float itemSpacing = 0.5f;
    public int recipeItemCount;


    // Start is called before the first frame update
    void Start()
    {
        MakeRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeRecipe()
    {
        recipeText.text = "RECIPE: \n";
        currentRecipe.Clear();
        for(int i = 0; i < recipeItemCount; i++)
        {
            GameObject recipeItem = FoodItems[Random.Range(0, FoodItems.Count)];
            currentRecipe.Add(recipeItem);
            recipeText.text += "" + recipeItem.name + "\n";
        }
    }

    public void AddScore()
    {
        correctRecipes++;
        correctText.text = "Correct Recipes: " + correctRecipes;
    }

}
