using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrinkType { Drink, Food };

[CreateAssetMenu(fileName = "Drank", menuName = "StudentLife/Dranks", order = 1)]
public class DrinkData : ScriptableObject
{
    public string drinkName;
    public DrinkType drinkType = DrinkType.Drink;
    public float drinkCost;
    public float drinkPrice;
    public int amountSold;
    public float MoneyMade { get { return ((drinkPrice * (float)amountSold) - (drinkCost * (float)amountSold)); } }
    public Color buttonColor = new Color(1, 1, 1, 1);

    public DrinkData()
    {
        DrinkManager.RegisterDrinkData(this);
    }

    public void SellDrink()
    {
        amountSold++;
        DrinkManager.OnSomethingSold(this);
    }

    public void RemoveDrink()
    {
        if (amountSold == 0)
            return;

        amountSold--;
        DrinkManager.OnSomethingRemoved(this);
    }
}
