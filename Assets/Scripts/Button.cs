using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	private bool _isLight = true;	// ボタンが光っているか
	public bool IsLight { get { return this._isLight; } }

	public void SwitchLight()
	{
		_isLight = (_isLight == true) ? false : true;
	}
}
