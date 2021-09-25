using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollectableCoin : ItemsCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddItem(ItemsManager.ItemType.COIN, 1);
    }
}
