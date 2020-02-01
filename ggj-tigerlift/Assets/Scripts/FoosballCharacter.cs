using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoosballCharacter : MonoBehaviour
{
	[SerializeField] private GameObject m_CharacterPrefab;
	[SerializeField] private GameObject Visual;

	public float MoveSpeed = 2.0f;

	[SerializeField] float m_TimeSinceLastKick = 0.0f;
	public float KickCooldown = 2.0f;
	public float KickImpulse = 1.2f;

	public CharacterRail AttachedRail;

	public int CurrentLife;

	public List<Foosball> BallsInRange = new List<Foosball>();

	private void Awake()
	{
		BallsInRange = new List<Foosball>();

		if (m_CharacterPrefab)
		{
			Instantiate(m_CharacterPrefab, Visual.transform);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		m_TimeSinceLastKick += Time.deltaTime;

    }

	public void OnKick()
	{
		if (m_TimeSinceLastKick < KickCooldown)
		{
			return;
		}

		// do da kick
		foreach (Foosball ball in BallsInRange)
		{
			Vector3 direction = ball.transform.position - transform.position;
			ball.RigidBody.velocity = direction.normalized * ball.RigidBody.velocity.magnitude * KickImpulse;

			//ball.RigidBody.AddForce(direction.normalized * KickImpulse, ForceMode.VelocityChange);
		}

	}

	public void OnUpButton()
	{

		if (AttachedRail)
		{
			AttachedRail.MoveCharacterUp();
		}

	}

	public void OnDownButton()
	{
		if (AttachedRail)
		{
			AttachedRail.MoveCharacterDown();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Foosball ball = other.GetComponent<Foosball>();
		
		if (ball == null)
		{
			return;
		}

		BallsInRange.Add(ball);
	}

	private void OnTriggerExit(Collider other)
	{
		Foosball ball = other.GetComponent<Foosball>();

		if (ball == null)
		{
			return;
		}

		BallsInRange.Remove(ball);
	}
}
