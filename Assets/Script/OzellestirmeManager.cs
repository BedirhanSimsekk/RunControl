using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bedirhan;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class OzellestirmeManager : MonoBehaviour
{
    public TextMeshProUGUI PuanText;
    public TextMeshProUGUI SapkaText;
    [Header("SAPKALAR")]
    public GameObject[] Sapkalar;
    public GameObject[] SapkaButonlari;
    [Header("SOPALAR")]
    public GameObject[] Sopalar;
    [Header("MATERYALLER")]
    public Material[] Materyaller;

    int SapkaIndex = -1;

    BellekYonetimi _BellerYonetim = new BellekYonetimi();

    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    void Start()
    {
        _BellerYonetim.VeriKaydet_i("AktifSapka", -1);
        if(_BellerYonetim.VeriOku_i("AktifSapka") == -1)
        {
            foreach(var item in Sapkalar)
            {
                item.SetActive(false);
            }
            SapkaIndex = -1;
            SapkaText.text = "Þapka yok";
        }
        else
        {
            SapkaIndex = _BellerYonetim.VeriOku_i("AktifSapka");
            Sapkalar[SapkaIndex].SetActive(true);
        }
        
        Load();
        //Save();
    }

    public void SapkaYonButonlari(string islem)
    {
        if(islem == "ileri")
        {
            if (SapkaIndex == -1)
            {
                SapkaIndex = 0;
                Sapkalar[SapkaIndex].SetActive(true);
            }
            else if(SapkaIndex < Sapkalar.Length - 1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
            }
            if (SapkaIndex == Sapkalar.Length - 1)
            {
                SapkaButonlari[1].GetComponent<Button>().interactable = false;
            }
            else
            {
                SapkaButonlari[0].GetComponent<Button>().interactable = true;
            }
            Debug.Log(SapkaIndex);
        }
        else
        {
            if (SapkaIndex > -1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;
                if (SapkaIndex > -1)
                    Sapkalar[SapkaIndex].SetActive(true);
            }
            if (SapkaIndex == -1)
            {
                SapkaButonlari[0].GetComponent<Button>().interactable = false;
            }
            else
            {
                SapkaButonlari[1].GetComponent<Button>().interactable = true;
            }
            Debug.Log(SapkaIndex);
        }
    }

    public void Save()
    {
        _ItemBilgileri[1].SatinAlmaDurumu = false;
        _ItemBilgileri.Add(new ItemBilgileri());
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
        bf.Serialize(file, _ItemBilgileri);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd", FileMode.Open);
            _ItemBilgileri = (List<ItemBilgileri>)bf.Deserialize(file);
            file.Close();
            Debug.Log(_ItemBilgileri[1].Item_Ad);
        }
    }

}
