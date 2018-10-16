using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	private bool _isLight = true;
	public bool IsLight { get { return this._isLight; } }
	MeshRenderer _renderer = null;

	[SerializeField] GameData _data = null;

	// Use this for initialization
	private void Start()
	{
		_renderer = this.transform.GetChild(0).GetComponent<MeshRenderer>();
		
	}

	public void SwitchLight()
	{
		_isLight = (_isLight == true) ? 
			false :
			true;

		// 仮実装
		SwitchMaterial();
	}

	// マテリアルを入れ替える
	public void SwitchMaterial()
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