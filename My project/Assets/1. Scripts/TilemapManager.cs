using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Tilemaps;

public class TestIsometric : MonoBehaviour
{
    public Camera _mainCamera;
    public Tilemap _tileMap;
    private Vector3 _clickPos = Vector3.zero;
    private Vector3Int _tilemapCell = Vector3Int.zero;

    IEnumerator OnMouseUp()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 tilePos = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z)) - transform.position;

        _tilemapCell = _tileMap.LocalToCell(tilePos);
        _clickPos = _tileMap.GetCellCenterLocal(_tilemapCell);

        yield return null;
    }
}
