using UnityEngine;

public interface ICommand<T>
{
    void Execute(T clase);
}
