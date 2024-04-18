using UnityEngine;

[System.Serializable]
public class ItemSlotData 
{
    [field: SerializeField] public ItemClass Item { get; set; } = null;

    [field: SerializeField] public int Quantity { get; set; } = 0;

    public ItemSlotData()
    {
        Item = null;
        Quantity = 0;
    }

    public ItemSlotData(ItemClass item, int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }

    public ItemSlotData(ItemSlotData itemSlot)
    {
        this.Item = itemSlot.Item;
        this.Quantity = itemSlot.Quantity;
    }

    public void AddQuantity(int quantity) => Quantity += quantity;

    public void SubQuantity(int quantity)
    {
        Quantity -= quantity; // remove stacked Item
        if (Quantity <= 0)
            Clear();
    }

    public void AddItem(ItemClass item, int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }

    public void Clear()
    {
        this.Item = null;
        this.Quantity = 0;
    }
}
