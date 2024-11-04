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
        applyrules();
        
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
    int countcells(int x, int y)
    {
        int count=0;
        if (0 < x && x > 25)
        {
            if (0 < y && y > 25)
            {
                if (map[x + 1, y] == 1)
                {
                    count++;
                }
                if (map[x + 1, y + 1] == 1)
                {
                    count++;
                }
                if (map[x, y + 1] == 1)
                {
                    count++;
                }
                if (map[x - 1, y + 1] == 1)
                {
                    count++;
                }
                if (map[x - 1, y] == 1)
                {
                    count++;
                }
                if (map[x - 1, y - 1] == 1)
                {
                    count++;
                }
                if (map[x, y - 1] == 1)
                {
                    count++;
                }
                if (map[x + 1, y - 1] == 1)
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
                if (countcells(x,y) < 2 && map[x, y] == 1)
                {
                    mapchanges[x, y] = 0;
                }
                if (countcells(x, y) > 3 && map[x,y]==1)
                {
                    mapchanges[x, y] = 0;
                }
                if (countcells(x, y) == 3 && map[x, y] == 0)
                {
                    mapchanges[x, y] = 1;
                }
                if (countcells(x, y) == 2 || countcells(x, y) == 3 && map[x, y] == 1)
                {
                    mapchanges[x, y] = 1;
                }
            }
        }
        map = mapchanges;
        DrawTileMap();
    }
    private void OnGUI()
    {
        Vector3 mouseworldposition = mycam.ScreenToWorldPoint(Input.mousePosition);
        GUI.Label(new Rect(50, 50, 400, 30), $"Mouse: {Input.mousePosition} In cell Space: {myTilemap.WorldToCell(mouseworldposition)}");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
