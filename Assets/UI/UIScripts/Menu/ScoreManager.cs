using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;    

    public Text brozeCoin;
    public Text silverCoin;
    public Text goldCoin;

    public int bronzeCoinCollected;
    public int silverCoinCollected;
    public int goldCoinCollected;


    int coinsCollected = 0;
    //int finalCollectedCoins = 0;

    void Awake()
    {
        instance = this;       
    }

    // Start is called before the first frame update
    void Start()
    {    
        brozeCoin.text = coinsCollected.ToString() + " Bronze Coin ";
        silverCoin.text = coinsCollected.ToString() + " Silver Coin ";
        goldCoin.text = coinsCollected.ToString() + " Gold Coin ";
    }

    public void AddCoins(string itemType)
    {
        Debug.Log(itemType);
        

        if (itemType == "Bronze Coin")
        {
            bronzeCoinCollected += 1;
        }
        else if(itemType == "Silver Coin")
        {
            silverCoinCollected += 1;
        }
        else if(itemType == "Gold Coin")
        {
            goldCoinCollected += 1;
        }
            



        brozeCoin.text = bronzeCoinCollected.ToString() + " Bronze Coin  / 14 ";
        silverCoin.text = silverCoinCollected.ToString() + " Silver Coin / 10 ";
        goldCoin.text = goldCoinCollected.ToString() + " Gold Coin       / 7 ";
    }
}
