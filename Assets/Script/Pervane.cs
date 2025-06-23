using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pervane : MonoBehaviour
{
    private Animator _Animator;
    public float BeklemeSuresi;
    public BoxCollider _Ruzgar;
    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }

    public void AnimasyonDurum(string durum)
    {
        if(durum == "true")
        {
            _Animator.SetBool("Calistir", true);
            _Ruzgar.enabled = true;
        }
            
        else
        {
            _Animator.SetBool("Calistir", false);
            _Ruzgar.enabled = false;
            StartCoroutine(AnimasyonTetikle());
        }
            

    }

    IEnumerator AnimasyonTetikle()
    {
        yield return new WaitForSeconds(BeklemeSuresi);
        AnimasyonDurum("true");
    }
}
