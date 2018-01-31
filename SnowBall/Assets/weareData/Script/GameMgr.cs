using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {

	enum GameStatus {
		Title,
		Tutorial,
		Start,
		Game,
		Clear
	};
	[SerializeField] GameObject _op_sound;
	[SerializeField] GameObject _title;
	[SerializeField] GameObject _tutorial_targets;
	[SerializeField] GameObject _targets;
	[SerializeField] TextMesh _timer;
	[SerializeField] GameStatus _status;
	[SerializeField] int GAME_TIME = 60;
	[SerializeField] TargetMgr _target_mgr;
	[SerializeField] TextMesh _result;
	[TextArea(1, 3)][SerializeField] string[ ] _comment = new string[ 5 ];
	float _game_time;
	int _hit_num;
	GameObject _create_targets = null;

	// Use this for initialization
	void Start ( ) {
		_status = GameStatus.Title;
		_game_time = 0;
		_hit_num = 0;
	}

	private void Update( )
	{
		updateGame( );
		draw( );
	}	

	private void updateGame( ) {
		switch ( _status ) {
			case GameStatus.Title:
				if( Input.GetKeyDown( KeyCode.Return ) ) {
					_status = GameStatus.Tutorial;
					Destroy(_title);
					Destroy(_op_sound);
				}
				break;
			case GameStatus.Tutorial:
				if( Input.GetKeyDown( KeyCode.Return ) ) {
					_status = GameStatus.Start;
					Destroy( _tutorial_targets );
					_create_targets = Instantiate( _targets );
					_result.text = "Game Start";
				}
				break;
			case GameStatus.Start:
				_game_time += Time.deltaTime;
				if ( _game_time > 1 ) {
					_result.text = "";
					_status = GameStatus.Game;
					_game_time = 0;
				}
				break;
			case GameStatus.Game:
				_game_time += Time.deltaTime;
				if ( GAME_TIME - _game_time < -1 ) {
					_timer.text = "";
					_hit_num = _target_mgr.getHitCount( );
					Destroy( _create_targets );
					_status = GameStatus.Clear;
				}
				break;
			case GameStatus.Clear:
				if( Input.GetKeyDown( KeyCode.Return ) ) {
					SceneManager.LoadScene(0);
				}
				break;
		}
	}

	private void draw( ) {
		switch ( _status ) {
			case GameStatus.Title:
				break;
			case GameStatus.Tutorial:
				break;
			case GameStatus.Start:
				break;
			case GameStatus.Game:
				_timer.text = ( GAME_TIME - ( int )_game_time ).ToString( );
				break;
			case GameStatus.Clear:
				drawResult( );
				break;
		}
	}

	private void drawResult( ) {
		if ( _hit_num <= 3 ) {
			_result.text = _comment[ 0 ];
		}

		if ( _hit_num >= 4 &&
			 _hit_num <= 15 ) {
			_result.text = _comment[ 1 ];
		}

		if ( _hit_num >= 16 &&
			 _hit_num <= 30 ) {
			_result.text = _comment[ 2 ];
		}

		if ( _hit_num >= 31 &&
			 _hit_num <= 45 ) {
			_result.text = _comment[ 3 ];
		}

		if ( _hit_num >= 46 ) {
			_result.text = _comment[ 4 ];
		}
	}
}
