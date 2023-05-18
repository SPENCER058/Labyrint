using UnityEngine;

[CreateAssetMenu(fileName = "Coin Data", menuName = "Custom Asset/Coin Data")]

public class CoinData : ScriptableObject
{
	public int value;

	public Material material;

	public int GetValue() {
		return value;
	}
}
