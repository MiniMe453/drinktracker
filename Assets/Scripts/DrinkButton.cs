using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrinkButton : MonoBehaviour
{
    public Button DrinkSoldButton;
    public Button UndoSellButton;
    public TextMeshProUGUI DrinkName;
    public TextMeshProUGUI DrinkCount;
    public Image ButtonImage;
    public DrinkData drinkData;

    public void InitButton(DrinkData _data)
    {
        drinkData = _data;
        DrinkName.text = drinkData.drinkName;
        ButtonImage.color = drinkData.buttonColor;
        UndoSellButton.onClick.AddListener(OnClick_UndoSell);
        DrinkSoldButton.onClick.AddListener(OnClick_DrinkSoldButton);

        drinkData.amountSold = 0;
        DrinkCount.text = drinkData.amountSold.ToString();
    }

    void OnClick_DrinkSoldButton()
    {
        drinkData.SellDrink();

        DrinkCount.text = drinkData.amountSold.ToString();
    }

    void OnClick_UndoSell()
    {
        drinkData.RemoveDrink();

        DrinkCount.text = drinkData.amountSold.ToString();
    }
}
