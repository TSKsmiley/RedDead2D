using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneSwitcher : MonoBehaviour
{

	private float transitionTime = 1F;

	public GameObject fadeToBlack;

	public void StartGameClick()
	{
		fadeToBlack.SetActive(true);
		StartCoroutine(levelFade());
	}

	public void QuitGameClick()
	{
		Application.Quit();
	}



	IEnumerator levelFade()
	{
		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(1);
	}
}
