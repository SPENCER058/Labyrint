using TMPro;
using UnityEngine;

public class OrientationTest : MonoBehaviour
{

    [SerializeField] TMP_Text systemInfoText;

    [SerializeField] enum Mode {
        gravity, 
        acceleration, 
        userAcceleration, 
        rotationRate, 
        rotationRateUnbiased, 
        attitude
	}

    void Start()
    {
        systemInfoText.text = "Sensors : ";
		if (SystemInfo.supportsAccelerometer) {
			systemInfoText.text += "Accelerometer ";
		}

		if (SystemInfo.supportsGyroscope) {
			systemInfoText.text += "+ Gyroscope ";
            Input.gyro.enabled = true;
		}
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.rotation = Input.gyro.attitude;
    }
}
