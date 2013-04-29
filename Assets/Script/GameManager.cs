using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public int gameState = 0;			// In this state, the code is waiting for : 0 = Piece selection, 1 = Piece animation, 2 = Player2/AI movement
	//private int activePlayer = 0;		// 0 = Player1, 1 = Player2, 2 = AI, to be used later
	private GameObject SelectedPiece;	// Selected Piece
	
	//Update SlectedPiece with the GameObject inputted to this function
	public void SelectPiece(GameObject _PieceToSelect)
	{
		// Change color of the selected piece to make it apparent. Put it back to white when the piece is unselected
		if(SelectedPiece)
		{
			SelectedPiece.renderer.material.color = Color.white;
		}
		SelectedPiece = _PieceToSelect;
		SelectedPiece.renderer.material.color = Color.red;
	}
	
	// Move the SelectedPiece to the inputted coords
	public void MovePiece(Vector2 _coordToMove)
	{
		SelectedPiece.transform.position = _coordToMove;		// Move the piece
		SelectedPiece.renderer.material.color = Color.white;	// Change it's color back
		SelectedPiece = null;									// Unselect the Piece
	}
	
	// Change the state of the game
	public void ChangeState(int _newState)
	{
		gameState = _newState;
		Debug.Log ("GameState = " + _newState);
	}
}
