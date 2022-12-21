using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyC : MonoBehaviour
{
    public float outLine = -8;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.sqrMagnitude < -8)
        {
            Destroy(gameObject);
        }
    }
}
