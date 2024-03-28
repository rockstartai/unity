
using System.Collections.Generic;

namespace W2D3.Exs.Tetris
{
	public interface ITetrisSolidifiedPiecesHolder
	{
		IReadOnlyList<TetrisPiece> Pieces { get; }

		void Solidify(TetrisPiece piece);
	}
}
