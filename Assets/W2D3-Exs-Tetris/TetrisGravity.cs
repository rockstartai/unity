using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	public class TetrisGravity : MonoBehaviour
	{
		TetrisLevelCfg _lvl;
		IActiveTetrisPieceProvider _activeTetrisPieceProvider;


		public void Initialize(
			TetrisLevelCfg lvl, 
			IActiveTetrisPieceProvider activeTetrisPieceProvider
			) 
		{
			_lvl = lvl;
			_activeTetrisPieceProvider = activeTetrisPieceProvider;
			StartCoroutine()
		}

		IEnumerator GravityLoop()
		{
			var delay = new WaitForSeconds(_lvl.SecondsPerStep);
			while (true)
			{
				yield return delay;
				ApplyGravityStep();
			}
		}

		void ApplyGravityStep()
		{
			if (_activeTetrisPieceProvider == null)
				return;

			var activePiece = _activeTetrisPieceProvider.ActivePiece;

			if (activePiece == null)
				return;

			activePiece.

		}


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
