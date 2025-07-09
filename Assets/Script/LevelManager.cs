using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bedirhan;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    public Sprite KilitButon;
    int mevcutLevel;

    BellekYonetimi _BellekYonetimi = new BellekYonetimi();
    void Start()
    {
        mevcutLevel = _BellekYonetimi.VeriOku_i("SonLevel") - 4;
        int index = 1;
        for (int i = 0; i < buttons.Length; i++)
        {
            if(index <= mevcutLevel)
            {
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = index.ToString();
                int sahneIndex = index + 4;
                buttons[i].onClick.AddListener(delegate { SahneYukle(sahneIndex); });
            }
            else
            {
                buttons[i].GetComponentInChildren<Image>().sprite = KilitButon;
                buttons[i].enabled = false;
            }
            index++;
        }


    }
    public void SahneYukle(int index)
    {
        SceneManager.LoadScene(index);
        Debug.Log(index);
    }

    void Update()
    {
        
    }
}
