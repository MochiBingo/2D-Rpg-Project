using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class testtilemap : MonoBehaviour
{
    public Tilemap myTilemap;
    public Camera mycam;
    public TileBase livecell;
    public int[,] map = new int[25,25];
    
    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                
                map[x, y] = UnityEngine.Random.Range(0, 2);
            }
        }
        DrawTileMap();
        
    }
    void DrawTileMap()
    {
        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                if (map[x, y] == 0)
                {
                    myTilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
                else
                {
                    myTilemap.SetTile(new Vector3Int(x, y, 0), livecell);
                }
            }
        }
    }
    public bool Checkclivecell(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1))
        {
            if (map[x, y] == 1)
            {
                return true;
            }
        }
        return false;
    }
    public int countcells(int x, int y)
    {
        int count=0;
        for (int check_x = -1; check_x <= 1; check_x++)
        {
            for (int check_y = -1; check_y <= 1; check_y++)
            {
                if (check_y == 0 && check_x == 0)
                {
                    continue;
                }
                bool resultisalivecheck = Checkclivecell(x + check_x, y + check_y);
                if (resultisalivecheck == true)
                {
                    count++;
                }
            }
        }
        return count;
    }
    void applyrules()
    {
        int[,] mapchanges = new int[25, 25];
        
        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                mapchanges[x, y] = map[x, y];
                if (countcells(x, y) < 2 && map[x, y] == 1)
                {
                    mapchanges[x, y] = 0;
                }
                if (countcells(x, y) > 3 && map[x, y] == 1)
                {
                    mapchanges[x, y] = 0;
                }
                if (countcells(x, y) == 3 && map[x, y] == 0)
                {
                    mapchanges[x, y] = 1;
                }
                if ((countcells(x, y) == 2 || countcells(x, y) == 3) && map[x, y] == 1)
                {
                    mapchanges[x, y] = 1;
                }
                
            }
        }
        map = mapchanges;
    }
    private void OnGUI()
    {
        Vector3 mouseworldposition = mycam.ScreenToWorldPoint(Input.mousePosition);
        GUI.Label(new Rect(50, 50, 400, 30), $"Mouse: {Input.mousePosition} In cell Space: {myTilemap.WorldToCell(mouseworldposition)}");
    }
    // Update is called once per frame
    void Update()
    {
        applyrules();
        DrawTileMap();
    }
}
