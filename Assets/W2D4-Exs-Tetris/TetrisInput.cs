using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisInput : MonoBehaviour
	{
		TetrisPiece _currentPiece;
		TetrisPieceMover _mover;
		IInputHandler _input;


		public void Init(TetrisPieceMover mover)
		{
			_mover = mover;

			// Strategy pattern
			if (Application.isMobilePlatform)
				_input = new MobileInputHandler();
			else
				_input = new StandaloneInputHandler();
		}


		void Update()
		{
			if (_currentPiece == null || _mover == null)
				return;

			if (_input.IsLeft())
				_mover.TryMove(_currentPiece, Vector2Int.left);
			else if (_input.IsRight())
				_mover.TryMove(_currentPiece, Vector2Int.right);
		}


		// These below are nested classes/interfaces. It's fine if the containing class is small.
		// In a bigger game input handlers are definitely large and, thus, separated in their own file.
		// In a bigger game, you'll react to events that are triggered by the Input modules themselves,
		// not proactively querying the modules like we're doing here, but this is a perfect, easy
		// demonstration of the Strategy Pattern


		interface IInputHandler
		{
			bool IsLeft();
			bool IsRight();
		}


		class StandaloneInputHandler : IInputHandler
		{
			public bool IsLeft() => Input.GetKeyDown(KeyCode.LeftArrow);

			public bool IsRight() => Input.GetKeyDown(KeyCode.RightArrow);
		}


		class MobileInputHandler : IInputHandler
		{
			float SwipeThreshold => Screen.width / 10;


			public bool IsLeft()
			{
				var deltaX = GetSwipeDeltaX();
				return deltaX < -SwipeThreshold;
			}

			public bool IsRight()
			{
				var deltaX = GetSwipeDeltaX();
				return deltaX > SwipeThreshold;
			}

			// This method checks if the swipe has ended and returns the horizontal delta.
			// Returns 0 if there's no valid swipe.
			private float GetSwipeDeltaX()
			{
				if (Input.touchCount > 0)
				{
					var touch = Input.GetTouch(0);
					if (touch.phase == TouchPhase.Ended)
						return touch.position.x - touch.rawPosition.x;
				}
				return 0;
			}
		}
	}
}
