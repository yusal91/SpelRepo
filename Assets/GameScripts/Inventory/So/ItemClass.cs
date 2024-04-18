using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : ScriptableObject
{
    [field: Header("Item")]
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: TextArea(10, 15)]
    [field: SerializeField] public string ItemDescription { get; private set; }

    [field: Header("Item Stack size")]
    [field: SerializeField] public bool IsStackable { get; private set; }  // recommanded not to have = true at begining but it causes isuses

    [field: Range(1, 99)]
    [field: SerializeField] public int StackSize { get; private set; }    // again don't set the size from the script
}
