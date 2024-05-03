using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.CSharp.Unity
{
	public class W2D3Components : MonoBehaviour
	{
		[SerializeField] AudioClip _audioClip;
		Rigidbody _rb;


		void Start()
		{
			// The transform component is so used that's already provided by default
			transform.position = new Vector3(2, 3, 4);
			// .. but, since it's a component, you can also get it via
			GetComponent<Transform>().position = new Vector3(2, 3, 4);



			// It's better to store components in a field if you'll be using them more than once
			_rb = GetComponent<Rigidbody>();
			_rb.AddForce(Vector3.up * 5);
			_rb.AddForce(Vector3.left * 3);



			// You can even add components at runtime
			var audioSrc = gameObject.AddComponent<AudioSource>();
			audioSrc.clip = _audioClip;
			audioSrc.playOnAwake = false; // prevent auto-play
			// Then play it whenever you want
			audioSrc.Play();
			// Then, then again (for ex., after 5 secs, or when a collision happens), etc.
			audioSrc.Play();



			// Hide the GameObject without deactivating it
			var meshRenderer = GetComponent<MeshRenderer>();
			meshRenderer.enabled = false;



			// Apply a force to all objects tagged 'Player' if they have a Rigidbody
			var taggedObjects = GameObject.FindGameObjectsWithTag("Player");
			foreach (var obj in taggedObjects)
			{
				if (obj.TryGetComponent<Rigidbody>(out var rb))
					rb.AddForce(Vector3.back * 10);
			}



			// Find all audio sources from the scene and plays them all at once.
			// I don't recommend running this code. :)
			var audioSources = FindObjectsOfType<AudioSource>();
			foreach (var src in audioSources)
			{
				src.Play();
			}
		}

		void OnCollisionEnter(Collision collision)
		{
			// Specific case: when colliding with an object, how do I know what it is?
			// Well, it first starts with correctly setting up the Collision matrix, but after that,
			// in code, we simply check by name or whether it has a certain component

			if (collision.gameObject.name == "some name")
			{
				// Do stuff
			}

			if (collision.gameObject.tag == "some tag")
			{
				// Do stuff
			}

			var comp = collision.gameObject.GetComponent<W2D3Components>();
			if (comp != null)
			{
				// We've just collided with another object that has an instance of this type of script
				// Note: W2D3Components is just a name we're using for this script. Imagine instead of
				// 'W2D3Components' we have 'Ball' or 'Gun' or 'Bullet' etc.
			}
		}
	}
}
