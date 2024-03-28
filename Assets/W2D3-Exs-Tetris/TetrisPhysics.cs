using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisPhysics : ITetrisPhysics
	{
		ITetrisSolidifiedPiecesHolder _solidifiedPiecesHolder;
		TetrisLevelCfg _cfg;


		public TetrisPhysics(TetrisLevelCfg cfg, ITetrisSolidifiedPiecesHolder solidifiedPiecesHolder)
		{
			_cfg = cfg;
			_solidifiedPiecesHolder = solidifiedPiecesHolder;
		}


		bool ITetrisPhysics.IsCollidingWithSolidWorld(Vector2Int pos)
		{
			if (IsOutsideLevel(pos))
				return true;

			foreach (var solidifiedPiece in _solidifiedPiecesHolder.Pieces)
			{
				foreach (var solidifiedBlockPos in solidifiedPiece.EnumerateBlockWorldPositions())
				{
					if (solidifiedBlockPos == pos)
						return true;
				}
			}

			return false;
		}

		bool IsOutsideLevel(Vector2Int pos)
		{
			var maxX = _cfg.Size.x - 1;
			var maxY = _cfg.Size.y - 1;

			return pos.x < 0 || pos.x > maxX
				|| pos.y < 0 || pos.y > maxY;
		}
	}
}
