using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
	[SerializeField] GameObject finishedCanvas;
	[SerializeField] TMP_Text finishedText;
	[SerializeField] CustomEvent gameOverEvent;
	[SerializeField] CustomEvent playerWinEvent;

	int coin = 100;

	private void OnEnable () {
		gameOverEvent.OnInvoked.AddListener(GameOver);
		playerWinEvent.OnInvoked.AddListener(PlayerWin);
	}

	private void OnDisable () {
		gameOverEvent.OnInvoked.RemoveListener(GameOver);
		playerWinEvent.OnInvoked.RemoveListener(PlayerWin);
	}

	public void GameOver () {
		finishedText.text = "Game Over!";
		finishedCanvas.SetActive(true);
	}

	public void PlayerWin () {
		finishedText.text = "GOAL!";
		finishedCanvas.SetActive(true);
	}

	private int GetScore () {
		return coin * 1000;
	}
}
