using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	/// <summary>
	/// Input button names
	/// </summary>
	[SerializeField] private KeyCode m_UpButton = KeyCode.A;
	[SerializeField] private KeyCode m_DownButton = KeyCode.Z;
	[SerializeField] private KeyCode m_KickButton = KeyCode.LeftShift;

	/// <summary>
	/// The character that this controller is controlling.
	/// public because... it's easier in a gamejam.
	/// </summary>
	public FoosballCharacter Character;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		// Go up
		if (Input.GetKey(m_UpButton))
		{
			Character.OnUpButton();
		} else if (Input.GetKey(m_DownButton)) // go down
		{
			Character.OnDownButton();
		}

		if (Input.GetKeyDown(m_KickButton))
		{
			// kick
			Character.OnKick();
		}


    }
}
