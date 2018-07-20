using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehavior<GameController>
{
	private List<Button> _buttons = new List<Button>();

	RaycastHit _raycast_hit = new RaycastHit();

	// Use this for initialization
	void Start()
	{

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
		foreach(var _button in _buttons)
		{
			if(_button.IsLight)
			{
				return false;
			}
		}
		return true;
	}
}
