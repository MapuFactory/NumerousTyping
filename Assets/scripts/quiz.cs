using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System.IO;

public class quiz : MonoBehaviour
{
	public string mondaiToi;
	public string mondaiKaki;
	public int mondaiLen;
	private int mondaiSu;
	private int mondaiType;
	private int n;
	private DisplayQuiz displayquiz;
	private MondaiTypeManager monTypeMa;
	private NowTypeManager nowTypeMa;

	TextAsset csvFile; // CSVファイル
	List<string[]> mondaiList = new List<string[]>(); // CSVの中身を入れるリスト;

	void Awake()
	{
		csvFile = Resources.Load("mondai") as TextAsset; // Resouces下のCSV読み込み
		StringReader reader = new StringReader(csvFile.text);

		// , で分割しつつ一行ずつ読み込み
		// リストに追加していく
		while (reader.Peek() != -1) // reader.Peaekが-1になるまで
		{
			string line = reader.ReadLine(); // 一行ずつ読み込み
			mondaiList.Add(line.Split(',')); // , 区切りでリストに追加
		}
		n = Random.Range(1, mondaiList.Count);
		//mondai_jp = GameObject.Find().transform.GetComponent<Text>();
		//mondai_en = gameObject.transform.GetComponent<Text>();
		mondaiToi = mondaiList[n][0];
		mondaiKaki = mondaiList[n][2];
		mondaiLen = mondaiKaki.Length;
		displayquiz = GetComponent<DisplayQuiz>();
		mondaiType = int.Parse(mondaiList[n][3]);
		nowTypeMa = GameObject.Find("NowType").GetComponent<NowTypeManager>();
	}

	void Start()
	{
		monTypeMa = this.transform.Find("MondaiType").gameObject.GetComponent<MondaiTypeManager>();
		mondaiType = int.Parse(mondaiList[n][3]);
		monTypeMa.SetType(mondaiList[n][3]);
	}

	public void Next()
	{
		Debug.Log("next");
		nowTypeMa.SetType(mondaiList[n][3]);

		n = Random.Range(1, mondaiList.Count);
		mondaiToi = mondaiList[n][0];
		mondaiKaki = mondaiList[n][2];
		mondaiType = int.Parse(mondaiList[n][3]);
		monTypeMa.SetType(mondaiList[n][3]);
		
		displayquiz.next();
		
	}

	public void Reset()
	{
		
	}

}
