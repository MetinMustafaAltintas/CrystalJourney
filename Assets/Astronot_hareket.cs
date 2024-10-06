using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Astronot_hareket : MonoBehaviour
{
    public float hizkatsayisi = 0.1f;
    public int Can = 1;
    public TextMeshProUGUI Cansayisi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        transform.position += new Vector3(yatay * hizkatsayisi, 0, 0);

        float dikey = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, dikey * hizkatsayisi, 0);

        //Debug.Log(yatay);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kristaller")
        {
            if (Can < 100)
            {

                Can++;
                Cansayisi.text = Can.ToString();
            }

            // Kristali topladýðýný GameManager'a bildir
            GameManager.instance.CollectCrystal();

            Destroy(collision.gameObject);
        }
        if (collision.tag == "Spike")
        {
            if (Can > 1)
            {
                Can--;
                Cansayisi.text = Can.ToString();
            }
            else
            {
                Can--;
                Cansayisi.text = Can.ToString();
                Debug.Log("Öldünüz");
                Destroy(gameObject);
            }
        }
        // Debug.Log("Kristal ile Yanyana geçme algýlandý.");
    }
}
