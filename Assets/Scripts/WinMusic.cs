// Script adapted from solution by Tuncer @answers.unity3d.com
using UnityEngine;
using System.Collections;

public class WinMusic : MonoBehaviour {

		public AudioClip gameWinClip;
		public AudioClip bgLoopClip;
		
		void Start()
		{
			StartCoroutine(playClips());
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
		IEnumerator playClips()
		{
			audio.clip = gameWinClip;
			audio.Play();
			yield return new WaitForSeconds(audio.clip.length);
			audio.clip = bgLoopClip;
			audio.Play();
			audio.loop = true;
		}
}
