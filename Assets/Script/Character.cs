using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 1f; // Yan hareket hýzý
    public GameManager _GameManager;
    public GameObject _Kamera;
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;
    void Start()
    {
    }

    private void FixedUpdate()
    {
        if(!SonaGeldikmi) 
        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }

    void Update()
    {
        if (SonaGeldikmi)
        {
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position, .008f);
        }
        else
        {
            if (Input.GetMouseButton(0)) // Basýlý tutma
            {
                float mouseX = Input.mousePosition.x - Screen.width / 2;

                if (mouseX < 0) // Ekranýn sol yarýsý
                {
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
                else // Ekranýn sað yarýsý
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Bolme") || other.CompareTag("Cýkartma"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.KarakterYonetimi(other.tag,sayi,other.transform);

        }
        else if ((other.CompareTag("SonTetikleyici")))
        {
            _GameManager.DusmanlariTetikle();
            _Kamera.GetComponent<CameraManager>().SonaGeldikmi = true;
            SonaGeldikmi = true;
        }
    }
}