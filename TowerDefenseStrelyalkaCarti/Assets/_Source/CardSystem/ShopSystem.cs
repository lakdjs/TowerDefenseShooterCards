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
    public GameObject[] cardPanelsGO;
    public Button[] purchaseButton;

    public GameObject deck;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SO.Length; i++)
        {
            cardPanelsGO[i].SetActive(true);
        }
        coinsTxt.text = "Coins: " + coins.ToString();
        LoadPanels();
        canPurchase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins += 100;
        coinsTxt.text = coinsTxt.text = "Coins: " + coins.ToString();
        canPurchase();
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

    public void canPurchase()
    {
        for (int i = 0; i < SO.Length; i++)
        {
            if (coins >= SO[i].cost)
            {
                purchaseButton[i].interactable = true;
            }
            else
            {
                purchaseButton[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (coins >= SO[btnNo].cost)
        {
            coins = coins - SO[btnNo].cost;
            coinsTxt.text = "Coins: " + coins.ToString();
            cardPanelsGO[btnNo].transform.parent = deck.transform;
            canPurchase();
        }
    }
}
