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
    public bool isPlayerTurn = true;
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
        if (isPlayerTurn == false)
        {
            enemyAI();
        }
    }
    private void enemyAI()
    {
        int playerX = testtilemap.instance.playerX;
        int playerY = testtilemap.instance.playerY;

        int dx = 0;
        int dy = 0;

        if (enemyX < playerX)
        {
            dx = 1; 
        }
        else if (enemyX > playerX)
        {
            dx = -1; 
        }

        if (enemyY < playerY)
        {
            dy = 1;
        }
        else if (enemyY > playerY)
        {
            dy = -1;
        }

        TryMoveEnemy(dx, dy);

        isPlayerTurn = true;
    }

    void TryMoveEnemy(int dx, int dy)
    {
        int newX = enemyX + dx;
        int newY = enemyY + dy;

        if (IsEnemyPositionValid(newX, newY))
        {
            Vector3Int oldPosition = new Vector3Int(enemyX, -enemyY, 0);
            testtilemap.instance.myTilemap.SetTile(oldPosition, testtilemap.instance.GetTileForCharacter(testtilemap.instance.mapData[enemyY][enemyX]));

            enemyX = newX;
            enemyY = newY;
            UpdateEnemyTile();
        }
    }
    public bool IsEnemyPositionValid(int x, int y)
    {
        if (x < 0 || x >= testtilemap.instance.columns || y < 0 || y >= testtilemap.instance.rows)
        {
            return false;
        }

        char tileAtPositon = testtilemap.instance.mapData[y][x];
        return tileAtPositon != 'O' && tileAtPositon != 'W' && tileAtPositon != 'H' && tileAtPositon != 'P' && tileAtPositon != 'T' && tileAtPositon != '+' && tileAtPositon != '~' && tileAtPositon != '=' && tileAtPositon != '[' && tileAtPositon != ']' && tileAtPositon != '_' && tileAtPositon != '-' && tileAtPositon != '!';
    }
    void UpdateEnemyTile()
    {

        Vector3Int enemyposition = new Vector3Int(enemyX, -enemyY, 0);
        if (testtilemap.instance.myTilemap.GetTile(enemyposition) == testtilemap.instance.Player && isPlayerTurn == false)
        {
            HealthSystem.health = HealthSystem.health - 20;
        }
        testtilemap.instance.myTilemap.SetTile(enemyposition, testtilemap.instance.enemy);

    }

}
