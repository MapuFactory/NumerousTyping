using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStartScript : MonoBehaviour
{
	public  bool isStart;
	// Start is called before the first frame update
	void  Awake()
	{
		isStart = false;
		StartCoroutine(WaitStart());
	}

	// Update is called once per frame
	IEnumerator WaitStart()
	{
		while(!Input.GetKeyDown(KeyCode.Space)) {
			yield return null;
		}
		isStart = true;
	}
}
