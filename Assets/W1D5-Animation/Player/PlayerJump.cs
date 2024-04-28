using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W1D5.Animation
{
    public class PlayerJump : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GetComponent<Animator>().SetTrigger("Jump");

        }
    }
}
