using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bedirhan
{
    public class Matematiksel_islemler : MonoBehaviour
    {
        public static void Carpma(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusmaEfektleri)
        {
            int DonguSayisi = (GameManager.AnlikKarakterSayisi * GelenSayi) - GameManager.AnlikKarakterSayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = new Vector3(Pozisyon.position.x,
                            Pozisyon.position.y, Pozisyon.position.z - 0.5f);
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        // Bu þekilde de yapabilirsiniz:
                        item.transform.position = new Vector3(Pozisyon.position.x,
                            Pozisyon.position.y, Pozisyon.position.z - 0.5f);
                        item.SetActive(true);
                        sayi++;
                    }
                }
                else
                {
                    sayi = 0;
                    break;
                }
            }
            GameManager.AnlikKarakterSayisi *= GelenSayi;
        }

        public static void Toplama(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusmaEfektleri)
        {
            int sayi2 = 0;
            foreach (var item in Karakterler)
            {
                if (sayi2 < GelenSayi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = new Vector3(Pozisyon.position.x,
                            Pozisyon.position.y, Pozisyon.position.z - 0.5f);
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        item.transform.position = new Vector3(Pozisyon.position.x,
                            Pozisyon.position.y, Pozisyon.position.z - 0.5f);
                        item.SetActive(true);
                        sayi2++;
                    }
                }
                else
                {
                    sayi2 = 0;
                    break;
                }
            }
            GameManager.AnlikKarakterSayisi += GelenSayi;
        }

        public static void Cýkartma(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri, Transform Pozisyon)
        {
            if (GameManager.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach(var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            item2.SetActive(true);
                            item2.transform.position = new Vector3(Pozisyon.position.x,
                                0.23f, Pozisyon.position.z);
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }

                    // Bu þekilde de yapabilirsiniz:
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                    GameManager.AnlikKarakterSayisi = 1;
                }
            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 < GelenSayi)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    item2.SetActive(true);
                                    item2.transform.position = new Vector3(Pozisyon.position.x,
                                        0.23f, Pozisyon.position.z);
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

                            // Bu þekilde de yapabilirsiniz:
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;
                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }
                }
                GameManager.AnlikKarakterSayisi -= GelenSayi;
            }
        }

        public static void Bolme(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri, Transform Pozisyon)
        {
            if (GameManager.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            item2.SetActive(true);
                            item2.transform.position = new Vector3(Pozisyon.position.x,
                                            0.23f, Pozisyon.position.z);
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {
                // Kalacak karakter sayýsýný hesapla
                int kalacakSayi = Mathf.CeilToInt((float)GameManager.AnlikKarakterSayisi / GelenSayi);
                int deaktiveEdilecekSayi = GameManager.AnlikKarakterSayisi - kalacakSayi;

                int sayac = 0;
                foreach (var item in Karakterler)
                {
                    if (sayac >= deaktiveEdilecekSayi) break;

                    if (item.activeInHierarchy)
                    {
                        foreach (var item2 in YokOlmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = new Vector3(Pozisyon.position.x,
                                                0.23f, Pozisyon.position.z);
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                        sayac++;
                    }
                }

                GameManager.AnlikKarakterSayisi = kalacakSayi;
            }
        }
    }
}

