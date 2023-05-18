using System.Collections;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
	[Header("Canvas")]
	[SerializeField] GameObject finishedCanvas;

	[Header("Texts")]
	[SerializeField] TMP_Text finishedText;
	[SerializeField] TMP_Text scoreText;
	[SerializeField] TMP_Text startCountdownText;
	[SerializeField] TMP_Text timeLeftText;

	[Header("Times")]
	[SerializeField] float totalTime;

	[Header("Events")]
	[SerializeField] CustomEvent gameOverEvent;
	[SerializeField] CustomEvent playerWinEvent;

	[Header("Scripts")]
	[SerializeField] GravityController gravityController;
	[SerializeField] PlayerControllers playerControllers;

	int coin;
	float timeLeft;
	bool isTimeCountActive = false;

	private void Start () {
		timeLeft = totalTime;

		StartCoroutine(Countdown(4));
		gravityController.SetActive(false);
		coin = 0;
		scoreText.text = "Score : 0";
		timeLeftText.text = $"Times : {(int)timeLeft}";
	}

	private void Update () {
		if (isTimeCountActive == true) {
			timeLeft -= Time.deltaTime;
			timeLeftText.text = $"Times : {(int)timeLeft}";
		}

		if (timeLeft <= 0) {
			isTimeCountActive = false;
			GameOver();
		}
	}

	private void OnEnable () {
		gameOverEvent.OnInvoked.AddListener(GameOver);
		playerWinEvent.OnInvoked.AddListener(PlayerWin);
		playerControllers.AddScore += UpdateScore;
	}

	private void OnDisable () {
		gameOverEvent.OnInvoked.RemoveListener(GameOver);
		playerWinEvent.OnInvoked.RemoveListener(PlayerWin);
		playerControllers.AddScore -= UpdateScore;
	}

	private void UpdateScore (int obj) {
		scoreText.text = $"Score : {obj.ToString()}";
		coin++;
	}

	public void GameOver () {
		finishedText.text = $"Game Over!\nFinal Score : {GetScore()}\nTime Left : {(int)timeLeft}";
		finishedCanvas.SetActive(true);
		gravityController.SetActive(false);
		isTimeCountActive = false;
	}

	public void PlayerWin () {
		finishedText.text = $"GOAL!\nFinal Score : {GetScore() * 10}\nTime Left : {(int)timeLeft}";
		finishedCanvas.SetActive(true);
		gravityController.SetActive(false);
		isTimeCountActive = false;
	}

	private int GetScore () {
		return coin * 10;
	}

	private IEnumerator Countdown (int second) {

		int count = second;	

		while (count > 0) {

			// display something...
			yield return new WaitForSecondsRealtime(1);

			count--;
			if (count == 0) {
				startCountdownText.text = "GO";

			} else {
				startCountdownText.text = count.ToString();

			}

		}

		yield return new WaitForSecondsRealtime(1);
		startCountdownText.text = "";
		gravityController.SetActive(true);
		isTimeCountActive = true;

	}
}
