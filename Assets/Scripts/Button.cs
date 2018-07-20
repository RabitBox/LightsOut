using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	private bool _isLight = true;	// ボタンが光っているか
	public bool IsLight { get { return this._isLight; } }
	MeshRenderer _renderer;

	// Use this for initialization
	private void Start()
	{
		_renderer = this.gameObject.GetComponent<MeshRenderer>();
	}

	public void SwitchLight()
	{
		_isLight = (_isLight == true) ? 
			false :
			true;

		_renderer.material = (_isLight == true) ?
			Resources.Load<Material>("Materials/On") :
			Resources.Load<Material>("Materials/Off");
	}
}
