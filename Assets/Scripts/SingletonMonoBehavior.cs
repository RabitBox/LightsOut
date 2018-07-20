using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : SingletonMonoBehavior<T>
{
	protected static T _instance = null;
	public static T Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = FindObjectOfType <T>();
			}
			return _instance;
		}
	}
}