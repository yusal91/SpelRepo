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

    public void addCoins()
    {        
        coinsCollected += 1;
        brozeCoin.text = coinsCollected.ToString() + " Bronze Coin ";
        silverCoin.text = coinsCollected.ToString() + " Silver Coin ";
        goldCoin.text = coinsCollected.ToString() + " Gold Coin ";
    }
}
