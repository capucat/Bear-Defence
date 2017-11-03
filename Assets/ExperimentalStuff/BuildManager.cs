﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

	public GameObject building;
	public GameObject Lazer;
	public GameObject Blaster;

	public Image simpleTurret;
	public Image LazerImage;
	public Image BlasterImage;

	public bool isPaused;

	public Color selectedColor;
	private Color normalColor;

	private GameObject thingThatsBuilt;
	public Vector3 offset;

	public static BuildManager instance = null;

	private Transform tile;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		thingThatsBuilt = building;
		normalColor = simpleTurret.color;

		LazerImage.color = selectedColor;
		BlasterImage.color = selectedColor;
		simpleTurret.color = normalColor;
	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			thingThatsBuilt = building;
			simpleTurret.color = normalColor;
			LazerImage.color = selectedColor;
			BlasterImage.color = selectedColor;
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			thingThatsBuilt = Lazer;
			LazerImage.color = normalColor;
			simpleTurret.color = selectedColor;
			BlasterImage.color = selectedColor;
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			thingThatsBuilt = Blaster;
			LazerImage.color = selectedColor;
			simpleTurret.color = selectedColor;
			BlasterImage.color = normalColor;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (tile.GetComponent<TileSelectController>().isHighlighted && !isPaused && !tile.GetComponent<TileSelectController>().hasBuilding) {
				Build ();
			}
		}
	}

	void Build() {

		float cost = thingThatsBuilt.GetComponent<PlaceableObject> ().cost;
		float currency = GameManager.instance.playerCurrency;

		if (currency - cost >= 0f) {
			GameManager.instance.playerCurrency = currency - cost;
			Instantiate (thingThatsBuilt, tile.position + offset, Quaternion.identity);
			tile.GetComponent<TileSelectController> ().hasBuilding = true;
		}
	}

	public void SetTile(Transform t) {
		tile = t;
	}
		
}
