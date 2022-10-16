using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
	public HP hp;
	public Slider slider;
	public GameObject hpObj;
	void Start()
	{
		hp = new HP(100);
		hpObj = this.transform.Find("HP").gameObject;
		slider = hpObj.GetComponent<Slider>();
		slider.value = 1;
	}

	void Update()
	{
		hp.heal(0.0f);
	}

	public void attack(float power){
		slider.value = hp.damage(power);
		if(hp.checkLose()){
			SceneManager.LoadScene("ClearScene",LoadSceneMode.Additive);
			StartCoroutine(CoUnload());
		}
	}

	IEnumerator CoUnload()
	{
		var op = SceneManager.UnloadSceneAsync("GameScene");
		yield return op;
		yield return Resources.UnloadUnusedAssets();
	}
}
