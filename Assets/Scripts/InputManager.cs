using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehavior<InputManager>
{
	/// <summary>
	/// レイキャストを飛ばし、当たったゲームオブジェクトの情報を取得する
	/// </summary>
	/// <param name="screenPosition"> レイキャストを飛ばすスクリーン座標 </param>
	/// <returns> ヒットしたGameObject </returns>
	public GameObject GetRaycastHitObject(Vector3 screenPosition)
	{
		var ray = Camera.main.ScreenPointToRay(screenPosition);
		RaycastHit raycastHit;

		Physics.Raycast(ray, out raycastHit);

		if (raycastHit.collider != null)
		{
			return raycastHit.collider.gameObject;
		}
		return null;
	}
}
