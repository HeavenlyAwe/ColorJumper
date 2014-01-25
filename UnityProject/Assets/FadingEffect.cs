using UnityEngine;
using System.Collections;

public class FadingEffect : MonoBehaviour {
	
	bool isTweeningOut;
	bool isTweeningIn;
	float fadeTime; //in seconds

	float fullAlpha = 1f;
	
	// Use this for initialization
	void Start () {
		Color color = renderer.material.color;
		
		color.a = fullAlpha;
		renderer.material.color = color;
		
		Debug.Log(renderer.material.color.a);
		
		isTweeningOut = false;
		isTweeningIn = false;
		
		fadeTime = 2.0f;

		FadeOutTile ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTweeningOut) {
			Color color = renderer.material.color;
			
			color.a -= Time.deltaTime / fadeTime;
			
			if (color.a <= 0) {
				color.a = 0;
				onFadeOutComplete();
			}
			
			renderer.materials[0].color = color;
			renderer.materials[1].color = color;
			renderer.materials[2].color = color;
		}
		else if (isTweeningIn) {
			Color color = renderer.material.color;
			
			color.a += Time.deltaTime / fadeTime;
			
			if (color.a >= fullAlpha) {
				color.a = fullAlpha;
				onFadeInComplete();
			}
			
			renderer.materials[0].color = color;
			renderer.materials[1].color = color;
			renderer.materials[2].color = color;
		}
	}
	
	public void FadeOutTile() {
		isTweeningOut = true;
		isTweeningIn = false;
	}
	
	public void FadeInTile() {
		isTweeningIn = true;
		isTweeningOut = false;
	}
	
	void onFadeOutComplete() {
		gameObject.transform.parent.gameObject.collider.enabled = false;
		isTweeningOut = false;
		FadeInTile ();
	}
	
	void onFadeInComplete() {
		gameObject.transform.parent.gameObject.collider.enabled = true;
		isTweeningIn = false;
		FadeOutTile ();
	}
}
