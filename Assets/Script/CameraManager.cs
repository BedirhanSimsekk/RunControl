using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;
    void Start()
    {
        target_offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SonaGeldikmi)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        }
        else
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position, .015f);
    }
}
