using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _Navmesh;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().VarisNoktasi;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlusturma(transform,true);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("TestereDisli"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlusturma(transform,true);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Balyoz"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().LekeOlustur(transform);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Dusman"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlusturma(transform, true);
            gameObject.SetActive(false);
        }

    }
}
