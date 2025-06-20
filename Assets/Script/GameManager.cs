using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KarakterYönetimi(string veri, Transform Pozisyon)
    {
        switch (veri)
        {
            case "x2":
                int sayi = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi < AnlikKarakterSayisi)
                    {
                        if (!item.activeInHierarchy)
                        {
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
                AnlikKarakterSayisi *= 2;
                break;

            case "+3":
                int sayi2 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi2 < 3)
                    {
                        if (!item.activeInHierarchy)
                        {
                            // Bu þekilde de yapabilirsiniz:
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
                AnlikKarakterSayisi += 3;
                break;

            case "-4":
                if (AnlikKarakterSayisi <= 4)
                {
                    foreach (var item in Karakterler)
                    {
                        // Bu þekilde de yapabilirsiniz:
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                        AnlikKarakterSayisi = 1;
                    }
                }
                else
                {
                    int sayi3 = 0;
                    foreach (var item in Karakterler)
                    {
                        if (sayi3 < 4)
                        {
                            if (item.activeInHierarchy)
                            {
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
                    AnlikKarakterSayisi -= 4;
                }
                break;

            case "/2":
                if (AnlikKarakterSayisi <= 2)
                {
                    foreach (var item in Karakterler)
                    {
                        // Bu þekilde de yapabilirsiniz:
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                        AnlikKarakterSayisi = 1;
                    }
                }
                else
                {
                    int sayi4 = 0;
                    foreach (var item in Karakterler)
                    {
                        if (sayi4 < AnlikKarakterSayisi / 2)
                        {
                            if (item.activeInHierarchy)
                            {
                                // Bu þekilde de yapabilirsiniz:
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                sayi4++;
                            }
                        }
                        else
                        {
                            sayi4 = 0;
                            break;
                        }
                    }
                    if(AnlikKarakterSayisi % 2 == 0)
                    {
                        AnlikKarakterSayisi /= 2;
                    }
                    else
                    {
                        AnlikKarakterSayisi = AnlikKarakterSayisi / 2 + 1;
                    }
                    
                }
                break;
        }
    }
}
