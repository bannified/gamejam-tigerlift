using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foosball : MonoBehaviour
{
	[SerializeField] Collider m_Coll;

	public Rigidbody RigidBody;

	[SerializeField] float m_MinLaunchStrength = 5.0f;
	[SerializeField] float m_MaxLaunchStrength = 15.0f;

	private void Start()
	{
		Invoke("LaunchInRandomDirection", .5f);
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	public void LaunchInRandomDirection()
	{
		Vector3 launchVector = Random.onUnitSphere;
		launchVector.y = 0.0f; // we don't need the y-component
		launchVector.Normalize();

		launchVector *= Random.Range(m_MinLaunchStrength, m_MaxLaunchStrength);

		RigidBody.AddForce(launchVector, ForceMode.Impulse);
	}
}
