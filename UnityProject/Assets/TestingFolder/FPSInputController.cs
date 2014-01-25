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
		Vector3 directionVector = new Vector3 (Input.GetAxis (this.name + "_Horizontal"), 0, Input.GetAxis (this.name + "_Vertical"));
		Debug.Log (directionVector);
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

		checkButtons();
	}

	private void checkButtons() {
		if (Input.GetButton (this.name + "_Green")) {
			changeColor (PlatformInformation.PlatformColor.GREEN);
		} else if (Input.GetButton (this.name + "_Red")) {
			changeColor (PlatformInformation.PlatformColor.RED);
		} else if (Input.GetButton (this.name + "_Blue")) {
			changeColor (PlatformInformation.PlatformColor.BLUE); 
		} else if (Input.GetButton (this.name + "_Yellow")) {
			changeColor (PlatformInformation.PlatformColor.YELLOW);
		}
	}
	
	private void changeColor(PlatformInformation.PlatformColor color){
		for (int i = 0; i < level.width; i++) {
			for(int j = 0; j < level.height; j++){
				PlatformInformation platformInfo = level.tiles[i, j].GetComponent<PlatformInformation>();
				FadingEffect tileFadeEffect = platformInfo.fadingEffect;

				if (platformInfo.platformColor == color) {
					tileFadeEffect.FadeOutTile ();
				}
				else {
					tileFadeEffect.FadeInTile ();
				}
			}
		}
	}

}