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

	public FoosballCharacter OpponentCharacter;

	public PlayerUIPanel UIPanel;

	private void Awake()
	{
		SetupEvents();
	}

	// Start is called before the first frame update
	void Start()
    {
		UpdateUIElements();
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
		OpponentCharacter.CurrentLife += 1;
		GameManager.Instance.ResetBall();
		OpponentCharacter.GetComponentInParent<CharacterGroupController>().UpdateUIElements();
		UpdateUIElements();
	}

	void OnColliderHitCastle(Collider other)
	{
		Character.CurrentLife -= 1;
		UpdateUIElements();
	}

	void UpdateUIElements()
	{
		UIPanel.ScoreText.text = Character.CurrentLife.ToString();
	}
}
