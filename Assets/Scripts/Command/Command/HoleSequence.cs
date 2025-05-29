using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class HoleSequence : MonoBehaviour
{
    public List<ICommand> correctSequence;
    private List<ICommand> currentSequence = new();

   

    public void RegisterCommand(ICommand command)
    {
        currentSequence.Add(command);
        if (currentSequence.Count > correctSequence.Count)
        {
            currentSequence.Clear(); // reset por orden incorrecto
            return;
        }

        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (currentSequence[i].GetType() != correctSequence[i].GetType())
            {
                currentSequence.Clear(); // orden incorrecto
                return;
            }
        }

        if (currentSequence.Count == correctSequence.Count)
        {
            // Ejecutar toda la secuencia si fue correcta
            foreach (var cmd in correctSequence)
                //cmd.Execute(weapon);

            currentSequence.Clear(); // reset para repetir
        }
    }
}
