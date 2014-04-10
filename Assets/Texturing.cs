using UnityEngine;
using System.Collections;

public class Texturing : MonoBehaviour {
	public Texture pictureView;
	public GameObject picObject;
	// Use this for initialization
	void Start () {
		Texture pictureView = null;
		picObject = null;
		//написать:
		
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if(go.name == "Wall"){
				
				//Material newMat = Resources.Load("material", typeof(Material)) as Material;
				Material newMat = new Material (Resources.Load ("material", typeof(Material)) as Material);
				newMat.mainTexture = Resources.Load ("marble_1_17", typeof(Texture)) as Texture;
				go.renderer.material = newMat;
				
				var SizeX = go.transform.localScale.x;
				var SizeZ = go.transform.localScale.z;
				go.renderer.material.mainTextureScale = new Vector2 (SizeX, SizeZ);
			}
			if(go.name == "Floor"){
				Material newMat = new Material (Resources.Load ("material", typeof(Material)) as Material);
				newMat.mainTexture = Resources.Load ("floor", typeof(Texture)) as Texture;
				go.renderer.material = newMat;
				
				var SizeX = go.transform.localScale.x;
				var SizeZ = go.transform.localScale.z;
				go.renderer.material.mainTextureScale = new Vector2 (SizeX, SizeZ);
			}
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			
			if (go.name == "painting") {
				var distance = Vector3.Distance(go.transform.position,gameObject.transform.position);
				if(distance<2){
					pictureView = go.renderer.material.mainTexture;
					picObject = go;
				}
				
			}
		}
		if (picObject != null) {
			var distance = Vector3.Distance(picObject.transform.position,gameObject.transform.position);
			if(distance>3)
			{
				pictureView = null;
			}
		}
	}
	void OnGUI(){
		if (pictureView != null) {
			float height= 0;
			float width=0;
			float temp = 999;
			if(pictureView.height>pictureView.width)
			{
				if(Screen.height>pictureView.height)
				{
					temp = (float)pictureView.height/(float)Screen.height/2;
				}
				else
				{
					temp = (float)Screen.height/(float)pictureView.height/2;
				}
				height = Screen.height/2;
				width = pictureView.width/temp;
				
			}
			else
			{
				if(Screen.width>pictureView.width)
				{
					temp = (float)Screen.width/(float)pictureView.width/2;
					
				}
				else
				{
					temp= (float)pictureView.width/Screen.width/2;
				}
				width = pictureView.width*temp;
				height = pictureView.height*temp;
			}
			Rect texRect = new Rect (Screen.width/2- Screen.height/2, 0,width,height);
			GUI.DrawTexture (texRect, pictureView);//- этот метод рисует текстур;
		}
	}
}