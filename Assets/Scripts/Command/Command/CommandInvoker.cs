using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UnityEngine;

public class CommandInvoker 
{
    private static Stack<ICommand> undoStack = new Stack<ICommand>();
    private static List<ICommand> recentCommands = new List<ICommand>(6);
    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);

        recentCommands.Add(command);
        if (recentCommands.Count > 6)
            recentCommands.RemoveAt(0); 

        if (recentCommands.Count == 6 &&
            recentCommands.All(cmd => cmd is IScoreMultiplier || cmd is ISpawnMagazines))
        {
            Debug.Log("¡BONUS!");
            RoundManager.Instance.SetNewScore(20);

            recentCommands.Clear();
        }
    }

    public static void UndoCommand()
    {
        if(undoStack.Count > 0)
        {
            ICommand activeCommand = undoStack.Pop();
            activeCommand.Undo();
        }
    }

}
