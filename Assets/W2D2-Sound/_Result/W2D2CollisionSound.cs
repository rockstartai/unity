using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D2.Sound
{
    public class W2D2CollisionSound : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
