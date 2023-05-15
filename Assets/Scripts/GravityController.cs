using UnityEngine;

public class GravityController : MonoBehaviour
{
	[SerializeField] float acceleration = 9 * 8f;
	Vector3 gravityOffset;
	bool isActive = true;

	private void Start () {
		if (SystemInfo.supportsGyroscope) {
			Input.gyro.enabled = true;
		}
	}

	private void Update () {
		
		if (isActive) {
			Physics.gravity = GetGravityFromSensor() + gravityOffset;
		} else {
			Physics.gravity = Vector3.zero;
		}

		Physics.gravity = GetGravityFromSensor() + gravityOffset;
	}

	public void CallibrateGravity () {
		gravityOffset = Vector3.down * acceleration - GetGravityFromSensor();
	}

	private Vector3 GetGravityFromSensor () {
		Vector3 gravity;
		if (Input.gyro.gravity != Vector3.zero) {
			gravity = Input.gyro.gravity * acceleration;
		} else {
			gravity = Input.acceleration * acceleration;
		}
		gravity.z = Mathf.Clamp(gravity.z, float.MinValue, -1);
		return Physics.gravity = new Vector3(gravity.x, gravity.z, gravity.y);
	}

	public void SetActive(bool value) {
		isActive = value;
		if (value) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
	}
}
