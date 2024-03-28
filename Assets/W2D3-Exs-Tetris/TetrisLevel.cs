using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisLevel : MonoBehaviour
	{
		TetrisLevelCfg _cfg;
		TetrisPieceFactory _pieceFactory;
		ITetrisActivePieceHolder _activePieceHolder;
		ITetrisSolidifiedPiecesHolder _solidifiedPiecesHolder;


		public void Init(TetrisSignalBus signalBus, TetrisLevelCfg cfg, TetrisPieceFactory pieceFactory, 
			ITetrisActivePieceHolder activePieceHolder, 
			ITetrisSolidifiedPiecesHolder solidifiedPiecesHolder)
		{
			_cfg = cfg;
			_pieceFactory = pieceFactory;
			_activePieceHolder = activePieceHolder;
			_solidifiedPiecesHolder = solidifiedPiecesHolder;

			signalBus.Subscribe<TetrisPieceReachedGroundEvent>(OnPieceReachedGround);
			SpawnNextPiece();
		}

		void OnPieceReachedGround(TetrisPieceReachedGroundEvent _)
		{
			_solidifiedPiecesHolder.Solidify(_activePieceHolder.Piece);
			SpawnNextPiece();
		}


		void SpawnNextPiece()
		{
			var nPieces = _cfg.Pieces.Count;
			var nextSpawnedPieceIndex = UnityEngine.Random.Range(0, nPieces);
			var nextSpawnedPieceCfg = _cfg.Pieces[nextSpawnedPieceIndex];
			_activePieceHolder.Piece = _pieceFactory.Create(nextSpawnedPieceCfg);
			_activePieceHolder.Piece.Position = _cfg.SpawnPos;
		}
	}
}
