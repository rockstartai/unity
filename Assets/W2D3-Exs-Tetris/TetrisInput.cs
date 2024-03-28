using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisInput : MonoBehaviour
	{
		TetrisPiece _currentPiece;


		void Update()
		{
			if (_currentPiece == null)
				return;

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{

			}
		}
	}
}
