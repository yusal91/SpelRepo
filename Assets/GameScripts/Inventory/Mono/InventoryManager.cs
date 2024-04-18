using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryPage inventoryPage;
    public ItemSlotData[] items;


    private void OnEnable()
    {
        inventoryPage.OnItemSelected += RefreshUi;
    }

    private void OnDisable()
    {
        inventoryPage.OnItemSelected -= RefreshUi;
    }

    private void Start()
    {
        SetItemLength();                  // this one called soon after one above
        UpdateUiInSlots();
    }

    private void SetItemLength()
    {
        inventoryPage.SlotsInfoOnStart();                  // order here matters this is called first and 
        items = new ItemSlotData[inventoryPage.slots.Length];

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new ItemSlotData();
        }
    }

    public void UpdateUiInSlots()
    {
        for (int i= 0; i < items.Length; i++)
        {
            inventoryPage.SetUiSlots(items[i].Item.Icon, items[i].Quantity);
        }
    }

    private void RefreshUi(int itemIndex)
    {
        Debug.Log("Can Click on Item:" + itemIndex);
    }
   
}
