using UnityEngine;
using System.Collections;

public class Horizontal : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H))
		{
			GetComponent<Highlighter>().Highlight();
			RectTransform rt = GetComponent<RectTransform>();
			rt.rotation *= Quaternion.Euler(0, 0, 180f);
		}
	}
}
