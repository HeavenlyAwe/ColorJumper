using UnityEngine;
using System.Collections;

public class CharAnim : MonoBehaviour {
	public bool death;
	public bool win;
	public bool spawn;
	public Animator anim;
	private AnimatorStateInfo currentBaseState;	
	private AnimatorStateInfo layer2CurrentState;

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int runState = Animator.StringToHash("Base Layer.Run");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		/*
		if(anim.layerCount == 2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);

		if (Input.GetButton ("Player1_Green")) {
			anim.SetBool ("push", true);
		} else {
			anim.SetBool("push", false);
		}

		if (spawn) {
			anim.SetBool("spawn", true);
		} else {
			anim.SetBool("spawn", false);
		}

		if (win) {
			anim.SetBool ("win", true);
		} else {
			anim.SetBool("win", false);
		}

		if (death) {
			anim.SetBool ("death", true);
		} else {
			anim.SetBool("death", false);
		}

		if (Input.GetButton("Fire1")) {
			anim.SetBool("idle", true);
			anim.SetBool("jump", true);
		}
		else {
			anim.SetBool("idle", true);
			anim.SetBool("jump", false);
		}

		if (Input.GetButton ("Fire2")) {
			anim.SetBool ("run", true);
			anim.SetBool("idle", false);
		}
		else {
			anim.SetBool("run", false);
		}

		if (Input.GetButton ("Fire1") && Input.GetButton ("Fire2")) {
			anim.SetBool ("runjump", true);
		} else {
			anim.SetBool("runjump", false);
		}
		*/
	}
}

