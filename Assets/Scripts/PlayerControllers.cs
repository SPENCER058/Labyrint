using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllers : MonoBehaviour
{

	[SerializeField] private int score = 0;

	public Action<int> AddScore;

	private void Start () {
		score = 0;
	}

	private void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.CompareTag("Coin")) {
			collision.gameObject.SetActive(false);
			int scoreGet = collision.gameObject.GetComponentInChildren<Coin>().GetCoinValue();
			score = score + scoreGet;
			AddScore.Invoke(score);
		}
	}
}
