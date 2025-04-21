using UnityEngine;
using TMPro;  

public class BoxPenyimpanan : MonoBehaviour
{
    public int maxItems = 4; 
    private int currentItems = 0; 

    public TextMeshProUGUI winText; 

    void Start()
    {
        winText.gameObject.SetActive(false);
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
                winText.gameObject.SetActive(true);
                Debug.Log("Menang! Semua item sudah masuk.");
            }
        }
    }
}
