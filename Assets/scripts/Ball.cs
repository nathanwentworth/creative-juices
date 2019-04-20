using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody ConnectedBody { get; set; }
    void OnTriggerEnter2D(Collider2D other)
    {
        Goal goal = other.GetComponent<Goal>();
        if (goal) {
            if (!Manager.scores.ContainsKey(goal.side)) {
                Manager.scores.Add(goal.side, 0);
            }
            Manager.scores[goal.side]++;
            Debug.Log("side: " + goal.side + ", score: " + Manager.scores[goal.side]);
        }
    }

    IEnumerator Shrink() {
        yield return new WaitForEndOfFrame();
    }
}
