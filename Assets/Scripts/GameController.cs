using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : SingletonMonoBehavior<GameController>
{
	private Button[,] _buttons;
	[SerializeField]
	private GameObject _button_prefab = null;
	private readonly int _number = 5;
	private readonly float _button_distance = 1.2f;

	RaycastHit _raycast_hit = new RaycastHit();

	// Use this for initialization
	void Start()
	{
		_buttons = new Button[_number, _number];
		CreateButtons();
	}

	// Update is called once per frame
	void Update()
	{
		Click();
	}

	// 画面をクリックされたときの処理
	private void Click()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(_ray, out _raycast_hit);
			if(_raycast_hit.collider != null)
			{
				if (_raycast_hit.collider.tag == "Button")
				{
					_raycast_hit.collider.gameObject.GetComponent<Button>().SwitchLight();
				}
			}
		}
	}

	// ボタンの状態をチェックする
	// return[0] : 光っているボタンがある
	// return[1] : ボタンが全て消えている
	private bool CheckButtons()
	{
		var _sequence =	from row	in Enumerable.Range(0, this._buttons.GetLength(0))
						from column in Enumerable.Range(0, this._buttons.GetLength(1))
						select new { row, column };

		foreach(var _index in _sequence)
		{
			if(this._buttons[_index.row, _index.column].IsLight)
			{
				return false;
			}
		}
		return true;
	}

	// ボタンを生成する
	private void CreateButtons()
	{
		if(this._buttons != null)
		{
			if(_button_prefab != null)
			{
				var _sequence = from row	in Enumerable.Range(0, this._buttons.GetLength(0))
								from column in Enumerable.Range(0, this._buttons.GetLength(1))
								select new { row, column };

				foreach (var _index in _sequence)
				{
					var _created_object = Instantiate(_button_prefab, this.transform);
					_created_object.transform.position = new Vector3(_index.column, _index.row) * _button_distance;
					this._buttons[_index.row, _index.column] = _created_object.GetComponent<Button>();
				}
			}
		}
	}
}
