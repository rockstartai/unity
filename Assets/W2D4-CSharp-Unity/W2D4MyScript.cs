using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.CSharp.Unity
{
	public class W2D4MyScript : MonoBehaviour
	{
		public ScriptableObject obj;

		public int myProperty;

#if UNITY_EDITOR
		void Reset()
        {
			if (Application.platform == RuntimePlatform.OSXEditor)
				myProperty = 3;
			else
				myProperty = 2;

            Debug.Log("Reset: Called in editor", gameObject);
        }
#endif

		void Awake()
		{
			Debug.Log("Awake: Called before anyone's OnEnable (globally)", gameObject);
		}

		void OnEnable()
		{
			Debug.Log("OnEnable: Called at init IF enabled, or when first enabled, or whenever re-enabled", gameObject);
		}

		void Start()
		{
			Debug.Log("Start: Called before anyone's Update (globally)", gameObject);
			//Debug.Log($"myProperty: {myProperty}");
		}

  //      void Update()
		//{
		//	Debug.Log(
		//		"Called once per frame (usually 60 times per sec). " +
		//		$"Delay since last frame: {Time.deltaTime}", gameObject
		//	);
		//}

		//void FixedUpdate()
		//{
		//	Debug.Log(
		//		"Similar to Update, but physics should be done here. Ex: Rigidbody.AddForce(..). " +
		//		$"Delay since last physics frame: {Time.fixedDeltaTime}", gameObject
		//	);
		//}

		//void LateUpdate()
		//{
		//	Debug.Log("Called after all Update(); ex: Camera movement", gameObject);

		//          Camera.main.transform.LookAt(transform.position);
		//}

		void OnCollisionEnter(Collision collision)
		{
            Debug.Log($"Collision detected with {collision.gameObject.name}", gameObject);
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Trigger entered: {other.gameObject.name}", gameObject);
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log($"Trigger exited: {other.gameObject.name}", gameObject);
        }

        void OnDisable()
		{
			Debug.Log("Called when disabled/deactivated", gameObject);
		}

		void OnApplicationPause(bool pauseStatus)
		{
			Debug.Log($"Application paused: {pauseStatus}", gameObject);
		}

		void OnApplicationQuit()
		{
			Debug.Log("Application quitting", gameObject);
		}

		void OnDestroy()
		{
			Debug.Log("Called when the object is being removed; cleanup if needed", gameObject);
		}
	}
}
