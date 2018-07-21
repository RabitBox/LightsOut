using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//---------------------------------------------
// 盤面クラス
// ボタンの配置や状態の管理
//---------------------------------------------
public class Board : MonoBehaviour
{
	private Button[,] _buttons;
	[SerializeField]
	private GameObject _button_prefab = null;
	private readonly int _number = 5;
	private readonly float _button_distance = 1.2f;

	//==================================================
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
			var _target = InputManager.Instance.GetRaycastHitObject(Input.mousePosition);

			if(_target != null)
			{
				if(_target.tag == "Button")
				{
					_target.GetComponent<Button>().SwitchLight();
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
				var _base_position = new Vector3(
					((float)(this._buttons.GetLength(0) / 2) * -_button_distance),
					((float)(this._buttons.GetLength(0) / 2) * -_button_distance));

				var _sequence = from row	in Enumerable.Range(0, this._buttons.GetLength(0))
								from column in Enumerable.Range(0, this._buttons.GetLength(1))
								select new { row, column };

				foreach (var _index in _sequence)
				{
					var _created_object = Instantiate(_button_prefab, this.transform);
					_created_object.transform.position = (new Vector3(_index.column, _index.row) * _button_distance) + _base_position;
					this._buttons[_index.row, _index.column] = _created_object.GetComponent<Button>();
				}
			}
		}
	}
}
