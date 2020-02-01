using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroupController : MonoBehaviour
{

	public GeneralizedCollider RepairCollider;
	public GeneralizedCollider DamageCollider;

	public PlayerController PlayerController;
	public FoosballCharacter Character;
	public CharacterRail Rail;

	private void Awake()
	{
		SetupEvents();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void SetupEvents()
	{
		RepairCollider.OnTriggerEnterEvent += OnColliderEnterGate;
		DamageCollider.OnTriggerEnterEvent += OnColliderHitCastle;
	}

	void OnColliderEnterGate(Collider other)
	{
		Character.CurrentLife += 1;
		GameManager.Instance.ResetBall();
	}

	void OnColliderHitCastle(Collider other)
	{
		Character.CurrentLife -= 1;
	}

	void UpdateUIElements()
	{

	}
}
