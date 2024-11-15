using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playermovement : MonoBehaviour
{
    //public Tilemap tilemap;
    //public Tile empty;
    //public float movespeed = 1f;
    //private Vector3 targetPosition;
    //public float tilesize = 0.16f;
    //private Vector2 inputDirection;
    //void Start()
    //{
    //    targetPosition = transform.position;
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        inputDirection = Vector2.up;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        inputDirection = Vector2.down;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        inputDirection = Vector2.left;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        inputDirection= Vector2.right;
    //    }

    //    if (inputDirection != Vector2.zero)
    //    {
    //        Vector3 newTargetPosition = transform.position + new Vector3 (inputDirection.x, inputDirection.y, 0) * tilesize;
    //        Vector3Int cellPosition = tilemap.WorldToCell(newTargetPosition);

    //        Tile tileAtTarget = tilemap.GetTile<Tile>(cellPosition);
    //        if (tileAtTarget == empty)
    //        {
    //            targetPosition = newTargetPosition;
    //        }
    //    }

    //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, movespeed * Time.deltaTime);
    //}
}
