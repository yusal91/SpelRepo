using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPageUi : MonoBehaviour
{
    public EquipmentSlotUi slotPrefab;

    public RectTransform contentParent;

    public List<EquipmentSlotUi> equipmentSlotUis = new List<EquipmentSlotUi>();

    public event Action<int> OnSlotClicked;

    public void SetSlot(int slotSize)
    {
        for (int i = 0; i < slotSize; i++)
        {
            EquipmentSlotUi slotUi = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
            slotUi.transform.SetParent(contentParent, false);

            equipmentSlotUis.Add(slotUi);

            slotUi.OnSlotClick += HandleSelection;
        }
    }    

    public void SetData(Sprite icon, int index)
    {
        if(equipmentSlotUis.Count > index)
        {
            equipmentSlotUis[index].SetData(icon);
        }
    }

    private void HandleSelection(EquipmentSlotUi ui)
    {
        int index = equipmentSlotUis.IndexOf(ui);
        if(index == -1) { return; }

        OnSlotClicked?.Invoke(index);
    }

    public void SlotSelected(int index)
    {
        DeSelectedSlot();
        equipmentSlotUis[index].SelectedSlot();
    }
    public void DeSelectedSlot()
    {
        foreach (var slotUi in equipmentSlotUis)
        {
            slotUi.DeSelectedSlot();
        }
    }
}
