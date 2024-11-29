using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;

public class moveEnemy : MonoBehaviour
{
    public static Tile enemy;
    private int enemyX = 1;
    private int enemyY = 1;
    

    private void Update()
    {
        
    }
    private void checkDistance()
    {
    }



    bool IsPositionValid(int x, int y)
    {
        if (x < 0 || x >= columns || y < 0 || y >= rows)
        {
            return false;
        }
        char tileAtPositon = testtilemap.mapData[y][x];
        return tileAtPositon != 'O' && tileAtPositon != 'W' && tileAtPositon != 'H' && tileAtPositon != 'P' && tileAtPositon != 'T' && tileAtPositon != '+' && tileAtPositon != '~' && tileAtPositon != '=' && tileAtPositon != '[' && tileAtPositon != ']' && tileAtPositon != '_' && tileAtPositon != '-' && tileAtPositon != '!' && tileAtPositon != 'p';
    }
}
