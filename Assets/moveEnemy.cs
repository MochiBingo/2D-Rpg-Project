using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Numerics;

public class moveEnemy : MonoBehaviour
{
    public static moveEnemy instance;
    public int enemyX = 40;
    public int enemyY = 20;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UpdateEnemyTile();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryMoveEnemy(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryMoveEnemy(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMoveEnemy(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMoveEnemy(-1, 0);
        }
    }
    private void checkDistance()
    {

    }

    void TryMoveEnemy(int dx, int dy)
    {
        int newX = enemyX + dx;
        int newY = enemyY + dy;

        if (testtilemap.instance.IsPositionValid(newX, newY))
        {
            Vector3Int oldPosition = new Vector3Int(enemyX, -enemyY, 0);
            testtilemap.instance.myTilemap.SetTile(oldPosition, testtilemap.instance.GetTileForCharacter(testtilemap.instance.mapData[enemyY][enemyX]));

            enemyX = newX;
            enemyY = newY;
            UpdateEnemyTile();
        }
    }
    void UpdateEnemyTile()
    {

        Vector3Int enemyposition = new Vector3Int(enemyX, -enemyY, 0);
        if (testtilemap.instance.myTilemap.GetTile(enemyposition) == testtilemap.instance.Player)
        {
            testtilemap.instance.dieText.SetActive(true);
            testtilemap.instance.gameActive = false;
        }
        testtilemap.instance.myTilemap.SetTile(enemyposition, testtilemap.instance.enemy);

    }

}
