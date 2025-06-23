using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bedirhan;
public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekeleri;
    void Start()
    {

    }

    public void KarakterYonetimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                Matematiksel_islemler.Carpma(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
                break;

            case "Toplama":
                Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
                break;

            case "Cýkartma":
                Matematiksel_islemler.Cýkartma(GelenSayi, Karakterler, YokOlmaEfektleri, Pozisyon);
                break;

            case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri, Pozisyon);
                break;
        }
    }

    public void YokOlmaEfektiOlusturma(Transform Pozisyon)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = new Vector3(Pozisyon.position.x,
                                0.23f, Pozisyon.position.z);
                item.GetComponent<ParticleSystem>().Play();
                AnlikKarakterSayisi--;
                break;
            }
        }
    }
    public void LekeOlustur(Transform pozisyon)
    {
        StartCoroutine(AdamLekesiOlusturma(pozisyon));
    }
    public IEnumerator AdamLekesiOlusturma(Transform Pozisyon)
    {
        GameObject aktifLeke = null;

        // Boþ leke bul ve aktif et
        foreach (var item in AdamLekeleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = new Vector3(Pozisyon.position.x, 0.005f, Pozisyon.position.z);
                aktifLeke = item; // Hangi lekeyi açtýðýmýzý hatýrla
                AnlikKarakterSayisi--;
                break;
            }
        }

        // 5 saniye bekle
        yield return new WaitForSeconds(5f);

        // Sadece bu lekeyi kapat
        if (aktifLeke != null)
        {
            aktifLeke.SetActive(false);
        }
    }
}
