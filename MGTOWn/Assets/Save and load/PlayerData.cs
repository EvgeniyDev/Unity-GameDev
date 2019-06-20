using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int stamina;

    public float[] position;

    public int[] itemsId;
    public int[] itemsAmount;
    public int[] itemsDamage;
    public string[] itemsName;
    public string[] itemsDescription;
    public string[] itemsPrefab;
    public bool[] itemsIsStakable;
    public string[] itemsSprites;

    public PlayerData(PlayerStats player, GameObject playerInstance, Inventory inventory)
    {
        int slotsAmount = inventory.cellContainer.transform.childCount;

        itemsId = new int[slotsAmount];
        itemsAmount = new int[slotsAmount];
        itemsDamage = new int[slotsAmount];
        itemsName = new string[slotsAmount];
        itemsDescription = new string[slotsAmount];
        itemsPrefab = new string[slotsAmount];
        itemsIsStakable = new bool[slotsAmount];
        itemsSprites = new string[slotsAmount];

        for (int i = 0; i < slotsAmount; i++)
        {
            itemsId[i] = inventory.items[i].id;
            itemsAmount[i] = inventory.items[i].itemAmount;
            itemsName[i] = inventory.items[i].itemName;
            itemsDescription[i] = inventory.items[i].description;
            itemsIsStakable[i] = inventory.items[i].isStackable;
            itemsPrefab[i] = inventory.items[i].prefab;
            itemsSprites[i] = inventory.items[i].icon;

            if (inventory.items[i] is WeaponItem)
            {
                itemsDamage[i] = (inventory.items[i] as WeaponItem).baseDamage;
            }
        }

        health = player.currentHealth;
        stamina = player.currentStamina;

        position = new float[3];
        position[0] = playerInstance.transform.position.x;
        position[1] = playerInstance.transform.position.y;
        position[2] = playerInstance.transform.position.z;
    }
}
