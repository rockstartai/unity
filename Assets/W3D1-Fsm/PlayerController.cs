using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 5f;
        Rigidbody _rb;


        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            var movePerSec = new Vector3(moveHorizontal, 0.0f, moveVertical)
                * _moveSpeed;
            _rb.AddForce(movePerSec, ForceMode.Acceleration);

            // Don't exceed the max speed
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _moveSpeed);
        }
    }
}
