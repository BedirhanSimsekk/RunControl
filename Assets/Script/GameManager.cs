using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bedirhan;
public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KarakterY�netimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                Matematiksel_islemler.Carpma(GelenSayi, Karakterler, Pozisyon);
                break;

            case "Toplama":
                Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon);
                break;

            case "C�kartma":
                Matematiksel_islemler.C�kartma(GelenSayi, Karakterler);
                break;

            case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler);
                break;
        }
    }
}
