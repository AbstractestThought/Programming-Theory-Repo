using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public static MazeManager Instance { get; private set; }

    [SerializeField] GameObject MazePiecePrefab;
    [SerializeField] GameObject MazePieceWithPlayer;
    [SerializeField] GameObject[] MazePieces;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        MazePieces = GameObject.FindGameObjectsWithTag("Maze Piece");
        MazePieceWithPlayer = GetPlayerLocation();
    }

    public GameObject GetPlayerLocation()
    {
        GameObject playerPiece = null;
        foreach (GameObject mazePiece in MazePieces)
        {
            if (mazePiece.GetComponent<Maze>().PlayerInRange)
            {
                playerPiece = mazePiece;
            }
        }
        return playerPiece;
    }

    public void GenerateMaze()
    {
           
    }
}
