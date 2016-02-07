// Script courtesy of Tuncer @answers.unity3d.com
using UnityEngine;
using System.Collections;

public class WinMusic : MonoBehaviour {

		public AudioClip gameWinClip;
		public AudioClip bgLoopClip;
		
		void Start()
		{
			GetComponent<AudioSource>().loop = true;
			StartCoroutine(playClips());
		}
		
		IEnumerator playClips()
		{
			audio.clip = gameWinClip;
			audio.Play();
			yield return new WaitForSeconds(audio.clip.length);
			audio.clip = bgLoopClip;
			audio.Play();
		}
}
