using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

	public int combo;
	public float inputSpeed;
	public float inputTime;
	public int nowType;

	private bool isheal;
	private HP hp;
	private nyuryoku nyuryokuPlayer;
	private GameObject enemy;
	private EnemyScript es;
	private Text comboText;
	private Text speedText;

	void Start()
	{
		isheal = true;
		hp = new HP(100);
		nyuryokuPlayer = this.transform.Find("mondaiMag").gameObject.GetComponent<nyuryoku>();
		StartCoroutine(heal());
		enemy = GameObject.Find("Enemy");
		es = enemy.GetComponent<EnemyScript>();
		comboText = this.transform.Find("Combo").gameObject.GetComponent<Text>();
		speedText = this.transform.Find("TypingSpeed").gameObject.GetComponent<Text>();
		inputTime = 0.0f;
	}

	void Update()
	{
		comboText.text = combo.ToString() + " Combo!!";
		speedText.text = inputSpeed.ToString("00.000");
		inputTime += Time.deltaTime;
	}

	public void attack(float power){
		hp.damage(power);
	}

	IEnumerator heal(){
		while(isheal){
			hp.heal(0.0f);
			yield return null;
		}
	}

}
