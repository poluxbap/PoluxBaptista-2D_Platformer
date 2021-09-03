using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollectableShield : ItemsCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddShield();
    }
}
