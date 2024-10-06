using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplama : MonoBehaviour
{
    public LayerMask layer;
    public bool yerdemiyim;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D carptikmi = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layer);
        if (carptikmi.collider != null)
        { // yerdeyiz
            yerdemiyim = true;
        }
        else
        { // havadayýz
            yerdemiyim = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && yerdemiyim == true)
        {
            rb.velocity += new Vector2(0, 10f);
        }
    }
}