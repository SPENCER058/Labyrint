using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;

public class CountDown : MonoBehaviour
{
	[SerializeField] int duration;

	public UnityEvent OnCountFinished = new UnityEvent();
	public UnityEvent<int> OnCount = new UnityEvent<int>();

	private bool isCounting;
	Sequence seq;

	//[SerializeField]private bool test = false;

	public void StartCount () {
/*		if (isCounting == true) {
			StopAllCoroutines();
		}*/

		StartCoroutine(CountCoroutine());
	}

	private IEnumerator CountCoroutine () {

		isCounting = true;
		for (int i = duration; i >= 0; i--) {
			OnCount.Invoke(i);
			yield return new WaitForSecondsRealtime(1);
		}

		isCounting = false;
		OnCountFinished.Invoke();
	}

	/*
		public void StartCount () {

			if (isCounting == true) {
				return;
			} else {
				isCounting = true;
			}

			seq = DOTween.Sequence();

			OnCount.Invoke(duration);
			for (int i = duration - 1; i >= 0; i--) {

				var count = i;
				seq.Append(transform
					.DOMove(this.transform.position, 1)
					.SetUpdate(true)
					.OnComplete(() => OnCount.Invoke(count)));
			}

			seq.Append(transform.DOMove(this.transform.position, 1))
				.SetUpdate(true)
				.OnComplete(() => {
					isCounting = false;
					OnCountFinished.Invoke();
				});
		}
	*/


}
