using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item stats")]
    public int id;
    public string itemName;

    [Multiline(3)]
    public string description;

    [HideInInspector]
    public int itemAmount;

    public bool isStackable;
    public string icon;
    public string prefab;

}
