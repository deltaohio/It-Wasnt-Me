﻿using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public List<Transform> spawnLocations;
	public GameObject[] EnemyPrefabs;

	// Use this for initialization
	void Start () {
		spawnLocations = new List<Transform>();

		foreach (var loc in GetComponentInChildren<Transform>()) {
			if (loc != transform) {
				spawnLocations.Add ((Transform)loc);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SpawnEnemy ();
		}
	}

	GameObject getEnemyPrefab(){
		return EnemyPrefabs[Random.Range(0,EnemyPrefabs.Length)];
	}

	public void SpawnEnemy(){
		GameObject temp = Instantiate(getEnemyPrefab()) as GameObject;
		temp.GetComponent<EnemyBase> ().IsEnergyType1 = getEnergyTypeForSpawn ();
		temp.transform.position = spawnLocations [Random.Range(0,spawnLocations.Count)].position;
	}

	bool getEnergyTypeForSpawn(){
		return Random.Range (0, 2) == 0;
	}
}