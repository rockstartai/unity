using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisPiece : MonoBehaviour
	{
		public Vector2Int Position { get => _position; set => UpdatePos(value); }

		Vector2Int _position;


		public void MoveBy(Vector2Int delta)
		{
			Position += delta;
		}

		void UpdatePos(Vector2Int newPos)
		{
			transform.position = new Vector2(x: newPos.x, y: newPos.y);
			_position = newPos;
		}
	}
}
