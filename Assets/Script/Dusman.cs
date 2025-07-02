using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    public GameObject Saldiri_Hedefi;
    NavMeshAgent _NavMesh;
    Animator _Animator;
    bool Saldiri_Basladimi;
    public GameManager _GameManager;
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
        _Animator = GetComponent<Animator>();
    }

    public void AnimasyonTetikle()
    {
        _Animator.SetBool("Saldir",true);
        Saldiri_Basladimi = true;
    }
    void LateUpdate()
    {
        if(Saldiri_Basladimi)
        _NavMesh.SetDestination(Saldiri_Hedefi.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AIKarakter"))
        {
            _GameManager.YokOlmaEfektiOlusturma(transform, false);
            gameObject.SetActive(false);
        }
    }
}
