using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomPitchShift : MonoBehaviour
{

	// Use this for initialization
	IEnumerator Start ()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.pitch = 1f;

        while (Application.isPlaying)
        {
            audio.pitch += Random.Range(-0.2f, 0.2f);
            yield return new WaitForSeconds(1f);
            yield return new WaitWhile(() => audio.isPlaying);
        }
	}
}
