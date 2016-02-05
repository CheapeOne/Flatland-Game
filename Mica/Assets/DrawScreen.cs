using UnityEngine;
using System.Collections;

public class DrawScreen: MonoBehaviour {

	private GUITexture screen;
	private Texture2D tex;
	private GameObject myCamera;
	public float fov;

	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
		screen = this.GetComponent("GUITexture") as GUITexture;
		tex = new Texture2D(Screen.width,Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		tex = new Texture2D(Screen.width,Screen.height);

		//get the pixels
		for(int x = 0; x < Screen.width; x++){
			for(int y = 0; y < Screen.height; y++){
				Color color = myCamera.GetComponent<Raytrace>().Trace(x, (float)Screen.width, fov);
				tex.SetPixel(x, y, color);
			}
		}
		tex.Apply();
		screen.texture = tex;

		/*
		string s = "";
		foreach(Color c in horizontalStrip){
			s = s + c.ToString() + " ";
		}
		Debug.Log(s);

		Color[] finalPixels = new Color[Screen.width * Screen.height];

		for(int y = 0; y < Screen.height; y++){
			for(int x = 0; x < Screen.width; x++)
				finalPixels[Screen.width * y] = horizontalStrip[x];
		}
			
		tex.SetPixel

		tex.Apply();
		screen.texture = tex;
		*/
	}
}
