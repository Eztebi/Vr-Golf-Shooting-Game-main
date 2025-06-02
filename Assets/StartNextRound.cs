using UnityEngine;

public class StartNextRound : MonoBehaviour
{ 
    public Observer<bool> StartNext = new Observer<bool>(false);
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
        StartNext.Invoke();
}

// Update is called once per frame
void Update()
{
}
public void StartRound()
{
    StartNext.Value = true;
}
}
