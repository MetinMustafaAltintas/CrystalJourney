using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Eðer TextMeshPro kullanýyorsan ekle
using UnityEngine.SceneManagement; // Sahne yönetimi için ekle

public class Portal : MonoBehaviour
{
    public TextMeshProUGUI kazanmaMesaji; // Kazanma mesajý UI öðesi
    private bool kazanildi = false; // Oyun kazanýldý mý kontrolü

    void Start()
    {
        // Baþlangýçta mesaj görünmez
        kazanmaMesaji.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer astronot portala deðerse
        if (other.CompareTag("Player") && !kazanildi)
        {
            kazanildi = true; // Oyunun kazanýldýðý durumunu ayarla
            Kazan(other.gameObject); // Kazan metodunu çaðýr
        }
    }

    private void Kazan(GameObject astronot)
    {
        // Kazandýnýz mesajýný aktif hale getir
        kazanmaMesaji.gameObject.SetActive(true);
        Debug.Log("Kazandýnýz!");

        // Astronotu sil
        Destroy(astronot);

        // Yeniden baþlatma için 2 saniye bekle
        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        // Oyun sahnesini yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}   