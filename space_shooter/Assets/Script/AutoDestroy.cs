using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public float timeOut;
    
    void Start()
    {
        // huy hieu ung no
        Destroy(gameObject, timeOut);
    }

}
