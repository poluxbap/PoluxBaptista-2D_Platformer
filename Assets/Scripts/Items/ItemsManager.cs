using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemsManager : Singleton<ItemsManager>
{
    public int coins;
    public TMP_Text coinText;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        coinText.text = "x " + coins;
    }
}
