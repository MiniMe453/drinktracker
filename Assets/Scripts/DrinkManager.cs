using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class DrinkManager
{
    public static int DrinksSold = 0;
    public static float DrinksMoneyMade
    {
        get
        {
            float money = 0;

            foreach (DrinkData d in drinkDatas)
            {
                if (d.drinkName == "Pizza Bread")
                    continue;

                money += d.MoneyMade;
            }

            return money;
        }
    }
    public static event Action EOnDrinkSold;
    public static event Action EOnFoodSold;
    public static int FoodSold = 0;
    public static List<DrinkData> drinkDatas = new List<DrinkData>();

    public static void RegisterDrinkData(DrinkData data)
    {
        drinkDatas.Add(data);
        data.amountSold = 0;
    }

    public static void OnSomethingSold(DrinkData data)
    {
        if (data.drinkType == DrinkType.Food)
        {
            FoodSold++;
            EOnFoodSold?.Invoke();

        }
        else
        {
            DrinksSold++;
            EOnDrinkSold?.Invoke();
        }
        SaveData(data);
    }

    public static void OnSomethingRemoved(DrinkData data)
    {
        if (data.drinkType == DrinkType.Food)
        {
            FoodSold--;
            EOnFoodSold?.Invoke();
        }
        else
        {
            DrinksSold--;
            EOnDrinkSold?.Invoke();
        }

        SaveData(data, true);
    }

    private static void SaveData(DrinkData data, bool wasRemoved = false)
    {
        //Save the data of all the drinks
        List<string> lines = new List<string>();

        lines.Add("Product,Price,Amound Sold");

        foreach (DrinkData d in drinkDatas)
        {
            string newLine = d.drinkName + "," + d.drinkPrice.ToString() + "," + d.amountSold;
            lines.Add(newLine);
        }

        lines.Add("Total,Price," + (FoodSold + DrinksMoneyMade).ToString());

        File.WriteAllLinesAsync((Application.persistentDataPath + "/barData.csv"), lines.ToArray());

        if (wasRemoved)
            return;

        //Save the timestamps of when drinks were sold
        using (StreamWriter sw = File.AppendText(Application.persistentDataPath + "/sellTimestamp.csv"))
        {
            sw.WriteLine(data.drinkName + "," + DateTime.Now.ToString());
        }
    }
}
