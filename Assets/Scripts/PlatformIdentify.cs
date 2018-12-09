using UnityEngine;

/// <summary>
/// プラットフォーム識別クラス
/// 指定したプラットフォーム以外であった場合に、シーン上から削除する
/// </summary>
public class PlatformIdentify : MonoBehaviour
{
	[SerializeField] private RuntimePlatform _targetPlatform = RuntimePlatform.WindowsEditor;

	private void Awake()
	{
		if (Application.platform == _targetPlatform)
		{
			Destroy(this);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}