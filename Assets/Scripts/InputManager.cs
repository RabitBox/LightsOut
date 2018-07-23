using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehavior<InputManager>
{
	// レイキャストを飛ばし、当たったゲームオブジェクトの情報を取得する
	public GameObject GetRaycastHitObject(Vector3 _screen_position)
	{
		var _ray = Camera.main.ScreenPointToRay(_screen_position);
		RaycastHit _raycast_hit;

		Physics.Raycast(_ray, out _raycast_hit);

		if (_raycast_hit.collider != null)
		{
			return _raycast_hit.collider.gameObject;
		}
		return null;
	}
}
