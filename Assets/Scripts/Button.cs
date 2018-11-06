using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンに関連する処理をまとめたクラス
/// </summary>
public class Button : MonoBehaviour
{
	private bool _isLight = true;
	public bool IsLight { get { return this._isLight; } }

	[SerializeField]
	MeshRenderer _renderer = null;

	[SerializeField] private GameData _data = null;

	private bool _isClicked = false;
	public bool IsClicked
	{
		get { return _isClicked; }
		private set { _isClicked = value; }
	}

	// クリックされたときに外部で呼び出す
	public void Click()
	{
		IsClicked = true;
	}

	/// <summary>
	/// ボタンの発光を切り替える
	/// </summary>
	public void SwitchLight()
	{
		_isLight = (_isLight == true) ? 
			false :
			true;
		_isClicked = false;

		SwitchMaterial();
	}

	/// <summary>
	/// マテリアルを入れ替える
	/// </summary>
	private void SwitchMaterial()
	{
		if (_renderer != null
			&& _data != null)
		{
			_renderer.material = (_isLight == true) ?
				_data.ButtonOnMaterial :
				_data.ButtonOffMaterial;
		}
	}
}