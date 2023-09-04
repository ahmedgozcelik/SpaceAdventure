using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject oyunBittiPanel;
    public GameObject joystick;
    public GameObject ziplamaButonu;
    public GameObject tabela;
    public GameObject menuButonu;
    public GameObject slider;

    void Start()
    {
        oyunBittiPanel.SetActive(false);
        UIAc();
    }

    public void OyunuBitir()
    {
        FindObjectOfType<SesKontrol>().OyunBittiSes();
        oyunBittiPanel.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        FindObjectOfType<KameraHareket>().OyunBitti();
        UIKapat();
    }

    /// <summary>
    /// Ye�il geri butonuna t�klay�nca ana men�ye d�n.
    /// </summary>
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Oyunu tekrar ba�latmak i�in oyun sahnemizi tekrar y�kledik.
    /// </summary>
    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun"); 
    }

    void UIAc()
    {
        joystick.SetActive(true);
        ziplamaButonu.SetActive(true);
        tabela.SetActive(true);
        menuButonu.SetActive(true);
        slider.SetActive(true);
    }

    void UIKapat()
    {
        joystick.SetActive(false);
        ziplamaButonu.SetActive(false);
        tabela.SetActive(false);
        menuButonu.SetActive(false);
        slider.SetActive(false);
    }
}
