using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject portalKapali; // Kapal� portal�n g�rseli
    public GameObject portalAcik;   // A��k portal�n g�rseli
    public TextMeshProUGUI kazanmaMesaji; // Kazanma mesaj� UI ��esi
    private int totalCrystals;      // Oyundaki toplam kristal say�s�
    private int collectedCrystals;  // Toplanan kristal say�s�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Kristallerin say�s�n� bul
        totalCrystals = GameObject.FindGameObjectsWithTag("Kristaller").Length;
        collectedCrystals = 0;

        // Ba�lang��ta kapal� portal g�r�n�r, a��k portal gizli
        portalKapali.SetActive(true);
        portalAcik.SetActive(false);

        // Ba�lang��ta kazanma mesaj� gizli
        kazanmaMesaji.gameObject.SetActive(false);
    }

    public void CollectCrystal()
    {
        collectedCrystals++;

        // T�m kristaller topland�ysa portallar� de�i�tir
        if (collectedCrystals >= totalCrystals)
        {
            SwapPortals();
        }
    }

    private void SwapPortals()
    {
        // Kapal� portal� gizle, a��k portal� g�ster
        portalKapali.SetActive(false);
        portalAcik.SetActive(true);
        Debug.Log("T�m kristaller topland�! Kapal� portal kayboldu, a��k portal ortaya ��kt�.");
    }

    void Update()
    {
        // Yeniden ba�latma kontrol�
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Oyun sahnesini yeniden y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}