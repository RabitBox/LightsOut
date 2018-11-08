using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Use Data Table")]
public class GameData : ScriptableObject
{
	[SerializeField] private Material _buttonOnMaterial;
	[SerializeField] private Material _buttonOffMaterial;

	public Material ButtonOnMaterial { get { return _buttonOnMaterial; } }
	public Material ButtonOffMaterial { get { return _buttonOffMaterial; } }
}
