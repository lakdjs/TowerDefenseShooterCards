using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsTxt;
    public SO[] SO;
    public CardTemplate[] cardPanels;
    // Start is called before the first frame update
    void Start()
    {
        coinsTxt.text = "Coins: " + coins.ToString();
        LoadPanels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins = coins + 100;
        coinsTxt.text = coinsTxt.text = "Coins: " + coins.ToString();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < SO.Length; i++)
        {
            cardPanels[i].titleText.text = SO[i].title;
            cardPanels[i].descText.text = SO[i].description;
            cardPanels[i].costText.text = SO[i].cost.ToString();
        }
    }
}
