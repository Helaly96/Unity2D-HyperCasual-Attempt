using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public GameObject[] Spawnpoints;

    //Lower left corner
    //Upper left corner
    //Upper right corner
    //Lower right corner

    public GameObject[] Corners;
    public GameObject Ball;
    Task t;

    private void Start()
    {
        float rand_spawn_point = Random.Range(0, Spawnpoints.Length);
        t = new Task(NewBallToKick(rand_spawn_point));
    }
    // Update is called once per frame
    void Update()
    {
        if( !(t.Running) )
        {
            float rand_spawn_point = Random.Range(0, Spawnpoints.Length);
            t = new Task(NewBallToKick(rand_spawn_point));

        }
    }

    IEnumerator NewBallToKick(float spawn_point)
    {

        
        GameObject x= Instantiate(Ball, Spawnpoints[(int)spawn_point].transform.position, Spawnpoints[(int)spawn_point].transform.rotation);
        float rand_x = Random.Range(Corners[0].gameObject.transform.position.x, Corners[3].gameObject.transform.position.x);
        float rand_y = Random.Range(Corners[1].gameObject.transform.position.y, Corners[2].gameObject.transform.position.x);
        x.GetComponent<Check>().target = new Vector2(rand_x, rand_y);
        Vector2 dir = new Vector3(rand_x, rand_y) - Spawnpoints[(int)spawn_point].transform.position;
        x.GetComponent<Rigidbody2D>().AddForce(dir * 170);

        Destroy(x, 1.3f);
        yield return new WaitForSeconds(1.5f);

    }
}
