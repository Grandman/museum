using UnityEngine;
using System.Collections;

public class Texturing : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
	
	}
}
