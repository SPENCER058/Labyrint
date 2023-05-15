using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CountDown : MonoBehaviour
{
	[SerializeField] int duration;

	public UnityEvent OnCountFinished = new UnityEvent();
	public UnityEvent<int> OnCount = new UnityEvent<int>();

	private bool isCounting;
	Sequence seq;

	private void Start () {
		duration = 3;
	}

	public void StartCount () {

		if (isCounting == true) {
			return;
		} else {
			isCounting = true;
		}
		DOTween.Kill(seq);

		seq = DOTween.Sequence();
;
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
			.OnComplete(() => OnCountFinished.Invoke());

	}
}
