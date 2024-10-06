using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // E�er TextMeshPro kullan�yorsan ekle
using UnityEngine.SceneManagement; // Sahne y�netimi i�in ekle

public class Portal : MonoBehaviour
{
    public TextMeshProUGUI kazanmaMesaji; // Kazanma mesaj� UI ��esi
    private bool kazanildi = false; // Oyun kazan�ld� m� kontrol�

    void Start()
    {
        // Ba�lang��ta mesaj g�r�nmez
        kazanmaMesaji.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // E�er astronot portala de�erse
        if (other.CompareTag("Player") && !kazanildi)
        {
            kazanildi = true; // Oyunun kazan�ld��� durumunu ayarla
            Kazan(other.gameObject); // Kazan metodunu �a��r
        }
    }

    private void Kazan(GameObject astronot)
    {
        // Kazand�n�z mesaj�n� aktif hale getir
        kazanmaMesaji.gameObject.SetActive(true);
        Debug.Log("Kazand�n�z!");

        // Astronotu sil
        Destroy(astronot);

        // Yeniden ba�latma i�in 2 saniye bekle
        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        // Oyun sahnesini yeniden y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}   