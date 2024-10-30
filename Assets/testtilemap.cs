using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class testtilemap : MonoBehaviour
{
    public Tilemap myTilemap;
    public Camera mycam;
    public TileBase mytilebase;
    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        myTilemap.SetTile(new Vector3Int(0, 0, 0), mytilebase);
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
