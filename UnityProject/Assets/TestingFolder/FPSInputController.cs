using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Character/FPS Input Controller")]

public class FPSInputController : MonoBehaviour
{
	private PlayerInformation playerInformation;

	public Animator anim;
	private AnimatorStateInfo currentBaseState;	
	private AnimatorStateInfo layer2CurrentState;
	
	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int runState = Animator.StringToHash("Base Layer.Run");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");


    private CharacterMotor motor;
	private Level level;

    // Use this for initialization
    void Awake()
    {
        motor = GetComponent<CharacterMotor> ();
		level = GameObject.Find ("Level").GetComponent<Level>();

		playerInformation = GetComponent<PlayerInformation> ();

		anim = GetComponent<Animator> ();
	}

    // Update is called once per frame
    void Update()
    {
		movePlayer ();
    }

	private void movePlayer() {

		Vector3 directionVector = new Vector3 (Input.GetAxis (this.name + "_Horizontal"), 0, Input.GetAxis (this.name + "_Vertical"));
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


			anim.SetBool ("run", true);
			anim.SetBool ("idle", false);
		} else {
			anim.SetBool("idle", true);
			anim.SetBool ("run", false);
		}

		/*
		Vector3 moveDirection = transform.rotation * directionVector;
		Quaternion newRotation = Quaternion.LookRotation (directionVector);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
*/

		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection = transform.rotation * directionVector;

		// transform.position += transform.rotation * directionVector;
		// motor.inputJump = Input.GetButton("Jump");

		
		//=================================================
		/*
		 * HITTING ANIMATION
		 */
		//=================================================
		float pushValue = Input.GetAxis (this.name + "_Push");
		if(pushValue > 0.5f){
			anim.SetBool("push", true);
		} else {
			anim.SetBool("push", false);
		}

		//=================================================
		/*
		 * JUMPING ANIMATION
		 */
		//=================================================
		float jumpValue = Input.GetAxis (this.name + "_Jump");
		motor.inputJump = jumpValue > 0.5f;
		if (motor.inputJump && motor.grounded) {
			level.playJumpSound();
		}

		if (playerInformation.isSpawning) {
			anim.SetBool("spawn", true);
			if(motor.grounded) {
				playerInformation.isSpawning = false;
				anim.SetBool ("spawn", false);
			}
		} else {
			if (!motor.grounded) {
				anim.SetBool("jump", true);
			} else {
				anim.SetBool("jump", false);
			}
		}
	
		if (transform.position.y < 2 && !playerInformation.isDying) {
			Debug.Log (this.name + " dying");
			playerInformation.isDying = true;
		}
		if(playerInformation.isDying) {
			if(transform.position.y < -8 && playerInformation.isAlive){
				Debug.Log ("Dead");
				playerInformation.isAlive = false;
				level.playDeathSound();
			}
			anim.SetBool ("idle", false);
			anim.SetBool ("run", false);
			anim.SetBool ("runjump", false);
			anim.SetBool ("death", true);
		} else {
			anim.SetBool ("death", false);
		}

		checkButtons();

	}

	private void checkButtons() {
		if (Input.GetButton (this.name + "_Green")) {
			level.playChangeColorSound ();
			changeColor (PlatformInformation.PlatformColor.GREEN);
		} else if (Input.GetButton (this.name + "_Red")) {
			level.playChangeColorSound ();
			changeColor (PlatformInformation.PlatformColor.RED);
		} else if (Input.GetButton (this.name + "_Blue")) {
			level.playChangeColorSound ();
			changeColor (PlatformInformation.PlatformColor.BLUE); 
		} else if (Input.GetButton (this.name + "_Yellow")) {
			level.playChangeColorSound ();
			changeColor (PlatformInformation.PlatformColor.YELLOW);
		}
	}
	
	private void changeColor(PlatformInformation.PlatformColor color) {
		gameObject.GetComponent<PlayerInformation>().color = color;

		for (int i = 0; i < level.width; i++) {
			for(int j = 0; j < level.height; j++){
				PlatformInformation platformInfo = level.tiles[i, j].GetComponent<PlatformInformation>();
				FadingEffect tileFadeEffect = platformInfo.fadingEffect;

				if (!level.getCurrentlyActiveColors().Contains(platformInfo.platformColor)) {
					tileFadeEffect.FadeOutTile ();
				}
				else {
					tileFadeEffect.FadeInTile ();
				}
			}
		}
	}

}