using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*speed;
    }
}
