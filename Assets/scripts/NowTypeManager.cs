using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowTypeManager : MonoBehaviour
{
	public GameObject[] children;
	private Animator anim;
	private int oldType = -1;
	void Awake()
	{
		GameObject parentObject = this.gameObject;
		var parent = this.transform;
		children  = new GameObject[parent.childCount];
		// 子オブジェクトを格納する配列作成
		var childIndex = 0;
		// 子オブジェクトを順番に配列に格納
		foreach (Transform child in parent)
		{
			children[childIndex++] = child.gameObject;
		}
		anim = GetComponent<Animator>();
	}

	public void SetType(string nowTypeSt){
		int nowType = int.Parse(nowTypeSt);
		if(oldType != -1) children[oldType].SetActive(false);
		oldType = nowType;
		children[oldType].SetActive(true);
		anim.SetBool("ChangeType", true);
		StartCoroutine(SetTypeAnimFin());
	}
	IEnumerator SetTypeAnimFin(){
		yield return new WaitForSeconds(0.1f);
		anim.SetBool("ChangeType", false);
	}

}
