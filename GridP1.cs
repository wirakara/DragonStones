using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GridP1 : MonoBehaviour {

	List<GameObject> grid;
	
	public GameObject GetGridByNumber(int index) {
		return grid [index];
	}

	void Awake () {
	
		grid = new List<GameObject>();
		
		//TODO: hack to reverse through children to add them from 0-24 (they are 24-0 in prefab)
		for(int i = 24; i >= 0; i--) {
			grid.Add (transform.GetChild(i).gameObject);
		}

	}
		
}
