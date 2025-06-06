using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
     public Observer<int> Health = new Observer<int>(100);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health.Invoke();
    }
    public void TakeDamage(int damage)
    {
        Health.Value -= damage;

        if (Health.Value <= 0)
        {
            ReiniciarJuego();
        }
    }
    private void ReiniciarJuego()
    {
        Scene sceneActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneActual.name);
    }
}
