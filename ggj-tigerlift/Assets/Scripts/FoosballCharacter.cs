using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoosballCharacter : MonoBehaviour
{
	[SerializeField] private GameObject m_CharacterPrefab;
	[SerializeField] private GameObject Visual;

	[SerializeField] private GameObject m_KickEffectPrefab;

	public float MoveSpeed = 2.0f;

	[SerializeField] float m_TimeSinceLastKick = 0.0f;
	public float KickCooldown = 2.0f;
	public float KickImpulse = 1.2f;

	public float KickMinVelocityMagnitude = 5.0f;

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
			Vector3 normalized = direction.normalized;
			//float angle = Mathf.Atan(direction.z / direction.x);
			//float angleDeg = angle * Mathf.Rad2Deg;

			if (ball.RigidBody.velocity.magnitude >= KickMinVelocityMagnitude)
			{
				ball.RigidBody.velocity = normalized * ball.RigidBody.velocity.magnitude * KickImpulse;
				print("normal kick");
			} else
			{
				// apply min velocity in other direction
				//ball.RigidBody.velocity = new Vector3(KickMinVelocityMagnitude * Mathf.Cos(angle), 0.0f, KickMinVelocityMagnitude * Mathf.Sin(angle));
				ball.RigidBody.velocity = KickImpulse * normalized * KickMinVelocityMagnitude;
				print("min kick");
			}

			Vector3 effectPos = transform.position + 0.5f * direction;
			effectPos.y = transform.position.y;

			Instantiate(m_KickEffectPrefab, effectPos, Quaternion.identity);

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
