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

		void FixedUpdate()
		{
			_target.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _target.velocity.y, _joystick.Vertical * _moveSpeed);
		}
	}
}