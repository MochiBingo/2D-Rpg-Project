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
    public Camera mycam;
    //public TileBase livecell;
    public int[,] map = new int[45, 25];
    void Start()
    {
        mycam = Camera.main;
        
    }
    void Update()
    {
        Debug.Log(mapString);
    }
    bool walkableTile;
    static string mapinput =
        @"
        TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTOOOOOTTTTTTT
        T                              SSRRRRRSS    T
        T                              SSRRRRRSS    T
        T                              SSRRRRRSS    T
        T                              SSRRRRRSS    T
        T                              SSRRRRRSS    T
        T                             SSRRRRRRSS    T
        T                             SSRRRRRSS     T
        T                             SSRRRRRSS     T
        T                             SSRRRRRSS     T
        TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSST
        TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSST
        ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO
        ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO
        ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO
        ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO
        ORRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRO
        TSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSSSSSSSSST
        TSSSSSSSSSSSSSSSSSSSSSSSSRRRRRSSSSSSSSSSSSSST
        T                      SSRRRRRSS            T
        T                      SSRRRRRSS            T
        T                      SSRRRRRRSS           T
        T                       SSRRRRRSS           T
        T                       SSRRRRRSS           T
        TTTTTTTTTTTTTTTTTTTTTTTTTTOOOOOTTTTTTTTTTTTTT
        ";
    string[] mapString = mapinput.Select(x => x.ToString()).ToArray();
    
    
    string GenerateMapString(int width, int height)
    {
        //legend:
        //B=building
        //#=building roof
        //T=tree
        //P=plant
        //S=sidewalk
        //R=Road
        //C=car
        //O=obstacle

        //Rules:
        //map has a border
        //car parts must be together
        //buildings must look like buildings (complete)
        //cars stay on roads, obstacles stay off roads
        //nothing in water


        return "s";
    }
    void ConvertMapToTilemap(string mapData)
    {
        
        
        for (int y=-1; y < map.GetLength(1); y++)
        {
            for (int x=-1; x < map.GetLength(0); x++)
            {

            }
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
