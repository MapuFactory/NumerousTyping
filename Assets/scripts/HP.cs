using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
	public float hp;
	public float maxHP;

	public HP(float setHP){
		maxHP = setHP;
		hp = setHP;
	}
	
	public float damage(float power){
		hp -= power;
		return hp/maxHP;
	}

	public void heal(float healPower){
		hp += healPower;
	}

	public bool checkLose(){
		return hp <= 0;
	}
}
