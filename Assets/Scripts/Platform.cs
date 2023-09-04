using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //PolygonCollider2D polygonCollider2D;

    BoxCollider2D boxCollider2D;

    float randomHiz;
    bool hareket;

    float min, max;
    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        

        if (Secenekler.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.8f);
        }
        if (Secenekler.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.5f);
        }

        float objeGenislik = boxCollider2D.bounds.size.x / 2; // Ekranýn yarýsýna kadar hareket et.

        if (transform.position.x > 0)
        {
            min = objeGenislik;
            max = EkranHesaplayicisi.instance.Genislik - objeGenislik;
        }
        else
        {
            min = -EkranHesaplayicisi.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }

    void Update()
    {
        //Platform hareket
        if (hareket)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ayaklar"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.parent = transform;
            player.GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
    }
}
