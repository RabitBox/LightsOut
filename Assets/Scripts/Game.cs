using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの進行管理クラス
/// </summary>
[RequireComponent(typeof(ButtonManager))]
public class Game : MonoBehaviour
{
	/// <summary>
	/// ゲームモード
	/// </summary>
	enum Mode
	{
		Play,
		Clear,
		Pause,
	}

	[SerializeField]
	private Mode _nowMode = Mode.Play;
	private ButtonManager _buttonManager = null;

	// Start is called before the first frame update
	void Start()
	{
		_buttonManager = this.gameObject.GetComponent<ButtonManager>();
	}

    // Update is called once per frame
    void Update()
    {
		OnClick();
	}

	/// <summary>
	/// クリックされた時の処理
	/// </summary>
	private void OnClick()
	{
		if (_nowMode == Mode.Play)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_buttonManager.OnClick(InputManager.Instance.GetRaycastHitObject(Input.mousePosition));
				if (_buttonManager.IsCheckButtonsOff())
				{
					_nowMode = Mode.Clear;
				}
			}
		}	
	}


}
