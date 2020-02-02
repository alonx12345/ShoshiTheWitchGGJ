using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {



	void Start(){
	}

	public void LoadLevel(string name)
	{
		Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(1);

    }
	
	public void QuitRequest(string name)
	{
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		//Application.LoadLevel(Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        


    }
	
	public void Reload () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
