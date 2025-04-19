using UnityEngine;

public class HPUnpack : MonoBehaviour
{
    public GameObject sdCardPrefab;  // Prefab SD Card
    public GameObject ramPrefab;     // Prefab RAM

    // Fungsi untuk spawn SD Card atau RAM
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

        // Menambahkan tag item untuk mempermudah pengecekan lebih lanjut
        spawnedItem.GetComponent<DraggableItem>().itemType = itemType;
    }
}
