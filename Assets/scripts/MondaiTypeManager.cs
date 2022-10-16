using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MondaiTypeManager : MonoBehaviour
{
	public GameObject[] children;
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
	}

	public void SetType(string nowTypeSt){
		int nowType = int.Parse(nowTypeSt);
		if(oldType != -1) children[oldType].SetActive(false);
		children[nowType].SetActive(true);
		oldType = nowType;
		//anim.SetBool("SetType", true);
		//anim.SetBool("SetType", false);
	}



}
