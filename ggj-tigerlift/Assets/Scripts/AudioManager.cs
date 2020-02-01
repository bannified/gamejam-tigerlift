using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public List<AudioClip> clips;

	private void Awake()
	{
		GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Count - 1)];
		GetComponent<AudioSource>().Play();
	}
}
