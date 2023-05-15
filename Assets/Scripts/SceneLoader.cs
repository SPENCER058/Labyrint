using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void RestartLevel () {
		var scene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(scene);
	}
}
