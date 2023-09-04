using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float hiz = default;

    [SerializeField]
    float hizlanma = default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    [SerializeField]
    int ziplamaLimiti = 3;

    int ziplamaSayisi;

    Joystick joystick;
    JoystickButon joystickButon;

    bool zipliyor;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButon = FindObjectOfType<JoystickButon>();
    }

    void Update()
    {
        //Hangi ortamda oyunu �al��t�r�yorsa o ortama g�re fonksiyonlar� kullan�yor.
#if UNITY_EDITOR
        KlavyeKontrol();
#else
        JoystickKontrol();
#endif
    }

    void KlavyeKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale; //�u anki scale de�erini ald�k. buradaki amac�m�z karakter sa�a ve sola giderken bakt��� y�n�n�n de�i�mesini sa�lamak.

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        gameObject.transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            Ziplamay�Baslat();
        }

        if (Input.GetKeyUp("space"))
        {
            ZiplamayiDurdur();
        }

    }

    void JoystickKontrol()
    {
        float hareketInput = joystick.Horizontal;
        Vector2 scale = transform.localScale; //�u anki scale de�erini ald�k. buradaki amac�m�z karakter sa�a ve sola giderken bakt��� y�n�n�n de�i�mesini sa�lamak.

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        gameObject.transform.Translate(velocity * Time.deltaTime);

        if(joystickButon.tusaBasildi == true && zipliyor == false)
        {
            zipliyor = true;
            Ziplamay�Baslat();
        }
        if(joystickButon.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }

    void Ziplamay�Baslat()
    {
        FindObjectOfType<SesKontrol>().ZiplamaSes();
        if (ziplamaSayisi < ziplamaLimiti)
        {
            rb2d.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        }
    }

    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }

    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
