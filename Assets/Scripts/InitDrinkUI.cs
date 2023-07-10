using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitDrinkUI : MonoBehaviour
{
    public RectTransform drinkParent;
    public RectTransform foodParent;
    public GameObject drinkButton;

    public DrinkData[] drinkDatas;

    void Start()
    {
        foreach (DrinkData data in drinkDatas)
        {
            switch (data.drinkType)
            {
                case DrinkType.Drink:
                    CreateDrinkButton(drinkParent, data);
                    break;
                case DrinkType.Food:
                    CreateDrinkButton(foodParent, data);
                    break;
            }
        }
    }

    void CreateDrinkButton(RectTransform parent, DrinkData data)
    {
        GameObject obj = Instantiate(drinkButton, parent);
        DrinkButton button = obj.GetComponent<DrinkButton>();
        button.InitButton(data);
    }
}
