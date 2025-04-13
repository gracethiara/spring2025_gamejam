using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameStateManager.IsPlayingGame)
            return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInfo v_winningPlayer = collision.gameObject.GetComponent<PlayerInfo>();
            GameStateManager.OnReachFinishLine(v_winningPlayer);
        }
    }
}
