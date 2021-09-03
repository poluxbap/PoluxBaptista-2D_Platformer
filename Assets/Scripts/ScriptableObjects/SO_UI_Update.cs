using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SO_UI_Update : MonoBehaviour
{
    public SO_Int soInt;
    public TMP_Text coinText;
    public TMP_Text powerJumpText;
    public TMP_Text shieldText;

    void Start()
    {
        coinText.text = "x " + soInt.coins.ToString();
        powerJumpText.text = "x " + soInt.powerjump.ToString();
        shieldText.text = "x " + soInt.shield.ToString();
    }

    void Update()
    {
        coinText.text = "x " + soInt.coins.ToString();
        powerJumpText.text = "x " + soInt.powerjump.ToString();
        shieldText.text = "x " + soInt.shield.ToString();
    }
}
