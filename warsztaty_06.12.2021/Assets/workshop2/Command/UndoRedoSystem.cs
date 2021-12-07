using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoRedoSystem
{
    private Stack<ICommand> undoStack;

    public UndoRedoSystem()
    {
        undoStack = new Stack<ICommand>();
    }

    public void Do(ICommand cmd) {
        undoStack.Push(cmd);
        cmd.Execute();
    }

    public void Undo() {
        if (undoStack.Count > 0) {
            ICommand cmd = undoStack.Pop();
            cmd.Revert();
        }
    }
}
