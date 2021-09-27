using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : Utils
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Load(2);
        }
    }

}
