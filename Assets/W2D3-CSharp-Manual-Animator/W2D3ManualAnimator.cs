using UnityEngine;

namespace W2D3.CSharp
{
	public class W2D3ManualAnimator : MonoBehaviour
	{
		public SpriteRenderer spriteRenderer;
		public Sprite[] frames;
		public float frameRate = 10f;

		int index = 0;
		float timer = 0f;


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
