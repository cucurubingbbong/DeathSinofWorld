using System;
using System.Collections.Generic;

public class EventBus
{
    private readonly Dictionary<Type, Delegate> eventDictionary = new();

    public void SubScribe<T>(Action<T> listener)
    {
        Type type = typeof(T);

        if (eventDictionary.TryGetValue(type, out var existing))
        {
            eventDictionary[type] = Delegate.Combine(existing, listener);
        }
        else
        {
            eventDictionary[type] = listener;
        }
    }

    public void UnsubScribe<T>(Action<T> listener)
    {
        Type type = typeof(T);

        if (eventDictionary.TryGetValue(type, out var existing))
        {
            var newDelegate = Delegate.Remove(existing, listener);

            if (newDelegate == null)
            {
                eventDictionary.Remove(type);
            }
            else
            {
                eventDictionary[type] = newDelegate;
            }
        }
    }

    public void Publish<T>(T eventData)
    {
        Type type = typeof(T);

        if (eventDictionary.TryGetValue(type, out var existing))
        {
            if (existing is Action<T> callback)
            {
                callback.Invoke(eventData);
            }
        }
    }

    public void Clear()
    {
        eventDictionary.Clear();
    }
}