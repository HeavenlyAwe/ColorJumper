using UnityEngine;
using System.Collections;

public class SPRotation : MonoBehaviour {
	public bool clockwise;

	void Update() {
		if (clockwise) {
			transform.RotateAround(transform.position, Vector3.up, 500 * Time.deltaTime);
		} else {
			transform.RotateAround(transform.position, Vector3.down, 500 * Time.deltaTime);
		}
	}
}
