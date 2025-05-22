using UnityEngine;

public class PlayerScript : MonoBehaviour
{
     public Observer<int> Health = new Observer<int>(100);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            Health.Value += 10;
        }
    }
    public void TakeDamage(int damage)
    {
        Health.Value -= damage;
    }
}
