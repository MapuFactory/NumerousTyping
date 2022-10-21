using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class nyuryoku : MonoBehaviour
{
	private DisplayQuiz displayquiz;
	private char beforeChar;

	public bool isHantei;
	public int n;

	void Start()
	{
		displayquiz = GetComponent<DisplayQuiz>();
		n = 0;
		isHantei = false;
	}

	/*public void nyuryokuHantei(string inputSt){
		keyst = inputSt;
		if(!hantei())	return;
		quiz.Next();
		mondai = new string(quiz.mondaiKaki.ToCharArray());
		N = mondai.Length;
		n = 0;
	}*/

	public void hantei(char keyChar, ref string mondai)
	{
		isHantei = false;
		displayquiz.henkan(beforeChar, n, keyChar, ref mondai);
		if(keyChar == KeyCode.Space){
			
		}
		if(mondai[n] != keyChar)	return;
		beforeChar = mondai[n];
		displayquiz.changeColor(n, mondai);
		n++;
		isHantei = true;
	}

}
