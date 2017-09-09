using UnityEngine;
using System.Collections;

public class Call : MonoBehaviour
{

	public GameObject canvas;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			canvas.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			canvas.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			Vector3[] cornershrz = new Vector3[4];
			GameObject horizontal = GameObject.FindGameObjectWithTag("Horizontal");
			horizontal.GetComponent<RectTransform>().GetWorldCorners(cornershrz);
			Vector3 hrz = cornershrz[2] - cornershrz[1];

			Vector3[] cornersvtc = new Vector3[4];
			GameObject vertical = GameObject.FindGameObjectWithTag("Vertical");
			vertical.GetComponent<RectTransform>().GetWorldCorners(cornersvtc);
			Vector3 vtc = cornersvtc[2] - cornersvtc[3];

			float angle = Vector3.Angle(vtc, hrz);

			if (angle > 180)
			{
				Debug.LogWarning("The angle can't be bigger than 180");
			} else
			{
				string string1 = @"\AngleEstimation";
				string string2 = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
				string string3 = @".txt";
				string fileName = string1 + string2 + string3;

				Debug.Log(angle.ToString());
				System.IO.File.WriteAllText(Application.dataPath + fileName, angle.ToString());
			}
		}
	}
}
