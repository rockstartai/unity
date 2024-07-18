namespace W2D3.Exs.Tetris
{
	public class TetrisPieceReachedGroundEvent 
	{
		public TetrisPiece Piece { get; }


		public TetrisPieceReachedGroundEvent(TetrisPiece piece)
		{
			Piece = piece;
		}
	}
}
