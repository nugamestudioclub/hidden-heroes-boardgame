using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private State currentState;
    public State CurrentState { get => currentState; }
    public static GameState Instance;

    [SerializeField]
    private Spinner spinner;
    public Spinner Spinner => spinner;

    [SerializeField]
    private Board board;
    public Board Board => board;

    [SerializeField]
    private AIPlayerController child;

    [SerializeField]
    private HumanPlayerController grampa;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
           
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    private bool isfirstTime = true;
    private void Update()
    {
        if (isfirstTime)
        {
            isfirstTime = false;
            NextState();
        }
    }

    public enum State
    {
        PlayerTurn,
        AITurn,
        DialoguePlayer,
        DialogueAI,
    }

    public void NextState()
    {
        if (currentState == State.PlayerTurn)
        {
            currentState = State.AITurn;
            child.TakeTurn();
        }
        else {
            currentState = State.PlayerTurn;
            grampa.TakeTurn();
        }
    }

}