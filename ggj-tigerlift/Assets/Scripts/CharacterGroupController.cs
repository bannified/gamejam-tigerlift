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

	public List<GameObject> TowerPieces;

	private void Awake()
	{
		SetupEvents();
	}

	// Start is called before the first frame update
	void Start()
    {
		UpdateUIElements();
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

		int i = 0;
		for (; i < Character.CurrentLife; i++)
		{
			TowerPieces[i].SetActive(true);
		}

		for (; i < TowerPieces.Count; i++)
		{
			TowerPieces[i].SetActive(false);
		}
	}
}
