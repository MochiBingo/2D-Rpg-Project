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
    public static Tile enemy;
    private int enemyX = testtilemap.columns - 2;
    private int enemyY = testtilemap.rows - 2;
    public static string[] mapData;

    private void Update()
    {
        UpdateEnemyTile();
    }
    private void checkDistance()
    {
    }

    void TryMoveEnemy(int dx, int dy)
    {
        int newX = enemyX + dx;
        int newY = enemyY + dy;

        if (IsPositionValid(newX, newY))
        {
            Vector3Int oldPosition = new Vector3Int(enemyX, -enemyY, 0);
            testtilemap.myTilemap.SetTile(oldPosition, testtilemap.GetTileForCharacter(mapData[enemyY][enemyX]));

            enemyX = newX;
            enemyY = newY;
            UpdateEnemyTile();
        }
    }
    void UpdateEnemyTile()
    {
        Vector3Int position = new Vector3Int(enemyX, -enemyY, 0);
        if (testtilemap.myTilemap.GetTile(position) == testtilemap.Player)
        {
            testtilemap.dieText.SetActive(true);
        }
        testtilemap.myTilemap.SetTile(position, enemy);

    }

    bool IsPositionValid(int x, int y)
    {
        if (x < 0 || x >= testtilemap.columns || y < 0 || y >= testtilemap.rows)
        {
            return false;
        }
        char tileAtPositon = mapData[y][x];
        return tileAtPositon != 'O' && tileAtPositon != 'W' && tileAtPositon != 'H' && tileAtPositon != 'P' && tileAtPositon != 'T' && tileAtPositon != '+' && tileAtPositon != '~' && tileAtPositon != '=' && tileAtPositon != '[' && tileAtPositon != ']' && tileAtPositon != '_' && tileAtPositon != '-' && tileAtPositon != '!' && tileAtPositon != 'p';
    }
}
