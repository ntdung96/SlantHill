//By Cale Bradbury - netgrind.net
//Toss in Assets/Editor
//Free for any use
//use to slow down unity for capturing frames for external software (gifcam, etc, scrubs only)
//export png sequence to assemble elsewhere (try imagemagick, photoshop)
//protip - right under the game tab there is a drop down where you can pick ratios and set absolute size in pixels.

using UnityEngine;
using System.Collections;
using UnityEditor;

[ExecuteInEditMode]
public class CaptureGifEditor : EditorWindow {

	
	public int frames = 50;
	public int frameDelay = 1;
	public bool captureFrames = true;
	public int captureUpscale = 1;
	public string capturePath = "Folder/Name";
	int i = -1;
	int c=0;
	private bool playing = true;
	[MenuItem("Edit/Capture Gif %_g")]

	static void Init () 
	{
		CaptureGifEditor window = EditorWindow.GetWindow<CaptureGifEditor>();
	}

	void Update()
	{
		c--;
		if(c<=0){
			c = frameDelay;
			if(i>=0){
				Debug.Log("Captured frame "+(frames-i)+"/"+frames);
				EditorApplication.Step();
				if(captureFrames){
					string s = ""+(frames-i);
					while(s.Length<6)s = "0"+s;
					Application.CaptureScreenshot(capturePath+""+s+".png",captureUpscale);
				}
				i--;
			}else if(i==-1){
				EditorApplication.Step();
				i--;
				EditorApplication.isPaused = !playing;
			}
		}
	}

	void capture(){
		playing = EditorApplication.isPlaying;
		EditorApplication.isPaused=true;
		i = frames-1;
	}

	void OnGUI()
	{
		frames = EditorGUILayout.IntField("Frames", frames);
		frameDelay = EditorGUILayout.IntField("Frame Delay", frameDelay);
		captureFrames = GUILayout.Toggle(captureFrames,"Capture Frames");
		if(captureFrames){
			captureUpscale = EditorGUILayout.IntField("Upscale", captureUpscale);
			capturePath = EditorGUILayout.TextField("Path (Path/ExtentionlessName)", capturePath);
		}
		if(GUILayout.Button("Capture"))
		{
			capture();
		}
	}
}