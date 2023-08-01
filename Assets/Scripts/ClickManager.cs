using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject player;
    int groundLayer;
    public Grid grid;
    public GameObject cell;
    // Start is called before the first frame update
    void Start()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        SelectGrid();
    }
    void SelectGrid()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200, groundLayer))
        {
            Vector3Int gridPos = grid.WorldToCell(hit.point);
            Vector3 coordinate = grid.CellToWorld(gridPos);
            cell.transform.position = coordinate + (Vector3.up * 0.01f);
            if (Input.GetMouseButtonDown(0))
            {
                player.GetComponent<PlayerControl>().MoveToward(coordinate);
            }
        }
    }
}
