using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    public Vector3 Position { get; }
    public void Invoke(Vector2 position);
    public void Undo();
}
