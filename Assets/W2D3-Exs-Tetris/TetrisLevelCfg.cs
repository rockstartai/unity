using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W2D3.Exs.Tetris
{
	[CreateAssetMenu(fileName = nameof(TetrisLevelCfg), menuName = nameof(TetrisLevelCfg))]
	public class TetrisLevelCfg : ScriptableObject
	{
		[SerializeField] Vector2Int _size;
		[SerializeField] Vector2Int _spawnPos;
		[SerializeField] float _gravitySpeed;
		[SerializeField] TetrisPieceCfg[] _pieces;


		public Vector2Int Size => _size;
		public Vector2Int SpawnPos => _spawnPos;
		public float SecondsPerGravityStep => 1f / _gravitySpeed;
		public IReadOnlyList<TetrisPieceCfg> Pieces => _pieces;
	}
}
