using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AyarlarKontrol : MonoBehaviour
{
    public Button kolayButon, ortaButon, zorButon;

    
    void Start()
    {
        //Ayarlar men�m�z a��l�r a��lmaz kay�tlara bak�p de�eri 1 olan� pasif hale getirecek.
        if(Secenekler.KolayDegerOku() == 1)
        {
            kolayButon.interactable = false;
            ortaButon.interactable = true;
            zorButon.interactable = true;
        }
        if(Secenekler.OrtaDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = false;
            zorButon.interactable = true;
        }
        if(Secenekler.ZorDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = true;
            zorButon.interactable = false;
        }
    }


     public void SecenekSecildi(string seviye)
    {
        switch (seviye)
        {
            case "kolay":
                Secenekler.KolayDegerAta(1);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(0);
                kolayButon.interactable = false; //interactable olay� kolay� se�erse ba�ka bir �eyi se�emiyor.
                ortaButon.interactable = true;
                zorButon.interactable = true;
                break;
            case "orta":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(1);
                Secenekler.ZorDegerAta(0);
                kolayButon.interactable = true;
                ortaButon.interactable = false;
                zorButon.interactable = true;
                break;
            case "zor":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(1);
                kolayButon.interactable = true;
                ortaButon.interactable = true;
                zorButon.interactable = false;
                break;
            default:
                break;
        }
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
