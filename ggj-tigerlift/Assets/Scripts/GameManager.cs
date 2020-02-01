using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager m_Instance;

	public static GameManager Instance
	{
		get { return m_Instance; }
	}

	public Foosball Ball;
	public GameplayStage Stage;

	public FoosballCharacter player1;
	public FoosballCharacter player2;

	public GameObject WinScreen;
	public GameObject Player1WinText;
	public GameObject Player2WinText;

	public GameObject GameStartScreen;

	bool gameStarted = false;

	private void Awake()
	{
		m_Instance = this;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartGame();
		}

		if (!gameStarted)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}

		if (WinScreen.activeSelf)
		{
			return;
		}

		if (player1.CurrentLife <= 0 || player2.CurrentLife >= 5)
		{
			// player 2 wins
			WinScreen.SetActive(true);
			Player1WinText.SetActive(false);
			Player2WinText.SetActive(true);
			Time.timeScale = 0.0f;
		}

		if (player2.CurrentLife <= 0 || player1.CurrentLife >= 5)
		{
			// player 1 wins
			WinScreen.SetActive(true);
			Player1WinText.SetActive(true);
			Player2WinText.SetActive(false);
			Time.timeScale = 0.0f;
		}
	}

	void StartGame()
	{
		GameStartScreen.SetActive(false);
		ResetBall();
		gameStarted = true;
	}

	public void ResetBall()
	{
		Ball.transform.position = Stage.BallStartingPoint.transform.position;
		Ball.Stop();
		Invoke("LaunchBall", 0.5f);
	}

	public void LaunchBall()
	{
		Ball.LaunchInRandomDirection();
	}
}
