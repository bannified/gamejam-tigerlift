using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRail : MonoBehaviour
{

	[SerializeField] FoosballCharacter m_Character; 

	[SerializeField] float m_StartingDeltaZ;

	[SerializeField] float m_MaxDeltaZ;
	[SerializeField] float m_MinDeltaZ;

	[SerializeField] float m_TargetZ;

	[Range(0.01f, 1.0f)]
	[SerializeField] float m_LerpAmount = 0.9f;

	private bool isMovingUp;

	// Start is called before the first frame update
	void Start()
    {
        if (m_Character != null)
		{
			m_Character.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + m_StartingDeltaZ);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (m_Character == null)
		{
			return;
		}

		m_Character.transform.position = new Vector3(m_Character.transform.position.x, m_Character.transform.position.y, Mathf.Lerp(m_Character.transform.position.z, m_TargetZ, m_LerpAmount));
    }

	public void MoveCharacterUp()
	{
		if (!isMovingUp)
		{
			m_TargetZ = m_Character.transform.position.z;
		}

		m_TargetZ += m_Character.MoveSpeed * Time.deltaTime;

		m_TargetZ = Mathf.Min(m_TargetZ, transform.position.z + m_MaxDeltaZ);
		
		isMovingUp = true;
	}

	public void MoveCharacterDown()
	{
		if (isMovingUp)
		{
			m_TargetZ = m_Character.transform.position.z;
		}

		m_TargetZ -= m_Character.MoveSpeed * Time.deltaTime;

		m_TargetZ = Mathf.Max(m_TargetZ, transform.position.z - m_MaxDeltaZ);

		isMovingUp = false;
	}
}
