#if UNITY_EDITOR
using UnityEngine;
using UnityEditor.Experimental.AssetImporters;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[ScriptedImporter(1, "pnglvl")]
public class LvImporter : ScriptedImporter
{
	public float m_Scale = 1;
	public float tileScale = 2;

	public int startY = 1;
	public int startX = 0;
	public int w = 32;
	public int h = 32;

 	//public Material block,water,breakable;
 	//public GameObject spike;

	string fm(Color c)
	{
		string s=Convert.ToString((int)(c.r * 255),16)
		+Convert.ToString((int)(c.g * 255), 16)
		+Convert.ToString((int)(c.b * 255), 16);
		return "#"+s;
	}

	public override void OnImportAsset(AssetImportContext ctx)
	{
		var name = ctx.assetPath.Replace ("\\", "/").Split ('/').LastOrDefault () ?? "temp";
		var gameObjectRoot = new GameObject(name);
		gameObjectRoot.AddComponent<Transform>();
		/*var gameObjectCanvas = new GameObject(name+"Canvas");
		gameObjectCanvas.AddComponent<Canvas>();
		gameObjectCanvas.transform.parent = gameObjectRoot.transform;*/

		/*GameObject textGameObj = new GameObject(name+"Text");
		textGameObj.AddComponent<Transform>();*/

		//var rectTransform = gameObjectCanvas.GetComponent<RectTransform> ();
		//rectTransform.anchoredPosition = Vector2.zero;	
		//rectTransform.anchoredPosition = Vector2.zero;	

		//string fileContent = File.ReadAllText (ctx.assetPath).Replace("\r", "");
			 byte[] imgData = File.ReadAllBytes (ctx.assetPath);
		/*var lines = fileContent.Split ('\n');
		var width = lines.Aggregate (0, (acc, val) => Math.Max (acc, val.Length));
		var height = Math.Max(0, lines.Length - 2);
*/
		/*Text textComp = textGameObj.AddComponent<Text>();
		
		textComp.fontStyle = FontStyle.Normal;
		textComp.fontSize = 8;
		textComp.supportRichText = true;
		Debug.Log ("prop font: " + textComp.font);
		textComp.horizontalOverflow = HorizontalWrapMode.Overflow;
		textComp.verticalOverflow = VerticalWrapMode.Overflow;
		textComp.text = "V1" + DateTime.Now + "\n"+fileContent; // + "\n@" + DateTime.Now + ", w: "+width+", h: "+height;
		*/

		/*var oneCharHeight = 25;
		var oneCharWidth = 10;
		var rectTransform = textGameObj.GetComponent<RectTransform> ();
		rectTransform.sizeDelta = new Vector2(width*oneCharWidth, height*oneCharHeight);
		*/

		//textGameObj.transform.parent = gameObjectCanvas.transform;
		//gameObjectRoot.transform.rotation = Quaternion.Euler(90, 0, 0);
		//textGameObj.transform.rotation = Quaternion.Euler(90, 0, 0);
		//gameObjectRoot.transform.rotation = Quaternion.Euler(90, 0, 0);


        //GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
		//plane.transform.parent = gameObjectRoot.transform;

		var position=new Vector3(0,0,0);

		//GameObject cubeObj2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//cubeObj2.transform.parent = gameObjectRoot.transform;
		//cubeObj2.transform.position = -120 * Vector3.one;
		//Mesh cubeMesh = cubeObj2.GetComponent<MeshFilter>().sharedMesh;
		
		//Tuple<string[], Texture2D> tuple = LevelLoader.GetLinesAndTex(fileContent);
	 	Debug.Log("imgData: " + imgData); 
    		Texture2D tex = new Texture2D(128, 128);
        tex.LoadImage(imgData);

		Texture2D map= tex; //tuple.Item2;
		var x=0;
		Color Start = map.GetPixel(x++, -1);
		Color Bounds = map.GetPixel(x++, -1);
		Color MetaBounds = map.GetPixel(x++, -1);
		Color Block = map.GetPixel(x++, -1);
		Color Breakable = map.GetPixel(x++, -1);
		Color Background = map.GetPixel(x++, -1);
		Color Treasure = map.GetPixel(x++, -1);
		Color Enemy = map.GetPixel(x++, -1);
		Color Boss = map.GetPixel(x++, -1);
		Color NPC = map.GetPixel(x++, -1);
		Color Seller = map.GetPixel(x++, -1);
		Color Upgrade = map.GetPixel(x++, -1);
		Color Water = map.GetPixel(x++, -1);
		Color Spikes = map.GetPixel(x++, -1);
		Color Lore = map.GetPixel(x++, -1);
		Color Key = map.GetPixel(x++, -1);
		Color Gate = map.GetPixel(x++, -1);
		Color Camp = map.GetPixel(x++, -1);
		Color BG2 = map.GetPixel(33, -1);

		Debug.Log(fm(Start) +",Start");
		Debug.Log(fm(Bounds) +",Bounds");
		Debug.Log(fm(MetaBounds) +",MetaBounds");
		Debug.Log(fm(Block) +",Block");
		Debug.Log(fm(Breakable) +",Breakable");
		Debug.Log(fm(Background) +",Background");
		Debug.Log(fm(Treasure) +",Treasure");
		Debug.Log(fm(Enemy) +",Enem");
		Debug.Log(fm(Boss) +",Boss");
		Debug.Log(fm(NPC) +",NPC");
		Debug.Log(fm(Seller) +",Seller");
		Debug.Log(fm(Upgrade) +",Upgrade");
		Debug.Log(fm(Water) +",Water");
		Debug.Log(fm(Spikes) +",Spike");
		Debug.Log(fm(Lore) +",Lore");
		Debug.Log(fm(Key) +",Key");
		Debug.Log(fm(Gate) +",Gate");
		Debug.Log(fm(Camp) +",Camp");
		Debug.Log(fm(BG2) +",BG2");


		Color[] blockFor = new Color[]{
			Block, Breakable, Gate, Spikes, Water, BG2
		};
		//string fm="F5";
		Debug.Log(Block+":"+fm(Block));
		for(int y=h-2;y>=startY;y--){
			for(x=startX;x<w;x++){
				
				Color current = map.GetPixel(x, y-h);
				Color above = map.GetPixel(x, y+1-h);
				Color above2 = map.GetPixel(x, y+2-h);
				if(//current.ToString() != Background.ToString()) { //
					Array.Exists(blockFor, element => fm(element) == fm(current))) {
					var wat=fm(current) == fm(Water);
					var bg2=fm(current) == fm(BG2);
					var isBreakable=fm(current) == fm(Breakable)
					|| fm(above) == fm(Boss)
					|| fm(above2) == fm(Boss);
					String tag=null;
						if(wat){
							tag = "Water";
						}
						if(isBreakable){
							tag = "Breakable";
						}

					GameObject cubeObj = new GameObject("y"+y+"x"+x+ " "+tag);
		//plane.transform.position = -120 * Vector3.one;
        //cubeObj.transform.rotation = Quaternion.Euler(90, 90, -90);
					cubeObj.tag=tag;
					cubeObj.transform.parent = gameObjectRoot.transform;
					cubeObj.transform.position=new Vector3(x,y-h,0)*tileScale;
					cubeObj.transform.localScale=Vector3.one*tileScale;
					/*MeshRenderer render =cubeObj.AddComponent<MeshRenderer>();
					render.material = 
						fm(current) == fm(Block)?block:
						bg2?block:
						wat?water:
						isBreakable? breakable:block;
						//if(){
						//	cubeObj.tag = "Breakable";
						//}
*/
					//MeshFilter f = cubeObj.AddComponent<MeshFilter>();
					//f.mesh = cubeMesh;
					if(!wat && !bg2
					&& !isBreakable
					){
						var coll = cubeObj.AddComponent<BoxCollider2D>();
						coll.edgeRadius = 0.1f;
					}
				}
			}
		}


		//DestroyImmediate(cubeObj.GetComponent<BoxCollider>());
		gameObjectRoot.transform.position = position;
		gameObjectRoot.transform.localScale = Vector3.one * m_Scale;

		// 'cube' is a a GameObject and will be automatically converted into a prefab
		// (Only the 'Main Asset' is elligible to become a Prefab.)
		ctx.AddObjectToAsset("main obj", gameObjectRoot);
		ctx.SetMainObject(gameObjectRoot);

		//textComp.cachedTextGenerator.Invalidate ();


		//var material = new Material(Shader.Find("Standard"));
		//material.color = Color.red;

		// Assets must be assigned a unique identifier string consistent across imports
		//ctx.AddObjectToAsset("my Material", material);

		// Assets that are not passed into the context as import outputs must be destroyed
		//var tempMesh = new Mesh();
		//DestroyImmediate(tempMesh);
	}
}
#endif