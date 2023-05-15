using TMPro;
using UnityEngine;

public class WaitCountText : MonoBehaviour
{
	[SerializeField] TMP_Text text;

	public void UpdateWaitText (int value) {
		text.text = "wait: " + value.ToString () + "s";
	}
}
