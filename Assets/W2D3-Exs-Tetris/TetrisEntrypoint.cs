using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisEntrypoint : MonoBehaviour
	{
		[SerializeField] TetrisLevelCfg _levelCfg;
		[SerializeField] TetrisLevel _level;
		[SerializeField] TetrisPieceFactory _pieceFactory;
		[SerializeField] TetrisGravity _gravity;
		[SerializeField] TetrisInput _input;


		void Start()
		{
			var signalBus = new TetrisSignalBus();
			var activePieceHolder = new TetrisActivePieceHolder();
			var solidifiedPiecesHolder = new TetrisSolidifiedPiecesHolder();
			var physics = new TetrisPhysics(_levelCfg, solidifiedPiecesHolder);
			var mover = new TetrisPieceMover(physics);

			_gravity.Init(signalBus, _levelCfg, activePieceHolder, mover);
			_input.Init(mover);
			_level.Init(signalBus, _levelCfg, _pieceFactory, activePieceHolder, solidifiedPiecesHolder);
		}
	}
}
