using NUnit.Framework;
using System.Net;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Inventory : MyMonobehavior
{
    [SerializeField] private int MaxValueStack = 70;
    [SerializeField] protected List<ItemInventory> ItemsInInventory;
    [SerializeField] Transform ItemHolder;
    [SerializeField] GameObject ItemPrefabs;

    public static Inventory instance;
    protected override void Awake()
    {
        instance = this;
    }
    public void AddItem(string NameCode)
    {
        // Tính tổng số lượng item trong inventory hiện tại
        int totalItems = 0;
        foreach (var i in ItemsInInventory)
            totalItems += i.ItemCount;

        // Nếu vượt quá giới hạn MaxValueStack thì không thêm
        if (totalItems >= MaxValueStack)
        {
            Debug.Log("Inventory đã đầy, không thể thêm.");
            return;
        }

        foreach (var itemInv in ItemsInInventory)
        {
            if (itemInv.ItemSO.ItemCode.ToString() == NameCode)
            {
                int spaceLeft = itemInv.MaxStack - itemInv.ItemCount;
                if (spaceLeft > 0)
                {
                    int addAmount = Mathf.Min(itemInv.ItemSO.DefaultStack, spaceLeft);
                    // Đảm bảo không vượt quá MaxValueStack
                    addAmount = Mathf.Min(addAmount, MaxValueStack - totalItems);
                    itemInv.ItemCount += addAmount;
                    return;
                }
                else
                {
                    Debug.Log("Item đã full stack.");
                    return;
                }
            }
        }

        // Nếu không có item thì thêm mới
        AddEmptyItem(NameCode);
        DisplayInventory();
    }
    public void AddEmptyItem(string NameCode)
    {
        var ListItemSO = Resources.LoadAll("Item", typeof(ItemSO));
        foreach (ItemSO item in ListItemSO)
        {
            if (item.ItemCode.ToString() != NameCode) continue;
            ItemInventory itemInventory = new ItemInventory();
            itemInventory.ItemSO = item;
            itemInventory.ItemCount = item.DefaultStack;
            ItemsInInventory.Add(itemInventory);
        }
    }

    

    public void DisplayInventory()
    {
        foreach(Transform Item in ItemHolder)
        {
            Destroy(Item.gameObject);
        }
        foreach(var item in ItemsInInventory)
        {
            GameObject obj = Instantiate(ItemPrefabs, ItemHolder);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            //item.ItemSO.ItemCode.ToString() + item.ItemCount;
            var itemImage = obj.transform.Find("ItemImage").GetComponent<Image>();
            itemName.text= item.ItemSO.ItemCode.ToString() + item.ItemCount;
            itemImage.sprite = item.ItemSO.image;
            // Lấy component thay vì AddComponent
            var controller = obj.GetComponent<ItemUiController>();
            controller.setName(item.ItemSO);
        }
    }

    public void removeItem(ItemSO itemSO, int amount)
    {
        if (itemSO == null) return;

        for (int i = 0; i < ItemsInInventory.Count; i++)
        {
            var itemInv = ItemsInInventory[i];

            if (itemInv.ItemSO == itemSO)
            {
                // Trừ số lượng
                itemInv.ItemCount -= amount;

                // Nếu số lượng <= 0 thì remove khỏi inventory
                if (itemInv.ItemCount <= 0)
                {
                    ItemsInInventory.RemoveAt(i);
                }

                // Cập nhật lại UI
                DisplayInventory();
                return;
            }
        }

        Debug.LogWarning($"Item {itemSO.ItemCode} không tồn tại trong inventory.");
    }
}
