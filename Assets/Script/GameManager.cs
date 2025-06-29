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

    [Header("LEVEL VERÝLERÝ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittimi;
    void Start()
    {
        DusmanlariOlustur();
    }

    public void DusmanlariOlustur()
    {
        for(int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }
    
    public void DusmanlariTetikle()
    {
        foreach(var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
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
    void SavasDurumu()
    {
        if(AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
        {
            OyunBittimi = true;
            foreach(var item in Dusmanlar)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Saldir", false);
                }
            }
            foreach (var item in Karakterler)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Saldir", false);
                }
            }
            _AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);
            if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
            {
                Debug.Log("Kaybettin");
            }
            else
            {
                Debug.Log("Kazandýn");
            }
        }
    }
    public void YokOlmaEfektiOlusturma(Transform Pozisyon,bool KisiDurumu)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = new Vector3(Pozisyon.position.x,
                                0.23f, Pozisyon.position.z);
                item.GetComponent<ParticleSystem>().Play();
                if (KisiDurumu)
                    AnlikKarakterSayisi--;
                else
                    KacDusmanOlsun--;
                break;
            }
        }
        if(!OyunBittimi)
            SavasDurumu();
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
