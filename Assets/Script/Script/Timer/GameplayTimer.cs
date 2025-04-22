using System.Collections;
using UnityEngine;
using TMPro;

public class GameplayTimer : MonoBehaviour
{
    public float waktuTersisa = 300f; // 5 menit waktu permainan
    private float waktuMulai;
    public bool permainanSelesai = false;

    public TextMeshProUGUI timerText; // Referensi ke TextMeshPro untuk timer
    public TextMeshProUGUI upahText;  // Referensi ke TextMeshPro untuk upah
    public TextMeshProUGUI winText;   // Referensi ke TextMeshPro untuk pesan kemenangan
    public GameObject winPanel;       // Referensi ke panel kemenangan

    void Start()
    {
        waktuMulai = Time.time;  // Catat waktu mulai permainan
        winPanel.SetActive(false);  // Sembunyikan panel kemenangan di awal permainan
    }

    void Update()
    {
        if (!permainanSelesai)
        {
            waktuTersisa -= Time.deltaTime;
            UpdateTimerUI();  // Update UI timer setiap frame

            if (waktuTersisa <= 0f)
            {
                waktuTersisa = 0f;
                SelesaikanPermainan();  // Panggil selesai permainan jika waktu habis
            }
        }
    }

    void UpdateTimerUI()
    {
        // Update text timer dengan format menit:detik
        float menit = Mathf.Floor(waktuTersisa / 60);
        float detik = Mathf.Floor(waktuTersisa % 60);
        timerText.text = string.Format("{0:00}:{1:00}", menit, detik);
    }

    public void SelesaikanPermainan()
    {
        if (permainanSelesai) return;  // Pastikan hanya dijalankan sekali

        permainanSelesai = true;  // Tandai permainan selesai
        Debug.Log("Permainan selesai");

        // Hitung durasi permainan
        float durasiMain = Time.time - waktuMulai;
        int upah = HitungUpah(durasiMain);  // Hitung upah berdasarkan durasi permainan

        // Update UI dengan upah dan tampilkan panel kemenangan
        upahText.text = "Upah: Rp " + upah.ToString("N0");
        winText.text = "Anda Menang!";
        winPanel.SetActive(true); // Menampilkan panel kemenangan

        StartCoroutine(TampilkanTombol());
    }

    int HitungUpah(float durasi)
    {
        if (durasi <= 60f)
            return 25000;
        else if (durasi <= 120f)
            return 20000;
        else if (durasi <= 180f)
            return 15000;
        else if (durasi <= 240f)
            return 10000;
        else if (durasi <= 300f)
            return 5000;
        else
            return 0;
    }

    IEnumerator TampilkanTombol()
    {
        yield return new WaitForSeconds(2f);  // Tunggu sebentar
        // Tombol atau panel lainnya bisa ditampilkan di sini
    }
}
