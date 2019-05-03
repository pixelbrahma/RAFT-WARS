using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField] private GameObject trajectoryPrefab;
    [SerializeField] private GameObject shotPrefab;
    public static float power;
    public Vector2 direction;
    const int numberOfProjectiles = 7;
    struct Position
    {
       public float x;
       public float y;
    }
    bool first = true;
    GameObject[] traj = new GameObject[numberOfProjectiles];
    bool fire = false;

    void Start () {

	}
	

	void Update () {

        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mPosition);
        direction = mPosition - transform.position;
        transform.up = direction.normalized;
        power = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        if (fire == false)
        {
            CreateProjectiles();
            if (Input.GetMouseButtonDown(0))
            {
                GameObject shot = Instantiate(shotPrefab, traj[1].transform.position, Quaternion.identity);
                fire = true;
            }
        }
    }

    void CreateProjectiles()
    {
        Vector2[] pos = new Vector2[numberOfProjectiles];
        float projectileOffsetX = direction.x / numberOfProjectiles;
        float projectileOffsetY = direction.y / numberOfProjectiles;
        Position[] trajectoryPoints = new Position[numberOfProjectiles];
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            trajectoryPoints[i].x = transform.position.x + i * projectileOffsetX;
            trajectoryPoints[i].y = transform.position.y + i * projectileOffsetY;
            pos[i] = new Vector2(trajectoryPoints[i].x, trajectoryPoints[i].y);
            if (first)
            {
                traj[i] = Instantiate(trajectoryPrefab, pos[i], Quaternion.identity) as GameObject;
                if (i == numberOfProjectiles - 1)
                {
                    first = false;
                }
            }
            traj[i].transform.position = pos[i];
        }
    }
}
