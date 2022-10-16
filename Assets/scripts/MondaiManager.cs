using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MondaiManager : MonoBehaviour
{
	private nyuryoku attack1Nyuryoku;
	private nyuryoku attack2Nyuryoku;
	private DisplayQuiz displayquiz1;
	private DisplayQuiz displayquiz2;

	public string keyst;
	public string mondai1;
	public string mondai2;
	public bool attack1Lock;
	public bool attack2Lock;
	public quiz attack1Quiz;
	public quiz attack2Quiz;
	public EnemyScript es;
	public PlayerScript ps;

	// Start is called before the first frame update
	void Start()
	{
		attack1Lock = false;
		attack2Lock = false;
		attack1Nyuryoku = this.transform.Find("Attack1").gameObject.GetComponent<nyuryoku>();
		attack2Nyuryoku = this.transform.Find("Attack2").gameObject.GetComponent<nyuryoku>();
		attack1Quiz = this.transform.Find("Attack1").gameObject.GetComponent<quiz>();
		attack2Quiz = this.transform.Find("Attack2").gameObject.GetComponent<quiz>();
		es = GameObject.Find("Enemy").GetComponent<EnemyScript>();
		ps = GameObject.Find("Player").GetComponent<PlayerScript>();
		displayquiz1 = this.transform.Find("Attack1").gameObject.GetComponent<DisplayQuiz>();
		displayquiz2 = this.transform.Find("Attack2").gameObject.GetComponent<DisplayQuiz>();
		mondai1 = new string(attack1Quiz.mondaiKaki.ToCharArray());
		mondai2 = new string(attack2Quiz.mondaiKaki.ToCharArray());
	}

	// Update is called once per frame
	void Update()
	{
		
		if(!Input.anyKeyDown)	return;
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			attack1Nyuryoku.n = 0;
			displayquiz1.changeFontSize(true);
			displayquiz2.changeFontSize(true);
			attack1Lock = false;
			attack2Lock = false;
			displayquiz2.resetColor();
			displayquiz1.resetColor();
		}
		keyst = Input.inputString;
		Debug.Log(keyst);
		if(keyst.Length == 0) return;
		
		if(!attack1Lock) attack1Nyuryoku.hantei(keyst[0], ref mondai1);
		if(!attack2Lock) attack2Nyuryoku.hantei(keyst[0], ref mondai2);

		if(!attack1Nyuryoku.isHantei && !attack2Nyuryoku.isHantei){
			 ps.combo = 0;
			 return;
		}
		if(!attack1Lock && !attack2Lock && attack1Nyuryoku.isHantei && !attack2Nyuryoku.isHantei){
			attack2Lock = true;
			attack1Lock = false;
			displayquiz2.resetColor();
		}
		if(!attack1Lock && !attack2Lock && !attack1Nyuryoku.isHantei && attack2Nyuryoku.isHantei){
			attack1Lock = true;
			attack2Lock = false;
			displayquiz1.resetColor();
		}
		if(attack1Nyuryoku.isHantei || attack2Nyuryoku.isHantei){
			ps.combo += 1;
			ps.inputSpeed = ps.inputTime;
			ps.inputTime = 0.0f;
		}
		displayquiz1.changeFontSize(attack1Lock);
		displayquiz2.changeFontSize(attack2Lock);

		if(mondai1.Length == attack1Nyuryoku.n){
			attack1Nyuryoku.n = 0;
			displayquiz1.changeFontSize(true);
			displayquiz2.changeFontSize(true);
			attack1Lock = false;
			attack2Lock = false;
			attack1Quiz.Next();
			//Debug.Log((float)mondai1.Length/10);
			es.attack(ps.combo);
			mondai1 = new string(attack1Quiz.mondaiKaki.ToCharArray());
		}
		if(mondai2.Length == attack2Nyuryoku.n){
			attack2Nyuryoku.n = 0;
			displayquiz1.changeFontSize(true);
			displayquiz2.changeFontSize(true);
			attack1Lock = false;
			attack2Lock = false;
			attack2Quiz.Next();
			//Debug.Log((float)mondai2.Length/10);
			es.attack(ps.combo);
			mondai2 = new string(attack2Quiz.mondaiKaki.ToCharArray());
		}
	}
}
