using UnityEngine;

namespace W2D3.CSharp
{
	// Simple sprite animator script for Unity
	public class W2D3ManualAnimator : MonoBehaviour
	{
		public SpriteRenderer spriteRenderer; // Assign in inspector
		public Sprite[] frames; // Assign in inspector
		private int index = 0;
		private float timer = 0f;
		public float frameRate = 10f; // Frames per second

		void Update()
		{
			timer += Time.deltaTime;
			if (timer >= 1f / frameRate)
			{
				index = (index + 1) % frames.Length;
				spriteRenderer.sprite = frames[index];
				timer -= 1f / frameRate;
			}
		}
	}
}
