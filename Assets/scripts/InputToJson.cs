using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class InputToJson : MonoBehaviour
{
	string datapath;

	private void Awake()
	{
		//初めに保存先を計算する
		datapath = Application.dataPath + "/Datas/mondai.json";
	}

	void Start()
	{
		Mondai[] mondai1 = LoadTest(datapath);
		Debug.Log(mondai1);
	}
	public Mondai[] LoadTest(string dataPath)
	{
		StreamReader reader = new StreamReader(dataPath); //受け取ったパスのファイルを読み込む
		string datastr = reader.ReadToEnd();//ファイルの中身をすべて読み込む
		reader.Close();//ファイルを閉じる

		return JsonUtility.FromJson<Mondai[]> (datastr);//読み込んだJSONファイルをMondai型に変換して返す
	}

}

