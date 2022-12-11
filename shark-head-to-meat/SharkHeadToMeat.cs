using HarmonyLib;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class SharkHeadToMeat : Mod
{
    public void Start()
    {
        CreateRecipe(ItemManager.GetItemByName("Raw_Shark"), 1);
        Debug.Log("Craftable Shark Meat has loaded!");
        allowItems("Raw_Shark");
    }
    private void allowItems(params string[] validItemNames)
    {


        var sharkheadItem = ItemManager.GetItemByName("Head_Shark");
        var sharkheadIngredient = new CostMultiple(new Item_Base[] { sharkheadItem }, 1);



        var sharkmeat = ItemManager.GetItemByName("Raw_Shark");
        sharkmeat.settings_recipe.NewCost = new CostMultiple[] { sharkheadIngredient };
    }
    /// <param name="pResultItem">Item resulting from the crafting.</param>
    public static void CreateRecipe(Item_Base pResultItem, int pAmount)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Resources);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public void OnModUnload()
    {
        Debug.Log("Shark Meat Crafting is unloaded!");
    }
}