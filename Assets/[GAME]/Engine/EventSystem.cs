using System;
using System.Collections.Generic;
using UnityEngine;
using Event = Engine.Events.Event;

namespace Engine
{
    public class EventSystem : Singleton<EventSystem>
    {
        private readonly Dictionary<Type, List<object>> colleagues =
            new Dictionary<Type, List<object>>();

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : Event
        {
            var eventType = typeof(TEvent);
            if (colleagues.ContainsKey(eventType))
                colleagues[eventType].Add(handler);
            else
                colleagues.Add(eventType, new List<object> {handler});
        }

        public void UnsubscribeAll<TEvent>()
            where TEvent : Event
        {
            var eventType = typeof(TEvent);
            if (colleagues.ContainsKey(eventType))
                colleagues.Remove(eventType);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> eventObj)
            where TEvent : Event
        {
            var eventType = typeof(TEvent);
            if (colleagues.ContainsKey(eventType))
                colleagues[eventType].Remove(eventObj);
        }

        public void Notify<TEvent>(TEvent eventObj) where TEvent : Event
        {
            var eventType = typeof(TEvent);
            Debug.Log($"{eventType.Name} happens.");
            if (colleagues.TryGetValue(eventType, out var actions))
            {
                foreach (var action in actions)
                {
                    if (!(action is Action<TEvent> handler))
                    {
                        Debug.LogError($"One of {eventType.Name} handlers is null.");
                        continue;
                    }

                    try
                    {
                        handler.Invoke(eventObj);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
            else
            {
                Debug.LogWarning($"Nothing subscribed on {eventType.Name}.");
            }
        }

        private void OnDestroy()
        {
            colleagues.Clear();
        }
    }
}