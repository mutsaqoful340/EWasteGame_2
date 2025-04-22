using UnityEngine;
using TMPro;
using System.Collections;

public class BoxPenyimpanan : MonoBehaviour
{
    public int maxItems = 4;
    private int currentItems = 0;

    public GameObject winPanel;  // Panel yang muncul setelah menang
    public TextMeshProUGUI winText;  // Text untuk menampilkan "Menang!"
    public GameObject buttonsPanel; // Panel yang berisi tombol-tombol (Lanjut Level, Ulangi Level)

    void Start()
    {
        // Menyembunyikan panel kemenangan dan tombol di awal permainan
        winPanel.SetActive(false);
        buttonsPanel.SetActive(false); // Pastikan tombol juga disembunyikan
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barang"))
        {
            currentItems++;
            Debug.Log("Item masuk! Total: " + currentItems);

            other.gameObject.SetActive(false);

            if (currentItems >= maxItems)
            {
                Menang();  // Panggil fungsi ketika semua item sudah masuk
            }
        }
    }

    void Menang()
    {
        winPanel.SetActive(true);  // Menampilkan panel kemenangan
        winText.text = "Anda Menang!";  // Menampilkan teks "Anda Menang!"

        Debug.Log("Menang! Semua item sudah masuk.");
        StartCoroutine(TampilkanTombol());  // Menunggu 5 detik sebelum menampilkan tombol
    }

    IEnumerator TampilkanTombol()
    {
        yield return new WaitForSeconds(5f); // Menunggu selama 5 detik

        buttonsPanel.SetActive(true); // Menampilkan tombol setelah 5 detik
    }

    // Fungsi untuk pindah ke level berikutnya
    public void LanjutLevel()
    {
        int nextSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Tidak ada level selanjutnya.");
        }
    }

    // Fungsi untuk mengulang level saat ini
    public void UlangiLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
