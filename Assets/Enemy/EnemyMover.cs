using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 4f)] float speedModifor = 1f;
    Enemy enemy;

    private void OnEnable()
    {
        FindPath();
        retunrToStart();
        StartCoroutine(FollowPath());
        speedModifor += 0.3f;
        speedModifor = Mathf.Clamp(speedModifor, 0f, 4f);
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        GameObject wayPoints = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in wayPoints.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void retunrToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPos);
            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speedModifor;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    private void FinishPath()
    {
        enemy.yoinkGoldOnExit();
        this.gameObject.SetActive(false);
    }
}
