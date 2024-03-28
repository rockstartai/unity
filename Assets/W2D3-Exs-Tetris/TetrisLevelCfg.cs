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
		[SerializeField] Vector2Int _spawnPoint;
		[SerializeField] Vector2Int _gravity;
		[SerializeField] float _speed;


		public float SecondsPerStep => 1f / _speed;
	}
}
