using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoosballCharacter : MonoBehaviour
{

	public float MoveSpeed = 2.0f;

	[SerializeField] float m_TimeSinceLastKick = 0.0f;
	public float KickCooldown = 2.0f;

	public CharacterRail AttachedRail;

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
}
