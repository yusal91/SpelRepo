using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUi : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    [SerializeField] private Image selectedSlotIcon;

    public event Action OnInvSlotItemClicked;

    public void SetSlotUi(Sprite newIcon, int quantity)
    {
        this.icon.sprite = newIcon;
        this.quantityText.text = quantity.ToString();
    }

    public void ResetSlotUi()
    {
        this.icon.sprite = null;
        this.quantityText.text = "";
    }

    public void ItemSelected()
    {
        selectedSlotIcon.enabled = true;
    }

    public void ItemDeSelected()
    {
        selectedSlotIcon.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData is { button: PointerEventData.InputButton.Left })
        {
            OnInvSlotItemClicked?.Invoke();
        }
    }
}
