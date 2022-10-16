using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DisplayQuiz : MonoBehaviour
{
	private Text mondaiToi;
	private Text mondaiKaki;
	private quiz quiz;
	private nyuryoku ny;

	private List<char> buffList = new List<char>();
	// Start is called before the first frame update
	void Awake(){
		mondaiToi = transform.GetChild(0).gameObject.GetComponent<Text>();
		mondaiKaki = transform.GetChild(1).gameObject.GetComponent<Text>();
		quiz = gameObject.GetComponent<quiz>();
		ny = gameObject.GetComponent<nyuryoku>();
	}
	void Start()
	{
		next();
	}

	public void next()
	{
		mondaiToi.text = quiz.mondaiToi;
		mondaiKaki.text = quiz.mondaiKaki;
	}
	public void resetColor()
	{
		mondaiToi.text = quiz.mondaiToi;
		mondaiKaki.text = quiz.mondaiKaki;
		ny.n = 0;
	}
	public void changeFontSize(bool isLock)
	{
		mondaiToi.fontSize = isLock ? 35 : 55;
		mondaiKaki.fontSize = isLock ? 25 : 45;
	}
	
	public void changeColor(int n, string mondai)
	{
		int N = mondai.Length;
		string mondaibaf = "";
		for(int i = 0; i < N; i++){
			if(i <= n){
				mondaibaf += "<color=#4169e1>" + mondai[i] + "</color>";
			}else{
				mondaibaf += mondai[i];
			}
		}
		mondaiKaki.text = mondaibaf;
	}

	
	public void henkan(char beforeChar, int n, char keyChar, ref string mondai)
	{
		buffList.Clear();
		if(keyChar == 'h'){
			if(beforeChar == 's' && mondai[n] == 'i'){
				buffList.AddRange(mondai);
				buffList.Insert(n, 'h');
				mondai = new string(buffList.ToArray());
			}
			if(beforeChar == 's' && mondai[n] == 'y'){
				char[] a = mondai.ToCharArray();
				a[n] = 'h';
				mondai = new string(a);
			}
			if(beforeChar == 'c' && mondai[n] == 'i'){
				buffList.AddRange(mondai);
				buffList.Insert(n, 'h');
				mondai = new string(buffList.ToArray());
			}
			if(mondai[n] == 'f'){
				
				char[] a = mondai.ToCharArray();
				a[n] = 'h';
				mondai = new string(a);
				if(mondai[n+1] != 'u'){
					buffList.AddRange(mondai);
					buffList.Insert(n+1, 'x');
					buffList.Insert(n+1, 'u');
					mondai = new string(buffList.ToArray());
				}
			}
		}

		if(keyChar == 'c'){
			if(mondai[n] == 'k' && mondai[n+1] == 'a'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				mondai = new string(a);
			}
			if(mondai[n] == 's' && mondai[n+1] == 'i'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				mondai = new string(a);
			}
			if(mondai[n] == 'k' && mondai[n+1] == 'u'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				mondai = new string(a);
			}
			if(mondai[n] == 's' && mondai[n+1] == 'e'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				mondai = new string(a);
			}
			if(mondai[n] == 'k' && mondai[n+1] == 'o'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				mondai = new string(a);
			}
			if(mondai[n] == 't' && mondai[n+1] == 'i'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				mondai = new string(a);
			}
			if(mondai[n] == 't' && mondai[n+1] == 'y' && mondai[n+2] != 'i'){
				char[] a = mondai.ToCharArray();
				a[n] = 'c';
				a[n+1] = 'h';
				mondai = new string(a);
			}
		}

		if(keyChar == 't'){
			if(mondai[n] == 'c' && mondai[n+1] == 'h'){
				if(mondai[n+2] == 'i'){
					char[] a = mondai.ToCharArray();
					a[n] = 't';
					mondai = new string(a);
					buffList.AddRange(mondai);
					buffList.RemoveAt(n+1);
					mondai = new string(buffList.ToArray());
				}else{
					char[] a = mondai.ToCharArray();
					a[n] = 't';
					a[n+1] = 'y';
					mondai = new string(a);
				}
			}
		}

		if(keyChar == 'j'){
			if(mondai[n] == 'z' && mondai[n+1] == 'i'){
				char[] a = mondai.ToCharArray();
				a[n] = 'j';
				mondai = new string(a);
			}else if(mondai[n] == 'z' && mondai[n+1] == 'y'){
				char[] a = mondai.ToCharArray();
				a[n] = 'j';
				mondai = new string(a);
				buffList.AddRange(mondai);
				buffList.RemoveAt(n+1);
				mondai = new string(buffList.ToArray());
				if(mondai[n+1] == 'i'){
					buffList.AddRange(mondai);
					buffList.Insert(n+1, 'x');
					buffList.Insert(n+1, 'i');
					mondai = new string(buffList.ToArray());
				}
			}
		}

		if(keyChar == 'z'){
			if(mondai[n] == 'j' && mondai[n+1] == 'i'){
				char[] a = mondai.ToCharArray();
				a[n] = 'z';
				mondai = new string(a);
			}
		}

		if(keyChar == 'k'){
			if(mondai[n] == 'q' && mondai[n+1] == 'u'){
				char[] a = mondai.ToCharArray();
				a[n] = 'k';
				mondai = new string(a);
			}
		}

		if(keyChar == 's'){
			if(beforeChar == 't' && mondai[n] == 'u'){
				buffList.AddRange(mondai);
				buffList.Insert(n, 's');
				mondai = new string(buffList.ToArray());
			}
		}

		if(keyChar == 'q'){
			if(mondai[n] == 'k' && mondai[n+1] == 'u'){
				char[] a = mondai.ToCharArray();
				a[n] = 'q';
				mondai = new string(a);
			}
		}

		if(keyChar == 'f'){
			if(mondai[n] == 'h' && mondai[n+1] == 'u'){
				char[] a = mondai.ToCharArray();
				a[n] = 'f';
				mondai = new string(a);
			}
		}

		if(keyChar == 'i'){
			if(beforeChar == 'g' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'k' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 's' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 't' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'd' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'n' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'h' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'b' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'r' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'm' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'p' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 'z' && mondai[n] == 'y'){
				kogaki('i', n, ref mondai);
			}else if(beforeChar == 's' && mondai[n] == 'h'){
				if(mondai[n+1] == 'i'){
					buffList.AddRange(mondai);
					buffList.RemoveAt(n);
					mondai = new string(buffList.ToArray());
				}else{
					kogaki('i', n, ref mondai);
				}
			}
		}
		
		if(keyChar == 'u'){
			if(beforeChar == 'g' && mondai[n] == 'w'){
				kogaki('u', n, ref mondai);
			}else if(beforeChar == 's' && mondai[n] == 'w'){
				kogaki('u', n, ref mondai);
			}else if(beforeChar == 'f' && mondai[n] != 'u'){
				kogaki('u', n, ref mondai);
			}else if(beforeChar == 'w' && mondai[n] == 'h'){
				if(mondai[n+1] != 'u'){
					kogaki('u', n, ref mondai);
				}
			}else if(beforeChar == 'w' && mondai[n] == 'i'){
				kogaki('u', n, ref mondai);
			}else if(beforeChar == 'w' && mondai[n] == 'e'){
				kogaki('u', n, ref mondai);
			}else if(mondai[n] == 'w' && mondai[n+1] == 'h'){
				kogaki('u', n, ref mondai);
			}
		}

		if(keyChar == 'e'){
			if(beforeChar == 't' && mondai[n] == 'h'){
				kogaki('e', n, ref mondai);
			}else if(beforeChar == 'd' && mondai[n] == 'h'){
				kogaki('e', n, ref mondai);
			}
		}

		if(keyChar == 'o'){
			if(beforeChar == 't' && mondai[n] == 'w'){
				kogaki('o', n, ref mondai);
			}else if(beforeChar == 'd' && mondai[n] == 'w'){
				kogaki('o', n, ref mondai);
			}
		}
		changeColor(n-1, mondai);
	}

	void kogaki(char c, int n, ref string mondai){
		char[] a = mondai.ToCharArray();
		a[n] = c;
		mondai = new string(a);
		buffList.AddRange(mondai);
		buffList.Insert(n+1, 'x');
		mondai = new string(buffList.ToArray());
	}
}
