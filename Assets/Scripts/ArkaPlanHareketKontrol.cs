using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arka : MonoBehaviour
{
    float arkaPlanKonum;
    float mesafe = 10.239991f;
    void Start()
    {
        arkaPlanKonum = transform.position.y;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
    }

    void Update()
    {
        if(arkaPlanKonum + mesafe < Camera.main.transform.position.y)
        {
            ArkaPlanYerlestir();
        }
    }

    /// <summary>
    /// Arka planý diðer arka plan objesinin hemen üstüne yerleþtir.
    /// </summary>
    void ArkaPlanYerlestir()
    {
        arkaPlanKonum += (mesafe * 2);
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
        Vector2 yeniPozisyon = new Vector2(0, arkaPlanKonum);
        transform.position = yeniPozisyon;
    }
}
