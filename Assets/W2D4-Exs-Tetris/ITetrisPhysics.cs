using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public interface ITetrisPhysics
	{
		bool IsCollidingWithSolidWorld(Vector2Int pos);
	}
}
