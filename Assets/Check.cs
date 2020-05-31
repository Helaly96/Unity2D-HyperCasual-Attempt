using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    public Vector2 target;
    bool Collided_with_player = false;
    private Text Score_text;
    public GameObject Particles;
    private GameObject PS;

    private void Start()
    {
        Score_text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        PS         = GameObject.FindGameObjectWithTag("SS");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")))
        {
            Collided_with_player = true;
        }
    }

    private void OnDestroy()
    {
        if ( !(Collided_with_player))
        {
            int score = int.Parse(Score_text.text);
            score += 1;
            Score_text.text = score.ToString();
            GameObject x = Instantiate(Particles, PS.transform.position, PS.transform.rotation);
            Destroy(x, 0.1f);

        }

  
    }
}
