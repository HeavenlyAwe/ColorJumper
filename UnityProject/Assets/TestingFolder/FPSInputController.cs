using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Character/FPS Input Controller")]

public class FPSInputController : MonoBehaviour
{
    private CharacterMotor motor;
	private Level level;

    // Use this for initialization
    void Awake()
    {
        motor = GetComponent<CharacterMotor> ();
		level = GameObject.Find ("Level").GetComponent<Level>();
    }

    // Update is called once per frame
    void Update()
    {
		movePlayer ();
    }

	private void movePlayer() {
		Vector3 directionVector = new Vector3 (Input.GetAxis (this.name + "_Horizontal"), 0, Input.GetAxis (this.name+ "_Vertical"));

		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			float directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;
			
			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min(1.0f, directionLength);
			
			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;
			
			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}

		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection = transform.rotation * directionVector;

		// transform.position += transform.rotation * directionVector;
		// motor.inputJump = Input.GetButton("Jump");

		float jumpValue = Input.GetAxis (this.name + "_Jump");
		motor.inputJump = Mathf.Abs(jumpValue) > 0.5f;

		checkButton(this.name + "_Green");
		checkButton (this.name + "_Red");
		checkButton (this.name + "_Blue");
		checkButton (this.name + "_Yellow");
	}

	private void checkButton(string text) {
		if (Input.GetButton (text)) {
			Debug.Log (text);
			GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);
		}
	}
	
	private void changeColor(Color color){
		/*
		// The offset is off, lets fix it tomorrow!!!
		float playerX = motor.transform.position.x + level.tile.transform.localScale.x / 2;
		float playerZ = motor.transform.position.z + level.tile.transform.localScale.y / 2;
		
		int tileX = (int) (playerX / level.tile.transform.localScale.x);
		int tileZ = (int) (playerZ / level.tile.transform.localScale.z);
		
		level.getTile(tileX, tileZ).renderer.material.color = color;
		*/
	}

}