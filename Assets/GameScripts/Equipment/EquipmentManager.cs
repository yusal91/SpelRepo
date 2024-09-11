using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int slotCount = 3;
    public EquipmentPageUi dataPage;

    public List<EquipSlot> equipSlots;    

    public event Action <Dictionary<int, EquipSlot>> EquipSlotAdded;

    private void OnEnable()
    {
        EquipSlotAdded += SlotUpdated;
        dataPage.OnSlotClicked += HandleSelection;
    }
    private void OnDisable()
    {
        EquipSlotAdded -= SlotUpdated;
        dataPage.OnSlotClicked -= HandleSelection;
    }

    private void Start()
    {
        PrepareUi();
        PrepareData(slotCount);
    }

    private void PrepareUi() => dataPage.SetSlot(slotCount);
    private void PrepareData(int size)
    {
        //size = Enum.GetNames(typeof(EquipItem)).Length - 1;

        for (int i = 0; i < size; i++)
        {
            equipSlots.Add(EquipSlot.EmptySlot());
            RefreshUi();
        }       
    }

    public EquipSlot GetByIndex(int index) => equipSlots[index];

    private Dictionary<int, EquipSlot> GetCurrentItem()
    {
        Dictionary<int, EquipSlot> returnValue = new Dictionary<int, EquipSlot>();

        for (int i = 0; i < equipSlots.Count; i++)
        {
            returnValue[i] = equipSlots[i];
        }
        return returnValue;
    }

    public void RefreshUi() => EquipSlotAdded?.Invoke(GetCurrentItem());

    private void SlotUpdated(Dictionary<int, EquipSlot> EquipSlotState)
    {
        foreach (var item in EquipSlotState)
        {
            dataPage.SetData(item.Value.item.Icon, item.Key);
        }
    }

    private void HandleSelection(int index)
    {
        EquipSlot equipSlot = GetByIndex(index);

        Debug.Log(equipSlot.item);
        dataPage.SlotSelected(index);
    }
}
