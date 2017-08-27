using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [HideInInspector] public BoardManager Board;

    // controls

    public GameObject P1LaunchButton;
    public GameObject P2LaunchButton;
    public GameObject P1PositionSelector;
    public GameObject P2PositionSelector;
    public GameObject P1DirectionSelector;
    public GameObject P2DirectionSelector;

    //Awake is always called before any Start functions
    void Awake()
    {
        Debug.Log("GameManager.Awake");
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a G
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        Board = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level
        InitGame();
    }

    private void InitGame()
    {
        Board.Init();
    }

    public void P1LaunchOnClick(String name)
    {
        Debug.Log("P1LaunchClick" + name);
        Player player;
        if ("P1Launch".Equals(name))
        {
            player = instance.Board.Field.Player1();
        }
        else
        {
            player = instance.Board.Field.Player2();
        }
        instance.Board.Field.Launch(player);
    }
}