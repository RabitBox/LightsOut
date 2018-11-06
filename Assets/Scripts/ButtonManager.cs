using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ボタンの配置や管理を行うクラス
/// </summary>
public class ButtonManager : MonoBehaviour
{
	[SerializeField] private Button[,] _buttons;
	[SerializeField] private GameObject _buttonPrefab = null;

	private readonly int NUMBER = 5;
	private readonly float BUTTON_DISTANCE = 1.25f;

	private int[,] _switchTable = { {0, 1}, {0, -1}, {1, 0}, {-1, 0} };

	//==================================================
	// Use this for initialization
	void Start()
	{
		CreateButtons();
	}

	// Update is called once per frame
	void Update()
	{
		Click();
	}

	/// <summary>
	/// 画面をクリックされたときの処理
	/// </summary>
	private void Click()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var target = InputManager.Instance.GetRaycastHitObject(Input.mousePosition);

			if(target != null)
			{
				if(target.tag == "Button")
				{
					var button = target.GetComponent<Button>();
					button.SwitchLight();

					this.SwitchButtons(target);
				}
			}
		}
	}

	/// <summary>
	/// 全てのボタンの状態をチェックする
	/// </summary>
	/// <returns>光っているボタンがあるか否か</returns>
	private bool CheckButtons()
	{
		var sequence =	from row	in Enumerable.Range(0, this._buttons.GetLength(0))
						from column in Enumerable.Range(0, this._buttons.GetLength(1))
						select new { row, column };

		foreach(var index in sequence)
		{
			if(this._buttons[index.row, index.column].IsLight)
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// ボタンの光を切り替える
	/// </summary>
	private void SwitchButtons(GameObject button)
	{
		var sequence =	from row	in Enumerable.Range(0, this._buttons.GetLength(0))
						from column in Enumerable.Range(0, this._buttons.GetLength(1))
						select new { row, column };
		foreach (var buttonsIndex in sequence)
		{
			// 取得したゲームオブジェクトを配列内から探す
			// 一致したものと、その上下左右の色を変更する
			if (this._buttons[buttonsIndex.row, buttonsIndex.column].GetInstanceID() == button.gameObject.GetInstanceID())
			{
				
				foreach (var tableIndex in _switchTable)
				{

				}
			}
		}
	}

	/// <summary>
	/// ボタンを生成する
	/// </summary>
	private void CreateButtons()
	{
		// ボタンを登録する配列の初期化
		_buttons = new Button[NUMBER, NUMBER];

		if (_buttonPrefab != null)
		{
			// ボタンを配置する起点となる座標
			var basePosition = new Vector3(
				((float)(this._buttons.GetLength(0) / 2) * -BUTTON_DISTANCE),
				((float)(this._buttons.GetLength(1) / 2) * -BUTTON_DISTANCE));

			var sequence =	from row	in Enumerable.Range(0, this._buttons.GetLength(0))
							from column in Enumerable.Range(0, this._buttons.GetLength(1))
							select new { row, column };

			foreach (var index in sequence)
			{
				var createdObject = Instantiate(_buttonPrefab, this.transform);
				createdObject.transform.position = (new Vector3(index.column, index.row) * BUTTON_DISTANCE) + basePosition;
				this._buttons[index.row, index.column] = createdObject.GetComponent<Button>();
			}
		}
	}
}
