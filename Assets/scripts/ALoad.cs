using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ALoad : MonoBehaviour
{
	private Scene gs;
	private GameObject playerUIObj;
	private GameObject enemyUIObj;
	private GameObject startUIObj;
	private GameObject canvasObj;
	private GameObject aishoUIObj;
	private SpaceStartScript sss;

	void Start()
	{
		if(SceneManager.GetSceneByName("GameScene").GetRootGameObjects().Length == 0) SceneManager.LoadScene("GameScene",LoadSceneMode.Additive);
		gs = SceneManager.GetSceneByName("GameScene");
		Debug.Log(gs.GetRootGameObjects().Length);
		foreach (var rootGameObject in gs.GetRootGameObjects())
		{
			sss = rootGameObject.GetComponent<SpaceStartScript>();
			if (sss != null)
			{
				startUIObj = rootGameObject;
				break;
			}
		}

		StartCoroutine(StartGame());
	}

	IEnumerator StartGame(){
		while(!sss.isStart) {
			yield return null;
		}
		canvasObj = GameObject.FindGameObjectWithTag("ui");
		playerUIObj = canvasObj.transform.Find("Player").gameObject;
		enemyUIObj = canvasObj.transform.Find("Enemy").gameObject;
		startUIObj = canvasObj.transform.Find("StartMessage").gameObject;
		aishoUIObj = canvasObj.transform.Find("AishoUI").gameObject;
		playerUIObj.SetActive(true);
		enemyUIObj.SetActive(true);
		startUIObj.SetActive(false);
		aishoUIObj.SetActive(true);
	}
}
