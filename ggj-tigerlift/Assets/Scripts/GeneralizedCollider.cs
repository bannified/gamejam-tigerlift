using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralizedCollider : MonoBehaviour
{

	public System.Action<Collider> OnTriggerEnterEvent;
	public System.Action<Collider> OnTriggerExitEvent;

	public void OnTriggerEnter(Collider other)
	{
		OnTriggerEnterEvent?.Invoke(other);
	}

	public void OnTriggerExit(Collider other)
	{
		OnTriggerExitEvent?.Invoke(other);
	}
}
