using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンに関連する処理をまとめたクラス
/// </summary>
public class Button : MonoBehaviour
{
	private bool _isLight = true;
	public bool IsLight { get { return this._isLight; } private set { _isLight = value; } }

	[SerializeField]
	MeshRenderer _renderer = null;

	[SerializeField] private GameData _data = null;

	/// <summary>
	/// ボタンの発光を切り替える
	/// </summary>
	public void SwitchLight()
	{
		IsLight = (IsLight == true) ? 
			false :
			true;

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
			_renderer.material = (IsLight == true) ?
				_data.ButtonOnMaterial :
				_data.ButtonOffMaterial;
		}
	}
}