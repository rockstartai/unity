using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestScript : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(transform.up * 30 * Time.deltaTime, Space.Self);
    }
}
