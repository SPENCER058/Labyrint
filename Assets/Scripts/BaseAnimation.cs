using UnityEngine;

public class BaseAnimation : ScriptableObject
{
	[SerializeField] protected float duration = 1 ;

	public virtual void Animate (Transform visual) {

	}
}
