using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T>
{
    private Func<T> createFunc;
    private Action<T> actionOnGet;
    private Action<T> actionOnRelease;
    private Action<T> actionOnDestroy;
    private Stack<T> availableItems;
    private List<T> unavailableItems;

    public ObjectPooling(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease, Action<T> actionOnDestroy)
    {
        this.createFunc = createFunc;
        this.actionOnGet = actionOnGet;
        this.actionOnRelease = actionOnRelease;
        this.actionOnDestroy = actionOnDestroy;
        this.availableItems = new Stack<T>();
        this.unavailableItems = new List<T>();
    }

    public T Get() {
        T item;
        if (availableItems.Count > 1) {
            item = availableItems.Pop();
        } else {
            item = createFunc.Invoke();
        }

        unavailableItems.Add(item);

        actionOnGet.Invoke(item);
        
        return item;
    }

    public void Release(T item) {
        if (!unavailableItems.Remove(item)) {
            return;
        }

        availableItems.Push(item);
        actionOnRelease.Invoke(item);
    }

    public void Clear() {
        foreach (T item in availableItems) {
            actionOnDestroy.Invoke(item);
        }

        availableItems.Clear();

        foreach (T item in unavailableItems) {
            actionOnDestroy.Invoke(item);
        }

        unavailableItems.Clear();
    }
}
