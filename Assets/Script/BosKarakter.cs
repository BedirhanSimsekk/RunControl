using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Progress;

public class BosKarakter : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material _AtanacakMaterial;
    NavMeshAgent _NavMesh;
    Animator _Animator;
    public GameObject Target;
    public GameManager _GameManager;
    bool temasVar;
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _NavMesh = GetComponent<NavMeshAgent>();
    }
    void LateUpdate()
    {
        if(temasVar)
            _NavMesh.SetDestination(Target.transform.position);
    }
    void MaterialDegistirveAnimasyonTetikle()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = _AtanacakMaterial;
        _Renderer.materials = mats;

        _Animator.SetBool("TemasVar", true);

        GameManager.AnlikKarakterSayisi++;
        gameObject.tag = "AIKarakter";
        Debug.Log(GameManager.AnlikKarakterSayisi);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AIKarakter") || other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("BosKarakter"))
            {
                MaterialDegistirveAnimasyonTetikle();
                temasVar = true;
                GetComponent<AudioSource>().Play();
            }

        }
        else if (other.CompareTag("igneliKutu"))
        {
            _GameManager.YokOlmaEfektiOlusturma(transform, true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("TestereDisli"))
        {
            _GameManager.YokOlmaEfektiOlusturma(transform, true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            _GameManager.LekeOlustur(transform);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Dusman"))
        {
            _GameManager.YokOlmaEfektiOlusturma(transform, true);
            gameObject.SetActive(false);
        }
    }
}
