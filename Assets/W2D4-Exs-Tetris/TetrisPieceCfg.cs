using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace W2D3.Exs.Tetris
{
	[CreateAssetMenu(fileName = nameof(TetrisPieceCfg), menuName = nameof(TetrisPieceCfg))]
	public class TetrisPieceCfg : ScriptableObject
	{
		[SerializeField, TextArea(4, 4)] string _blockScheme;


        public bool[][] GetBlocks()
		{
			var lines = GetCleanScheme().Split('\n');
			var nLines = lines.Length;
			var result = new bool[nLines][];
			for (int i = 0; i < nLines; i++)
			{
				var line = lines[i];
				var lineChars = line.ToCharArray();
				result[i] = Array.ConvertAll(lineChars, c => c != '0');
			}

			return result;
		}

		public IEnumerable<Vector2Int> EnumerateBlockLocalPositions()
		{
			var blocks = GetBlocks();
			for (int y = 0; y < blocks.Length; y++)
			{
				for (int x = 0; x < blocks[y].Length; x++)
				{
					if (blocks[y][x])
						yield return new Vector2Int(x, y);
				}
			}
		}

		string GetCleanScheme()
		{
			return _blockScheme.Trim().Replace(" ", "");
		}
	}
}
