using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typingScript : MonoBehaviour
{
	public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
		text.text = "New <color=#4169e1>Text</color>";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
