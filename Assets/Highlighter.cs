using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highlighter : MonoBehaviour
{

	public Color color = Color.yellow;
	Color original;
	public float highlightTime = 1;
	float highlightExpireTime = 0;

	// Use this for initialization
	void Start()
	{
		original = GetComponent<Image>().color;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > highlightExpireTime)
		{
			GetComponent<Image>().color = original;
		}
	}

	public void Highlight()
	{
		GetComponent<Image>().color = color;
		highlightExpireTime = Time.time + highlightTime;
	}
}
