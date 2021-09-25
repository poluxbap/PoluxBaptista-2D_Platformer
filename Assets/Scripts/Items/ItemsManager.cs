using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemsManager : Singleton<ItemsManager>
{
    public enum ItemType { COIN, POWERJUMP, SHIELD }

    public List<ItemInfo> items = new List<ItemInfo>();

    private void Start()
    {
        foreach (var item in items)
        {
            item.itemSO.value = 0;
        }
    }

    public virtual void AddItem(ItemType type, int value)
    {
        var item = items.Find(i => i.type.Equals(type));

        item.itemSO.value += value;

        UpdateUI(item);
    }

    protected virtual void UpdateUI(ItemInfo item)
    {
        if (!item.textMeshProUGUI)
            return;

        item.textMeshProUGUI.text = " x" + item.itemSO.value.ToString();
    }
}

[System.Serializable]
public class ItemInfo
{
    public ItemsManager.ItemType type = ItemsManager.ItemType.COIN;
    public SO_Int itemSO;
    public TextMeshProUGUI textMeshProUGUI;
}
