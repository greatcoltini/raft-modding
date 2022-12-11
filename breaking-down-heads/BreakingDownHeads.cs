using HarmonyLib;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class BreakingDownHeads : Mod
{

    // initialize lists for recipe and costs
    string[] recipeCosts ={"Head_Shark", "Head_Warthog", "Head_Screecher"};
    string[] recipes = {"Raw_Shark", "Leather", "Raw_Drumstick"};

    public void Start()
    {
        GenerateRecipes();
        Debug.Log("Breaking Down Heads has loaded!");
    }


    private void allowItems(string costItem, string produceItem)
    {
        var costItemIngredient = new CostMultiple(new Item_Base[] { ItemManager.GetItemByName(costItem) }, 1);

        var produceItemM = ItemManager.GetItemByName(produceItem);
        produceItemM.settings_recipe.NewCost = new CostMultiple[] { costItemIngredient };
    }


    // Recipes method
    public void GenerateRecipes()
    {
        for (int i = 0; i < 2; i++)
        {
            CreateRecipe(ItemManager.GetItemByName(recipes[i]), 1);
            allowItems(recipeCosts[i], recipes[i]);
        }
    }


    /// <param name="pResultItem">Item resulting from the crafting.</param>
    public static void CreateRecipe(Item_Base pResultItem, int pAmount)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Resources);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }


    public void OnModUnload()
    {
        Debug.Log("Breaking Down Heads is unloaded!");
    }
}