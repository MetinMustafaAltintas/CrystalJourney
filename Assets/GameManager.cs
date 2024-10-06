using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject portalKapali; // Kapalý portalýn görseli
    public GameObject portalAcik;   // Açýk portalýn görseli
    public TextMeshProUGUI kazanmaMesaji; // Kazanma mesajý UI öðesi
    private int totalCrystals;      // Oyundaki toplam kristal sayýsý
    private int collectedCrystals;  // Toplanan kristal sayýsý

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
        // Kristallerin sayýsýný bul
        totalCrystals = GameObject.FindGameObjectsWithTag("Kristaller").Length;
        collectedCrystals = 0;

        // Baþlangýçta kapalý portal görünür, açýk portal gizli
        portalKapali.SetActive(true);
        portalAcik.SetActive(false);

        // Baþlangýçta kazanma mesajý gizli
        kazanmaMesaji.gameObject.SetActive(false);
    }

    public void CollectCrystal()
    {
        collectedCrystals++;

        // Tüm kristaller toplandýysa portallarý deðiþtir
        if (collectedCrystals >= totalCrystals)
        {
            SwapPortals();
        }
    }

    private void SwapPortals()
    {
        // Kapalý portalý gizle, açýk portalý göster
        portalKapali.SetActive(false);
        portalAcik.SetActive(true);
        Debug.Log("Tüm kristaller toplandý! Kapalý portal kayboldu, açýk portal ortaya çýktý.");
    }

    void Update()
    {
        // Yeniden baþlatma kontrolü
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Oyun sahnesini yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}