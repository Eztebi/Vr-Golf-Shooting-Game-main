using UnityEngine;

public class BonusHole : MonoBehaviour
{
    [SerializeField] private SpawnMagazines spawneer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (spawneer == null)
            {
                Debug.Log("No espawneoMagazines");
                return;
            }

            else
            {
                ICommand commandSpawnMag = new ISpawnMagazines(spawneer, spawneer.magPrefabs);
                CommandInvoker.ExecuteCommand(commandSpawnMag);
            }
            Ball ball = other.GetComponent<Ball>();
            if (ball != null)
            {
                if (ball.Score == 0)
                {
                    ICommand commandScore = new IScoreMultiplier(ball, 100);
                    CommandInvoker.ExecuteCommand(commandScore);
                }
                else
                {
                    ICommand commandScore = new IScoreMultiplier(ball, ball.Score);
                    CommandInvoker.ExecuteCommand(commandScore);
                }
                //ball.
                ball.DeactivateHit();
            }
        }

    }
}
