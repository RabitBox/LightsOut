using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ボタンの配置や管理を行うクラス
/// </summary>
public class ButtonManager : MonoBehaviour
{
	[SerializeField] private LightButton[,] _buttons;
	[SerializeField] private GameObject _buttonPrefab = null;

	private readonly int NUMBER = 5;
	private readonly float BUTTON_DISTANCE = 1.25f;

	struct MatrixData { public int row; public int colomn; public MatrixData(int row, int colomn) { this.row = row; this.colomn = colomn; } }
	private MatrixData[] _switchTable = new MatrixData[]{ new MatrixData(0, 1), new MatrixData(0, -1), new MatrixData(1, 0), new MatrixData(-1, 0) };

	//==================================================
	// Use this for initialization
	void Start()
	{
		CreateButtons();
	}

	/// <summary>
	/// 全てのボタンの状態をチェックする
	/// </summary>
	/// <returns>光っているボタンがあるか否か</returns>
	public bool IsCheckButtonsOff()
	{
		return _buttons.Cast<LightButton>().All( X => X.IsLight == false );
	}

	/// <summary>
	/// ボタンの光を切り替える
	/// </summary>
	private void SwitchButtons(GameObject button)
	{
		if (button == null) return;

		var sequence =	from row	in Enumerable.Range(0, this._buttons.GetLength(0))
						from column in Enumerable.Range(0, this._buttons.GetLength(1))
						select new { row, column };

		foreach (var buttonIndex in sequence)
		{
			// 取得したゲームオブジェクトを配列内から探す
			// 一致したものと、その上下左右の色を変更する
			if (this._buttons[buttonIndex.row, buttonIndex.column].gameObject.GetInstanceID() == button.GetInstanceID())
			{
				this._buttons[buttonIndex.row, buttonIndex.column].SwitchLight();

				foreach (var data in _switchTable)
				{
					var row = (buttonIndex.row + data.row);
					row = (row < 0) ? 0 : (row > NUMBER - 1) ? NUMBER - 1 : row;
					var column = (buttonIndex.column + data.colomn);
					column = (column < 0) ? 0 : (column > NUMBER - 1) ? NUMBER - 1 : column;

					if (buttonIndex.row != row || buttonIndex.column != column)
					{
						this._buttons[row, column].SwitchLight();
					}
				}

				break;
			}
		}
	}

	/// <summary>
	/// 全てのボタンのモードを切り替える
	/// </summary>
	/// <param name="mode"></param>
	public void SwitchAllButtons(bool mode)
	{
		foreach (var button in _buttons)
		{
			if (button.IsLight != mode)
			{
				button.SwitchLight();
			}
		}
	}

	/// <summary>
	/// ボタンを生成する
	/// </summary>
	private void CreateButtons()
	{
		// ボタンを登録する配列の初期化
		_buttons = new LightButton[NUMBER, NUMBER];

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
				this._buttons[index.row, index.column] = createdObject.GetComponent<LightButton>();
			}
		}
	}

	/// <summary>
	/// 画面をクリックされたときの処理
	/// </summary>
	public void OnClick(GameObject target)
	{
		if (target != null)
		{
			if (target.tag == "Button")
			{
				this.SwitchButtons(target);
			}
		}
	}
}
