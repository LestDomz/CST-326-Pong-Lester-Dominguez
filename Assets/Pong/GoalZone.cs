using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public bool isRightGoal; //Right Score

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Goal Scored in: " + gameObject.name);
            ScoreManager.Instance.AddScore(!isRightGoal);   //adds 1 to text
            other.GetComponent<Ball>().ResetBall();
        }
    }

}
