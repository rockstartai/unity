using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisPieceFactory : MonoBehaviour
	{
		[SerializeField] TetrisPiece _piecePrefab;
		[SerializeField] GameObject _blockPrefab;


		public TetrisPiece Create(TetrisPieceCfg cfg)
		{
			var pieceGO = GameObject.Instantiate(_piecePrefab.gameObject);
			var piece = pieceGO.GetComponent<TetrisPiece>();

			// Moving the piece to the origin is crucial to keep the initial block positioning easy
			pieceGO.transform.position = Vector3.zero;

			foreach (var blockPos in cfg.EnumerateBlockLocalPositions())
			{
				// The block is instantiated as a child of the tetris piece object, which means it's 
				// enough to move the piece and all of its blocks will move accordingly. This also goes
				// for rotation, scale etc.
				var blockGO = GameObject.Instantiate(_blockPrefab, pieceGO.transform);

				// We keep things very simple: Block's Transform's position (Unity's visual side) is
				// the same as the Block's position (in our Level side)
				blockGO.transform.position = new Vector2(blockPos.x, blockPos.y);
			}

			piece.Init(cfg);


			return piece;
		}
	}
}
