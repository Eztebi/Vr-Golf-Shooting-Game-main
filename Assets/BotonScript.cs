using UnityEngine;

public class BotonScript : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform positionSpawn;
    void Spawn()
    {
        GameObject newBall = Instantiate(ball,positionSpawn.transform.position,positionSpawn.transform.rotation,this.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Club"))
        {
            Spawn();
        }
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
