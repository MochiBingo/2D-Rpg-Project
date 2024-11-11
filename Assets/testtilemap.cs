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
    public Tile obstacle;
    public Tile tree2;
    public Camera mycam;
    private System.Random rand = new System.Random();
    
    private const int columns = 45;
    private const int rows = 25;
    void Start()
    {
        mycam = Camera.main;
        
        ConvertMapToTilemap(GenerateMapString(columns,rows));
    }
    void Update()
    {
        
    }

    //private string[] mapinput = new string[]
    //{

    //"TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTOOOOOTTTTTTT",
    //"T                              SSRRRRRSS    T",
    //"T                              SSRRRRRSS    T",
    //"T                              SSRRRRRSS    T",
    //"T                              SSRRRRRSS    T",
    //"T                              SSRRRRRSS    T",
    //"T                             SSRRRRRRSS    T",
    //"T                             SSRRRRRSS     T",
    //"T                             SSRRRRRSS     T",
    //"T                             SSRRRRRSS     T",
    //"TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSST",
    //"TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSST",
    //"ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
    //"ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
    //"ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
    //"ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
    //"ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
    //"TSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSSSSSSSSST",
    //"TSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSSSSSSSSST",
    //"T                      SSRRRRRSS            T",
    //"T                      SSRRRRRSS            T",
    //"T                      SSRRRRRRSS           T",
    //"T                       SSRRRRRSS           T",
    //"T                       SSRRRRRSS           T",
    //"TTTTTTTTTTTTTTTTTTTTTTTTTTOOOOOTTTTTTTTTTTTTT"
    //};


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
        return mapinput;
        //legend:
        //B=building
        //#=building roof
        //T=tree
        //P=plant
        //S=sidewalk
        //R=Road
        //C=car
        //O=road barrier

       //Rules:
        //map has a border
        //car parts must be together
        //buildings must look like buildings (complete)
        //cars stay on roads, obstacles stay off roads
        //nothing in water 
    }
    private char GenerateRandomTile(int x, int y)
    {
        return ' ';
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
    private Tile GetTileForCharacter(char character)
    {
        return character switch
        {
            'T' => TreeSelection(),
            'R' => road,
            'S' => sidewalk,
            'O' => obstacle,
            ' ' => empty,
            _ => null,
        };
    }
    void LoadPremadeMap(string mapFilePath)
    {


        //ConvertMapToTilemap();
    }
    
    private void OnGUI()
    {
        Vector3 mouseworldposition = mycam.ScreenToWorldPoint(Input.mousePosition);
        GUI.Label(new Rect(50, 50, 400, 30), $"Mouse: {Input.mousePosition} In cell Space: {myTilemap.WorldToCell(mouseworldposition)}");
    }
}
