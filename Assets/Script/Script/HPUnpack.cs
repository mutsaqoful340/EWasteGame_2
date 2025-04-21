using UnityEngine;

public class HPUnpack : MonoBehaviour
{
    public GameObject sdCardPrefab;   // Prefab SD Card
    public GameObject ramPrefab;      // Prefab RAM
    public GameObject simCardPrefab;  // Prefab SIM Card ← DITAMBAH

    // Fungsi untuk spawn SD Card, RAM, atau SIM Card
    public void SpawnItem(Vector3 spawnPos, string itemType)
    {
        GameObject spawnedItem = null;

        // Tentukan prefab berdasarkan item type
        if (itemType == "SDCard")
        {
            spawnedItem = Instantiate(sdCardPrefab, spawnPos, Quaternion.identity);
        }
        else if (itemType == "RAM")
        {
            spawnedItem = Instantiate(ramPrefab, spawnPos, Quaternion.identity);
        }
        else if (itemType == "SIMCard") // ← DITAMBAH
        {
            spawnedItem = Instantiate(simCardPrefab, spawnPos, Quaternion.identity);
        }

        // Tambahkan tag atau info item ke komponen
        if (spawnedItem != null)
        {
            spawnedItem.GetComponent<DraggableItem>().itemType = itemType;
        }
    }
}
