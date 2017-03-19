using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateMapCubeEditor : EditorWindow {

	string hLineGap = "1";
	string hNum = "1";
	string vLineGap = "1";
	string vNum = "1";

	Vector3 lastMapCubePos = Vector3.zero;

	[MenuItem("zTools/CreateMapCube")]
	public static void Init(){
		GetWindow<CreateMapCubeEditor> ("CreateMapCube").Show();
	}

	void OnGUI(){
		if (Selection.activeGameObject == null) {
			GUILayout.Label ("请选择一个MapCube");
			return;
		}

		GUILayout.BeginVertical ();
		GUILayout.Label ("横排 创建一排");
		GUILayout.BeginHorizontal ();
		CreateHLine ();
		GUILayout.EndHorizontal ();


		GUILayout.Label ("纵排 创建一排");
		GUILayout.BeginHorizontal ();
		CreateVLine ();
		GUILayout.EndHorizontal ();


		GUILayout.EndVertical ();

	}

	void CreateHLine(){
		GUILayout.Label ("间隔", GUILayout.MaxWidth(30.0f));
		hLineGap = GUILayout.TextField (hLineGap);
		GUILayout.Label ("数量", GUILayout.MaxWidth(30.0f));
		hNum = GUILayout.TextField (hNum);

		if(GUILayout.Button("创建")){
			createCube (float.Parse(hLineGap), int.Parse(hNum), 1);
		}
	}

	void CreateVLine(){
		GUILayout.Label ("间隔", GUILayout.MaxWidth(30.0f));
		vLineGap = GUILayout.TextField (hLineGap);
		GUILayout.Label ("数量", GUILayout.MaxWidth(30.0f));
		vNum = GUILayout.TextField (vNum);

		if(GUILayout.Button("创建")){
			createCube (float.Parse(hLineGap), int.Parse(vNum), 2);
		}
	}

	void createCube(float gap, int num, int axle){
		lastMapCubePos = Selection.activeGameObject.transform.position;
		Transform cachedSelectionTr = Selection.activeGameObject.transform;
		if(axle == 1){ // x 轴
			for(int i = 1;i <= num;i++){
				var go = Resources.Load<GameObject> ("Prefabs/MapCube");
				float xPos = lastMapCubePos.x + cachedSelectionTr.localScale.x + gap; 
				go.transform.position = new Vector3 (xPos, cachedSelectionTr.position.y, cachedSelectionTr.position.z);
				go.transform.parent = cachedSelectionTr.parent;
				lastMapCubePos = go.transform.position;
			}
		}
		else if(axle == 2){ // z 轴
			lastMapCubePos = Selection.activeGameObject.transform.position;
			Transform cachedSelectionTr2 = Selection.activeGameObject.transform;
			for(int i = 1;i <= num;i++){
				var go = Resources.Load<GameObject> ("Prefabs/MapCube");
				float zPos = lastMapCubePos.z + cachedSelectionTr2.localScale.z + gap; 
				go.transform.position = new Vector3 (cachedSelectionTr2.position.x, cachedSelectionTr2.position.y, zPos);
				go.transform.parent = cachedSelectionTr2.parent;
				lastMapCubePos = go.transform.position;
			}
		}

	}


	void OnEnable(){
	}
}
