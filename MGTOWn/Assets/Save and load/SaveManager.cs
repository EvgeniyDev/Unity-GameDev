using UnityEngine;

public class SaveManager : MonoBehaviour
{
    PlayerStats playerStats;
    public GameObject inventoryHolder;
    Inventory inventory;

    int slotsAmount;
    private void Start()
    {
        if (MainMenu.isGameWasLoaded == true)
        {
            Load();
        }
    }

    public void Save()
    {
        playerStats = GetComponent<PlayerStats>();
        inventory = inventoryHolder.GetComponent<Inventory>();

        SaveLoadSystem.SaveGame(playerStats, gameObject, inventory);
    }

    public void Load()
    {
        PlayerData data = SaveLoadSystem.LoadGame();
        inventory = inventoryHolder.GetComponent<Inventory>();

        GetComponent<PlayerStats>().currentHealth = data.health;
        GetComponent<PlayerStats>().currentStamina = data.stamina;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        for (int i = 0; i < inventory.cellContainer.transform.childCount; i++)
        {
            inventory.items[i] = inventory.LoadItem(
                                    data.itemsId[i], data.itemsAmount[i], data.itemsIsStakable[i],
                                    data.itemsName[i], data.itemsDescription[i], data.itemsPrefab[i],
                                    data.itemsSprites[i], data.itemsDamage[i]);
        }

        inventory.DisplayItems();
    }
}
