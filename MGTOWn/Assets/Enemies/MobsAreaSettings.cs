using UnityEngine;
using UnityEngine.AI;

public class MobsAreaSettings : MonoBehaviour
{
    public GameObject Mobs;
    public GameObject mobPrefab;

    public int mobsAmount;

    [Header("Spawn coordinates")]
    public int min_x;
    public int max_x;
    public int y;
    public int min_z;
    public int max_z;


    [Header("Spawn time")]
    public int minSpawnTime;
    public int maxSpawnTime;

    GameObject instantiatedMob;

    void Update()
    {
        if (Mobs.transform.childCount < mobsAmount)
        {
            Invoke("Spawning", Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    void Spawning()
    {
        Vector3 randomLocation =
            new Vector3(Random.Range(min_x, max_x), y, Random.Range(min_z, max_z));

        instantiatedMob = Instantiate(mobPrefab, randomLocation, Quaternion.identity, Mobs.transform);

        instantiatedMob.GetComponent<NavMeshAgent>().Warp(randomLocation);
        instantiatedMob.name = mobPrefab.name;

        CancelInvoke("Spawning");
    }
}
