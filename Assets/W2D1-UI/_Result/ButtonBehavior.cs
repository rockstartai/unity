using UnityEngine;

namespace W2D1.UI
{
	public class ButtonBehavior : MonoBehaviour
	{
		int n;

		public void OnButtonPress()
		{
			n++;
			Debug.Log("Button clicked " + n + " times.");
		}
	}
}
