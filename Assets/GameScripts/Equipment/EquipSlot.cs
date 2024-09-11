using System;

[Serializable]
public class EquipSlot 
{
    public ItemClass item;

    public bool IsEmpty => item == null;

    public static EquipSlot EmptySlot()=> new EquipSlot() { item = null };
}
