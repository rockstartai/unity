using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D1.UI
{
	public class W2D1JoystickController : MonoBehaviour
	{
		[SerializeField] FixedJoystick _joystick;
		[SerializeField] Rigidbody _target;
		[SerializeField] float _moveSpeed;

        private void Start()
        {
			if (Application.isEditor)
				Application.targetFrameRate = 60;
        }

        void FixedUpdate()
        {
            _target.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _target.velocity.y, _joystick.Vertical * _moveSpeed);

        }

        // If you want to move it without physics (also aneble isKinematic in cube's inspector)
        //void Update()
        //{
        //    var delta = new Vector3(_joystick.Horizontal * _moveSpeed, _target.velocity.y, _joystick.Vertical * _moveSpeed);
        //    _target.transform.Translate(delta * Time.deltaTime);
        //}
    }
}