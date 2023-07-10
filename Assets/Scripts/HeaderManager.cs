using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderManager : MonoBehaviour
{
    public TextMeshProUGUI DrinksSold;
    public TextMeshProUGUI FoodSold;
    public TextMeshProUGUI DrinksMoneyMade;
    public TextMeshProUGUI FoodMoneyMade;
    void Start()
    {
        DrinkManager.EOnDrinkSold += OnDrinkSold;
        DrinkManager.EOnFoodSold += OnFoodSold;
    }

    void OnDrinkSold()
    {
        DrinksSold.text = DrinkManager.DrinksSold.ToString();
        DrinksMoneyMade.text = DrinkManager.DrinksMoneyMade.ToString() + "€";
    }

    void OnFoodSold()
    {
        FoodSold.text = DrinkManager.FoodSold.ToString();
        FoodMoneyMade.text = DrinkManager.FoodSold.ToString() + "€";
    }
}
