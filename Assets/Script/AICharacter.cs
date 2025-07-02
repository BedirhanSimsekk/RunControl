using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    NavMeshAgent _Navmesh;
    public GameManager _GameManager;
    public GameObject Target;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = _GameManager.VarisNoktasi;
    }
    void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            _GameManager.YokOlmaEfektiOlusturma(transform,true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("TestereDisli"))
        {
            _GameManager.YokOlmaEfektiOlusturma(transform,true);
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
        else if ((other.CompareTag("BosKarakter")))
        {
            _GameManager.Karakterler.Add(other.gameObject);
        }
    }
}
