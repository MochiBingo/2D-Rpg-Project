using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
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
    public Camera mycam;
    bool walkableTile;

    void Start()
    {
        mycam = Camera.main;
        ConvertMapToTilemap(mapinput);
    }
    void Update()
    {
        
    }

    private string[] mapinput = new string[]
        {
        
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTOOOOOTTTTTTT",
        "T                              SSRRRRRSS    T",
        "T                              SSRRRRRSS    T",
        "T                              SSRRRRRSS    T",
        "T                              SSRRRRRSS    T",
        "T                              SSRRRRRSS    T",
        "T                             SSRRRRRRSS    T",
        "T                             SSRRRRRSS     T",
        "T                             SSRRRRRSS     T",
        "T                             SSRRRRRSS     T",
        "TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSST",
        "TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSST",
        "ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
        "ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
        "ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
        "ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
        "ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO",
        "TSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSSSSSSSSST",
        "TSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSSSSSSSSST",
        "T                      SSRRRRRSS            T",
        "T                      SSRRRRRSS            T",
        "T                      SSRRRRRRSS           T",
        "T                       SSRRRRRSS           T",
        "T                       SSRRRRRSS           T",
        "TTTTTTTTTTTTTTTTTTTTTTTTTTOOOOOTTTTTTTTTTTTTT"
        };
    
    
    //string GenerateMapString(int width, int height)
    //{
    //    //legend:
    //    //B=building
    //    //#=building roof
    //    //T=tree
    //    //P=plant
    //    //S=sidewalk
    //    //R=Road
    //    //C=car
    //    //O=obstacle

    //    //Rules:
    //    //map has a border
    //    //car parts must be together
    //    //buildings must look like buildings (complete)
    //    //cars stay on roads, obstacles stay off roads
    //    //nothing in water

        
    //}
    void ConvertMapToTilemap(string[] mapData)
    {
        for (int y= 0; y < mapinput.Length; y++)
        {
            for (int x=0; x < mapinput[y].Length; x++)
            {
                char tileChar = mapinput[y][x];

                Tile tileToPlace = GetTileForCharacter(tileChar);
                Vector3Int position = new Vector3Int(x,-y, 0);
                myTilemap.SetTile(position, tileToPlace);
            }
        }
    }
    private Tile GetTileForCharacter(char character)
    {
        switch (character)
        {
            case 'T':
                return tree;
            case 'R':
                return road;
            case 'S':
                return sidewalk;
            case 'O':
                return obstacle;
            case ' ':
                return empty;
            default:
                return null;

        }
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
