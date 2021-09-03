using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemsManager : Singleton<ItemsManager>
{
    public SO_Int soInt;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        soInt.coins = 0;
        soInt.powerjump = 0;
        soInt.shield = 0;
    }

    public void AddCoins(int amount = 1)
    {
        soInt.coins += amount;
    }

    public void AddPowerJump(int amount = 1)
    {
        soInt.powerjump += amount;
    }

    public void AddShield(int amount = 1)
    {
        soInt.shield += amount;
    }

    public void SubtractCoins(int amount = 1)
    {
        soInt.coins += amount;
    }

    public void SubtractPowerJump(int amount = 1)
    {
        soInt.powerjump += amount;
    }

    public void SubtractShield(int amount = 1)
    {
        soInt.shield += amount;
    }
}
