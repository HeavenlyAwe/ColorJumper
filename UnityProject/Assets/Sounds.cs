using UnityEngine;
using System.Collections;
using System.IO;

public class Sounds : MonoBehaviour {

	private AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		loadSoundClips ();
		loadMusic ();
	}

	private void loadSoundClips(){
		audioClips = Resources.LoadAll<AudioClip>("Audio/Clips");
		AudioSource source = new AudioSource ();
		source.audio.clip = audioClips [0];


		// source.Play ();
	}

	private void loadMusic() {

	}

	// Update is called once per frame
	void Update () {
	
	}
}
