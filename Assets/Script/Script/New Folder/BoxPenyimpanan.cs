using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxPenyimpanan : MonoBehaviour
{
    public int maxItems = 4;
    private int currentItems = 0;

    public GameObject winPanel; // panel yang muncul saat menang
    public TextMeshProUGUI winText;

    void Start()
    {
        winPanel.SetActive(false); // sembunyikan panel saat start
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
                Menang();
            }
        }
    }

    void Menang()
    {
        winPanel.SetActive(true);
        winText.text = "Menang!";
        Debug.Log("Menang! Semua item sudah masuk.");
    }

    // Dipanggil oleh tombol "Lanjut Level"
    public void LanjutLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Tidak ada level selanjutnya.");
        }
    }

    // Dipanggil oleh tombol "Ulangi Level"
    public void UlangiLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
