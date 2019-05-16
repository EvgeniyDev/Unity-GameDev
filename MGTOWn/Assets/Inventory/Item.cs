using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string itemName;

    [Multiline(3)]
    public string description;

    [HideInInspector]
    public int itemAmount;

    public bool isStackable;
    public Sprite icon;
    public string prefab;

    public enum Type { None, Weapon, Armor, Drop, QuestItem };
    public Type type = Type.None;
}
