using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConditionallyVisible : MonoBehaviour
{
    void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible");
        //GetComponent<Renderer>().enabled = true;
    }

    void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
        //GetComponent<Renderer>().enabled = false;
    }
}
