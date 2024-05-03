using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.CSharp.Unity
{
	public class W2D3MyScript : MonoBehaviour
	{
		public int myProperty;

		void Awake()
		{
			Debug.Log("Called before anyone's OnEnable (globally)");
		}

		void OnEnable()
		{
			Debug.Log("Called at init IF enabled, or when first enabled, or whenever re-enabled");
		}

		void Start()
		{
			Debug.Log("Called before anyone's Update (globally)");
			Debug.Log($"myProperty: {myProperty}");
		}

		void Update()
		{
			Debug.Log(
				"Called once per frame (usually 60 times per sec). " +
				$"Delay since last frame: {Time.deltaTime}"
			);
		}

		void FixedUpdate()
		{
			Debug.Log(
				"Similar to Update, but physics should be done here. Ex: Rigidbody.AddForce(..). " +
				$"Delay since last physics frame: {Time.fixedDeltaTime}"
			);
		}

		void LateUpdate()
		{
			Debug.Log("Called after all Update(); ex: Camera movement");
		}

		void OnCollisionEnter(Collision collision)
		{
			Debug.Log($"Collision detected with {collision.gameObject.name}");
		}

		void OnTriggerEnter(Collider other)
		{
			Debug.Log($"Trigger entered: {other.gameObject.name}");
		}

		void OnDisable()
		{
			Debug.Log("Called when disabled/deactivated");
		}

		void OnApplicationPause(bool pauseStatus)
		{
			Debug.Log($"Application paused: {pauseStatus}");
		}

		void OnApplicationQuit()
		{
			Debug.Log("Application quitting");
		}

		void OnDestroy()
		{
			Debug.Log("Called when the object is being removed; cleanup if needed");
		}
	}
}
