﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : InteractableObject {

	//public Color selectedColor;
	public float capacity;
	public Image chargeBar;

	float currentCharge;

	/*Renderer rend;
	Color startColor;*/

	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		currentCharge = capacity;
	}
		

	public void Discharge(float discharge) {
		if (currentCharge > 0) {
			currentCharge -= discharge;
			if (currentCharge < 0) {
				currentCharge = 0;
			}
		}
		int curretChargeInt = (int)currentCharge;
		gameObject.GetComponent<BatteryVisuals>().setCharge(curretChargeInt);
		chargeBar.fillAmount = currentCharge / capacity;
	}

	public void Charge(float charge) {
		if (currentCharge < capacity) {
			currentCharge += charge;
			if (currentCharge > capacity) {
				currentCharge = capacity;
			}
		}
		int curretChargeInt = (int)currentCharge;
		gameObject.GetComponent<BatteryVisuals>().setCharge(curretChargeInt);
		chargeBar.fillAmount = currentCharge / capacity;
	}

	/*public override void Interact(Transform holdPosition) {
		transform.SetPositionAndRotation (holdPosition.position, holdPosition.rotation);
		transform.SetParent (holdPosition);
	}*/

}
