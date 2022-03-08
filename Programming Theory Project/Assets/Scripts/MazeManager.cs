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
    GameObject LastPlayerPos;

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
        if (MazePieceWithPlayer != null)
        {
            GenerateMaze();
        }
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
        if (MazePieceWithPlayer != LastPlayerPos)
        {
            LastPlayerPos = MazePieceWithPlayer;
            GameObject[] unusedMazePieces = MazePieces.Where(b => !b.GetComponent<Maze>().PlayerInRange).Select(b => b).ToArray();
            foreach (GameObject piece in unusedMazePieces)
            {
                Destroy(piece);
            }

            Vector3 generationCenter = MazePieceWithPlayer.transform.position;
            Vector3 xPos = new Vector3((generationCenter.x + 50), generationCenter.y, generationCenter.z);
            Vector3 zPos = new Vector3(generationCenter.x, generationCenter.y, (generationCenter.z + 50));
            Vector3 negXPos = new Vector3((generationCenter.x - 50), generationCenter.y, generationCenter.z);
            Vector3 negZPos = new Vector3(generationCenter.x, generationCenter.y, (generationCenter.z - 50));

            Instantiate(MazePiecePrefab, xPos, MazePiecePrefab.transform.rotation);
            Instantiate(MazePiecePrefab, zPos, MazePiecePrefab.transform.rotation);
            Instantiate(MazePiecePrefab, negXPos, MazePiecePrefab.transform.rotation);
            Instantiate(MazePiecePrefab, negZPos, MazePiecePrefab.transform.rotation);
        }   
    }
}
