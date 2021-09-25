using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollectablePowerJump : ItemsCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddItem(ItemsManager.ItemType.POWERJUMP, 1);
    }
}
