using HarmonyLib;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class BreakingDownHeads : Mod
{
    public void Start()
    {
        // create the recipes
        CreateRecipe(ItemManager.GetItemByName("Raw_Shark"), 1);
        CreateRecipe(ItemManager.GetItemByName("Leather"), 1);
        CreateRecipe(ItemManager.GetItemByName("Raw_Drumstick"), 1);
        CreateRecipe(ItemManager.GetItemByName("Head_PoisonPuffer"), 1);

        Debug.Log("Breaking Down Heads has loaded!");

        allowItems("Raw_Shark", "Leather", "Raw_Drumstick", "Head_PoisonPuffer");
    }
    private void allowItems(params string[] validItemNames)
    {

        var sharkheadItem = ItemManager.GetItemByName("Head_Shark");
        var sharkheadIngredient = new CostMultiple(new Item_Base[] { sharkheadItem }, 1);
        var sharkmeat = ItemManager.GetItemByName("Raw_Shark");
        sharkmeat.settings_recipe.NewCost = new CostMultiple[] { sharkheadIngredient };

        var warthogheadItem = ItemManager.GetItemByName("Head_Boar");
        var warthogheadIngredient = new CostMultiple(new Item_Base[] { warthogheadItem }, 1);
        var leather = ItemManager.GetItemByName("Leather");
        leather.settings_recipe.NewCost = new CostMultiple[] { warthogheadIngredient };

        var screecherheadItem = ItemManager.GetItemByName("Head_Screecher");
        var screecherheadIngredient = new CostMultiple(new Item_Base[] { screecherheadItem }, 1);
        var raw_drumstick = ItemManager.GetItemByName("Raw_Drumstick");
        raw_drumstick.settings_recipe.NewCost = new CostMultiple[] { screecherheadIngredient };

        var poisonpufferheadItem = ItemManager.GetItemByName("Head_PoisonPuffer");
        var poisonpufferheadIngredient = new CostMultiple(new Item_Base[] { poisonpufferheadItem }, 1);
        var explosiveGoo = ItemManager.GetItemByName("ExplosiveGoo");
        explosiveGoo.settings_recipe.NewCost = new CostMultiple[] { poisonpufferheadIngredient };

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