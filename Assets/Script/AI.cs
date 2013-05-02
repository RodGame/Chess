using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	private GameManager _GameManager; 	// GameObject responsible for the management of the game
	private int _activePlayer;
	private bool _player1AI;
	private bool _player2AI;
	
	// Use this for initialization
	void Start () 
	{
		_GameManager = gameObject.GetComponent<GameManager>();
		_player1AI = _GameManager.player1AI;
		_player2AI = _GameManager.player2AI;
	}
	
	// Update is called once per frame
	void Update () {
	
		if((_activePlayer == 1 && _player1AI == true) || (_activePlayer == -1 && _player2AI == true))
		{
			CalculateMove();
		}
		
		
		
	}
	
	void CalculateMove()
	{
		
	}
	
	
	
}
