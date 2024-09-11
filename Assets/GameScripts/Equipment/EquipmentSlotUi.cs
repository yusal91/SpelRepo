using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlotUi : MonoBehaviour, IPointerClickHandler
{
    public Image Icon;
    public Image SelectedSlotBg;

    public event Action<EquipmentSlotUi> OnSlotClick;

    public void SetData(Sprite icon)
    {
        this.Icon.enabled = true;
        this.Icon.sprite = icon;
    }

    public void SelectedSlot()=> SelectedSlotBg.enabled = true;
    public void DeSelectedSlot()=> SelectedSlotBg.enabled = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotClick?.Invoke(this);
    }
}
