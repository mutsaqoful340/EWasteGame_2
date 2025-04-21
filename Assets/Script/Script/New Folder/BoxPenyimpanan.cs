using UnityEngine;
using TMPro;  // Import TMPro untuk TextMeshProUGUI

public class BoxPenyimpanan : MonoBehaviour
{
    public int maxItems = 4; // Jumlah maksimal item
    private int currentItems = 0; // Jumlah item yang masuk

    public TextMeshProUGUI winText; // Teks kemenangan

    void Start()
    {
        // Menyembunyikan teks kemenangan di awal
        winText.gameObject.SetActive(false);
    }

    // Fungsi untuk menangani item yang masuk ke dalam box
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang masuk adalah item yang bisa dimasukkan
        if (other.CompareTag("Barang"))
        {
            // Menambahkan item dan memperbarui jumlah item
            currentItems++;
            Debug.Log("Item masuk! Total: " + currentItems);

            // Menghentikan objek setelah dimasukkan
            other.gameObject.SetActive(false);

            // Mengecek apakah jumlah item mencapai maksimum
            if (currentItems >= maxItems)
            {
                // Menampilkan teks kemenangan
                winText.gameObject.SetActive(true);
                Debug.Log("Menang! Semua item sudah masuk.");
            }
        }
    }
}
