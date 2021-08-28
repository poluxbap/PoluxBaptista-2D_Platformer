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

    private void Update()
    {
        coinText.text = "x " + coins;
    }

    public void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
    }
}
