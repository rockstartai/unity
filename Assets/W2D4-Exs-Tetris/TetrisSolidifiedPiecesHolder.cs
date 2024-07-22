
using System.Collections.Generic;

namespace W2D3.Exs.Tetris
{
	public class TetrisSolidifiedPiecesHolder : ITetrisSolidifiedPiecesHolder
	{
		public IReadOnlyList<TetrisPiece> Pieces => _solidifiedPieces;

		List<TetrisPiece> _solidifiedPieces = new();


		public void Solidify(TetrisPiece piece)
		{
			_solidifiedPieces.Add(piece);
		}
	}
}
