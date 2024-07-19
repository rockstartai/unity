using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	/// <summary>
	/// <see cref="Position"/> represents the position of its top-left slot in the block 
	/// scheme from the <see cref="TetrisPieceCfg"/>
	/// </summary>
	public class TetrisPiece : MonoBehaviour
	{
		public Vector2Int Position { get => _position; set => UpdatePos(value); }
		public TetrisPieceCfg Cfg => _cfg;

		Vector2Int _position;
		TetrisPieceCfg _cfg;


		public void Init(TetrisPieceCfg cfg)
		{
			_cfg = cfg;
		}
        private void Update()
        {
            
        }

        public void MoveBy(Vector2Int delta)
		{
			Position += delta;
		}

		public IEnumerable<Vector2Int> EnumerateBlockWorldPositions()
		{
			var piecePos = Position;
			foreach (var blockLocalPos in _cfg.EnumerateBlockLocalPositions())
				yield return piecePos + blockLocalPos;
		}

		void UpdatePos(Vector2Int newPos)
		{
			transform.position = new Vector2(newPos.x, newPos.y);
			_position = newPos;
		}
	}
}
