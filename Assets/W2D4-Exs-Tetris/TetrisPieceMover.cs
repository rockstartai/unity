using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisPieceMover
	{
		readonly ITetrisPhysics _physics;


		public TetrisPieceMover(ITetrisPhysics physics)
		{
			_physics = physics;
		}


		public bool TryMove(TetrisPiece piece, Vector2Int delta)
		{
			foreach (var blockPos in piece.EnumerateBlockWorldPositions())
			{
				var newPotentialPos = blockPos + delta;
				if (_physics.IsCollidingWithSolidWorld(newPotentialPos))
					return false;
			}

			piece.MoveBy(delta);

			return true;
		}
	}
}
