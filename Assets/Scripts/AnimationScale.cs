using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation Scale", menuName = "Custom Asset/Animation/Scale")]

public class AnimationScale : BaseAnimation
{
	public override void Animate (Transform visual) {
		base.Animate(visual);

		visual.parent.DOScale(2f, base.duration).SetLoops(-1, LoopType.Yoyo);
	}
}
