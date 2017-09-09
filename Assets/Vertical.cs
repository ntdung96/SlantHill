using UnityEngine;
using System.Collections;

public class Vertical : MonoBehaviour
{

	public float speed = 7;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			GetComponent<Highlighter>().Highlight();
			RectTransform rt = GetComponent<RectTransform>();
			rt.Rotate(Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetMouseButton(0))
		{
			GetComponent<Highlighter>().Highlight();
			RectTransform rt = GetComponent<RectTransform>();
			rt.Rotate(Vector3.back * speed * Time.deltaTime);
		}
	}
}