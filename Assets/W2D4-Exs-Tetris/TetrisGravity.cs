using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisGravity : MonoBehaviour
	{
		TetrisSignalBus _signalBus;
		TetrisLevelCfg _lvl;
		ITetrisActivePieceHolder _activePieceHolder;
		TetrisPieceMover _mover;


		public void Init(TetrisSignalBus signalBus, TetrisLevelCfg lvl, ITetrisActivePieceHolder activePieceHolder,
			TetrisPieceMover mover) 
		{
			_signalBus = signalBus;
			_lvl = lvl;
			_activePieceHolder = activePieceHolder;
			_mover = mover;
			StartCoroutine(GravityLoop());
		}

		IEnumerator GravityLoop()
		{
			var delay = new WaitForSeconds(_lvl.SecondsPerGravityStep);
			while (true)
			{
				yield return delay;
				Debug.Log("Step");
				ApplyGravityStep();
			}
		}

		void ApplyGravityStep()
		{
			if (_activePieceHolder == null)
				return;

			var activePiece = _activePieceHolder.Piece;
			if (activePiece == null)
				return;

			var succeeded = _mover.TryMove(activePiece, Vector2Int.down);
			var reachedGround = !succeeded;
			if (reachedGround)
				_signalBus.Publish(new TetrisPieceReachedGroundEvent(activePiece));
		}
	}
}
