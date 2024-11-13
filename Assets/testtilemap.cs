using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class testtilemap : MonoBehaviour
{
    public Tilemap myTilemap;
    public Tile tree;
    public Tile sidewalk;
    public Tile road;
    public Tile empty;
    public Tile roadbarrier;
    public Tile tree2;
    public Tile hotdogcart;
    public Tile plant;
    public Tile plant2;
    public Tile WaterTR;
    public Tile WaterTL;
    public Tile WaterBR;
    public Tile WaterBL;
    public Tile WaterLeft;
    public Tile WaterRight;
    public Tile WaterTop;
    public Tile WaterBottom;
    public Tile WaterMiddle;
    private System.Random rand = new System.Random();
    
    private const int columns = 45;
    private const int rows = 25;
    void Start()
    {   
        ConvertMapToTilemap(GenerateMapString(columns,rows));
    }
    void Update()
    {
        
    }
    string[] GenerateMapString(int columns, int rows)
    {
        string[] mapinput=new string[rows];

        for (int y = 0; y < rows; y++)
        {
            char[] row = new char[columns];
            for (int x = 0; x < columns; x++)
            {
                if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                {
                    row[x] = 'T';
                }

                else
                {
                    row[x] = GenerateRandomTile(x, y);
                }
                
            }
            mapinput[y] = new string(row);
        }
        PlacePond(mapinput, columns, rows);

        return mapinput;
        //legend:
        //T=tree (random)
        //P=plant (random)
        //O=obstacle (random)
        //W=water (not in yet)
        //R=paths (not in yet)

        //Rules:
        //map has a border (ONE)
        //always a pond
        //keep things off the paths
    }
    void PlacePond(string[] mapData, int columns, int rows)
    {
        int pondWidth = rand.Next(5, 10);
        int pondHeight = rand.Next(3, 8);

        int pondX = rand.Next(1, columns - pondWidth - 1);
        int pondY = rand.Next(1, rows - pondHeight - 1);

        for (int y = pondY; y < pondY + pondHeight; y++)
        {
            char[] row = mapData[y].ToCharArray();
            for (int x = pondX; x < pondX + pondWidth; x++)
            {
                row[x] = 'W';
            }
            mapData[y] = new string(row);
        }
        for (int x = pondX - 1; x < pondX + pondWidth + 1; x++)
        {
            if (pondY - 1 >= 0)
            {
                char[] topRow = mapData[pondY - 1].ToCharArray();
                if (x == pondX - 1)
                {
                    topRow[x] = '+';
                }
                else if (x == pondX + pondWidth)
                {
                    topRow[x] = '=';
                }
                else
                {
                    topRow[x] = '~';
                }
                mapData[pondY - 1] = new string(topRow);
            }
            if (pondY + pondHeight < rows)
            {
                char[] bottomRow = mapData[pondY + pondHeight].ToCharArray();
                if (x == pondX - 1)
                {
                    bottomRow[x] = '-';
                }
                else if (x == pondX + pondWidth)
                {
                    bottomRow[x] = '!';
                }
                else
                {
                    bottomRow[x] = '_';
                }
                mapData[pondY + pondHeight] = new string(bottomRow);
            }
            for (int y = pondY - 1; y < pondY + pondHeight + 1; y++)
            {
                // Left edge
                if (pondX - 1 >= 0)
                {
                    char[] leftRow = mapData[y].ToCharArray();
                    if (y == pondY - 1)
                        leftRow[pondX - 1] = '+'; // Top-left corner
                    else if (y == pondY + pondHeight)
                        leftRow[pondX - 1] = '-'; // Bottom-left corner
                    else
                        leftRow[pondX - 1] = '['; // Left edge
                    mapData[y] = new string(leftRow);
                }

                // Right edge
                if (pondX + pondWidth < columns)
                {
                    char[] rightRow = mapData[y].ToCharArray();
                    if (y == pondY - 1)
                        rightRow[pondX + pondWidth] = '='; // Top-right corner
                    else if (y == pondY + pondHeight)
                        rightRow[pondX + pondWidth] = '!'; // Bottom-right corner
                    else
                        rightRow[pondX + pondWidth] = ']'; // Right edge
                    mapData[y] = new string(rightRow);
                }
            }
        }
    }
    private char GenerateRandomTile(int x, int y)
    {
        if (rand.Next(1, 1000) <= 25)
        {
            return 'O';
        }
        else if (rand.Next(1, 1000) <= 50)
        {
            return 'P';
        }

        else
        {
            return ' ';
        }
    }
    void ConvertMapToTilemap(string[] mapData)
    {
        for (int y= 0; y < mapData.Length; y++)
        {
            for (int x=0; x < mapData[y].Length; x++)
            {
                char tileChar = mapData[y][x];

                Tile tileToPlace = GetTileForCharacter(tileChar);
                Vector3Int position = new Vector3Int(x,-y, 0);
                myTilemap.SetTile(position, tileToPlace);
            }
        }
    }

    private Tile GetTileForCharacter(char character)
    {
        return character switch
        {
            'T' => TreeSelection(),
            'R' => road,
            'S' => sidewalk,
            'O' => ObstacleSelection(),
            'P' => PlantSelection(),
            'W' => WaterMiddle,
            '+' => WaterTL,
            '~' => WaterTop,
            '=' => WaterTR,
            '[' => WaterLeft,
            ']' => WaterRight,
            '-' => WaterBL,
            '_' => WaterBottom,
            '!' => WaterBR,
            ' ' => empty,
            _ => null,
        };
    }
    private Tile TreeSelection()
    {
        int randValue = rand.Next(1, 3);
        return randValue switch
        {
            1 => tree,
            2 => tree2,
            _ => null,
        };
    }
    private Tile ObstacleSelection()
    {
        int randValue = rand.Next(1, 3);
        return randValue switch
        {
            1 => roadbarrier,
            2 => hotdogcart,
            _ => null,
        };
    }
    private Tile PlantSelection()
    {
        int randValue = rand.Next(1, 3);
        return randValue switch
        {
            1 => plant,
            2 => plant2,
            _ => null,
        };
    }
    void LoadPremadeMap(string mapFilePath)
    {


        //ConvertMapToTilemap();
    }
}
