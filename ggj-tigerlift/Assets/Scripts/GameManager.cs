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


	private void Awake()
	{
		m_Instance = this;
	}

	private void Start()
	{
		StartGame();
	}

	void StartGame()
	{
		ResetBall();
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
