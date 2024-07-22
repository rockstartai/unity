using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerTemp : MonoBehaviour
{

    AsyncOperation _loadOp;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (_loadOp != null)
        {
            Debug.Log("Load progress: " + _loadOp.progress);

            if (_loadOp.isDone)
            {
                _loadOp = null;
            }
        }
    }


    void OnButtonClicked()
    {
        Debug.Log("Loading scene");
        _loadOp = SceneManager.LoadSceneAsync("W2D1-UI-Mobile/W2D1-UI-Mobile", LoadSceneMode.Single);

    }
}
