using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	
	private Camera PlayerCam;			// Camera used by the player
	private GameManager _GameManager; 	// GameObject responsible for the management of the game
	
	// Use this for initialization
	void Start () 
	{
		PlayerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Find the Camera's GameObject from its tag 
		_GameManager = gameObject.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// Look for Mouse Inputs
		GetMouseInputs();
		
	}
	
	// Detect Mouse Inputs
	void GetMouseInputs()
	{	
		Ray _ray;
		RaycastHit _hitInfo;
		
		// Select a piece if the gameState is 0 or 1
		if(_GameManager.gameState < 2)
		{
			// On Left Click
			if(Input.GetMouseButtonDown(0))
			{
				_ray = PlayerCam.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click
				
				// Raycast and verify that it collided
				if(Physics.Raycast (_ray,out _hitInfo))
				{
					// Select the piece if it has the good Tag
					if(_hitInfo.collider.gameObject.tag == ("PiecePlayer1"))
					{
						_GameManager.SelectPiece(_hitInfo.collider.gameObject);
						_GameManager.ChangeState (1);
					}
				}
			}
		}
		
		// Move the piece if the gameState is 1
		if(_GameManager.gameState == 1)
		{
			Vector2 selectedCoord;
			
			// On Left Click
			if(Input.GetMouseButtonDown(0))
			{
				_ray = PlayerCam.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click
				
				// Raycast and verify that it collided
				if(Physics.Raycast (_ray,out _hitInfo))
				{
					
					// Select the piece if it has the good Tag
					if(_hitInfo.collider.gameObject.tag == ("Cube"))
					{
						selectedCoord = new Vector2(_hitInfo.collider.gameObject.transform.position.x,_hitInfo.collider.gameObject.transform.position.y);
						_GameManager.MovePiece(selectedCoord);
						_GameManager.ChangeState (0);
					}
				}
			}	
		}
	}
}
