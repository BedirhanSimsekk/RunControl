using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Bedirhan;
using System;

public class AnaMenuManager : MonoBehaviour
{
    BellekYonetimi _BellekYonetimi = new BellekYonetimi();
    void Start()
    {
        _BellekYonetimi.KontrolEtveTanimla();
    }

    public void SahneYukle(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Oyna()
    {
        SceneManager.LoadScene(_BellekYonetimi.VeriOku_i("SonLevel"));    
    }
    public void Cýkýs()
    {
        Application.Quit();
    }
}
