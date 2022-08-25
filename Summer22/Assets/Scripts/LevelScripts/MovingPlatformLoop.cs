using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLoop : MonoBehaviour
{
   public bool freezeAtEnd;
    public Transform pos1, pos2;
    public List<Transform> positions;
    public int positionsIndex = 0;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == positions[positionsIndex].position)
        {

            if (positionsIndex < positions.Count - 1)
            {
                Debug.Log("index increased to " + positionsIndex);
                positionsIndex++;
            }
            else
            {
                Debug.Log("Hit else");
                if (!freezeAtEnd)
                {
                    positionsIndex = 0;//Goes back to start
                }
            }
            nextPos = positions[positionsIndex].position;
        }


        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    void onColliderEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7 || col.gameObject.layer == 8)
        {
            col.gameObject.transform.parent = transform;//Assigns this platform as the parent
        }
    }

    void onColliderExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7 || col.gameObject.layer == 8)
        {
            col.gameObject.transform.parent = null;//Unassigns this platform as the parent
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
