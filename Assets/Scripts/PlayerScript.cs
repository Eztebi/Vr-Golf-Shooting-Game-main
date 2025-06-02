using UnityEngine;

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
    }
}
