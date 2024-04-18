using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{

    [Header("inventory Slots")]
    public GameObject slotHolder;
    public ItemSlotUi[] slots;


    public event Action<int> OnItemSelected;

    public void SlotsInfoOnStart()
    {
        slots = new ItemSlotUi[slotHolder.transform.childCount];

        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).GetComponent<ItemSlotUi>();

            slots[i].OnInvSlotItemClicked += UpdateUi;
        }
    }

    private void UpdateUi()
    {
        int slotIndex;
        slotIndex = slots.Length;
        if (slots[slotIndex] == null ) return;

        OnItemSelected?.Invoke(slotIndex);
    }

    public void SetUiSlots(Sprite newIcon, int quantity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlotUi(newIcon, quantity);
        }
    }
}
