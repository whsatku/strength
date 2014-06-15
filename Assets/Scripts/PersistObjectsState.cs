using UnityEngine;
using System.Collections;

public class PersistObjectsState : MonoBehaviour {

	public Transform[] objects;

	// Use this for initialization
	void Start () {
		foreach(Transform obj in objects){
			string name = nameForObject(obj);
			if(Manager.instance.objectState.ContainsKey(name)){
				Vector2 position = Manager.instance.objectState[name];
				if(obj.name == "PlayerPrefab"){
					Collider2D col = Physics2D.OverlapCircle(position, 0.26f);
					if(col){
						Debug.Log(col);
						position.x += col.bounds.size.x / 2;
					}
				}
				obj.position = position;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Transform obj in objects){
			Manager.instance.objectState[nameForObject(obj)] = obj.position;
		}
	}

	string nameForObject(Transform obj){
		return Application.loadedLevelName + obj.name;
	}
}
