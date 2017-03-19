using UnityEngine;
using System.Collections;

public class CreateTower : MonoBehaviour {

	public Material towerMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo)){
				if (hitInfo.collider.gameObject.tag == "TowerPos" && hitInfo.collider.transform.childCount == 0) {
					BattleStageActorFactor.instance.CreateBoint<PostTower> ("201", hitInfo.collider.transform.position, enActorCamp.enPlayer, enEnterStageWay.enAppearance);
				}


			}
			
		}
	}

	[ContextMenu("setTowerMaterial")]
	void setTowerMaterial(){
		var gos = GameObject.FindGameObjectsWithTag ("TowerPos");
		for(int i = 0;i < gos.Length;i++){
			gos [i].GetComponent<MeshRenderer> ().material = towerMaterial;
		}
	}
}
