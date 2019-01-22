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
	private GameObject _pause;
	[SerializeField]
	private GameObject _clear;
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
		switch (_nowMode)
		{
			case Mode.Play:
				OnClick();
				break;

			case Mode.Clear:
				if (_clear.activeSelf == false)
				{
					_clear.SetActive(true);
				}
				break;

			case Mode.Pause:
				if (_pause.activeSelf == false)
				{
					_pause.SetActive(true);
				}
				break;
		}
	}

	/// <summary>
	/// クリックされた時の処理
	/// </summary>
	private void OnClick()
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


	public void OnClick_Pause()
	{
		_nowMode = _nowMode == Mode.Play ? Mode.Pause : Mode.Play;
	}

	public void OnClick_Retry()
	{
		_nowMode = Mode.Play;
		_buttonManager.SwitchAllButtons(true);
	}
}
