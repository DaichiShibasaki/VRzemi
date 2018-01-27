using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {

	enum GameStatus {
		Start,
		Game,
		Clear,
		Reset
	};

	[SerializeField] GameObject GET_TEXT;
	[SerializeField] GameStatus _status;
	[SerializeField] float GAME_TIME = 10;
	float _game_time;

	// Use this for initialization
	void Start ( ) {
		_status = GameStatus.Start;
		_game_time = 0;
	}

	private void Update( )
	{
		_status = GameStatus.Game;
		GAME_TIME -= Time.deltaTime;
		GET_TEXT.GetComponent<TextMesh>().text = ( ( int )GAME_TIME ).ToString( );
		if( GAME_TIME < 1 ) {
			_status = GameStatus.Clear;
			GAME_TIME = 0.0f;
		}
		if( _status == GameStatus.Clear && Input.GetKey ( KeyCode.Return ) ) {
			Debug.Log("NowLoading");
			SceneManager.LoadScene(0);
		}
	}	
}
