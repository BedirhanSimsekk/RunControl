using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float moveSpeed = 1f; // Yan hareket hýzý
    public GameManager _GameManager;
    public CameraManager _Kamera;
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;
    public Slider _Slider;
    public GameObject GecisNoktasý;
    void Start()
    {
        float Mesafe = Vector3.Distance(transform.position, GidecegiYer.transform.position);
        _Slider.maxValue = Mesafe;
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
            if(_Slider.value != 0)
                _Slider.value -= .008f;
            
        }
        else
        {
            float Mesafe = Vector3.Distance(transform.position, GidecegiYer.transform.position);
            _Slider.value = Mesafe;
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
            _Kamera.SonaGeldikmi = true;
            SonaGeldikmi = true;
        }
        else if ((other.CompareTag("BosKarakter")))
        {
            _GameManager.Karakterler.Add(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float lerpSpeed = 12f; // Bu deðeri ayarlayarak hýzý kontrol edebilirsin
        Vector3 targetPosition = transform.position;

        if (collision.gameObject.CompareTag("Direk"))
        {
            if (transform.position.x < 0)
                targetPosition = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
            else
                targetPosition = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }

        if (collision.gameObject.CompareTag("igneliKutu"))
        {
            if (transform.position.x < 0)
                targetPosition = new Vector3(transform.position.x + .05f, transform.position.y, transform.position.z);
            else
                targetPosition = new Vector3(transform.position.x - .05f, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }

        if (collision.gameObject.CompareTag("OrtaDirek"))
        {
            if (transform.position.x < 0)
                targetPosition = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
            else
                targetPosition = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }
    }
}