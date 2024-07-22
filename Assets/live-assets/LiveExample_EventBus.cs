using System;
using System.Collections.Generic;
using UnityEngine;

namespace LiveExamples
{
    class FireEvent { }


    class CollisionEvent
    {
        public GameObject collided;


        public CollisionEvent(GameObject collided)
        {
            this.collided = collided;
        }
    }



    class EventBus
    {
        public static readonly EventBus Instance = new();


        EventBus() { }


        Dictionary<Type, List<Action<object>>> _subs = new();


        public void Subscribe<T>(Action<T> subscriber)
        {
            var type = typeof(T);

            if (!_subs.TryGetValue(typeof(T), out var subs))
            {
                subs = new List<Action<object>>();
                _subs[type] = subs;
            }

            subs.Add((o) => subscriber((T)o));
        }

        public void Fire<T>(T ev)
        {
            if (_subs.TryGetValue(typeof(T), out var subs))
            {
                foreach (var sub in subs)
                {
                    sub(ev);
                }
            }
        }
    }



    class EventBusExample
    {

        public void Do()
        {

            var evBus = EventBus.Instance;
            evBus.Subscribe<FireEvent>(OnFire);
            evBus.Subscribe<CollisionEvent>(OnCollision);



            // Somewhere else:


            EventBus.Instance.Fire(new FireEvent());


            GameObject colided = null; // find the collider object
            EventBus.Instance.Fire(new CollisionEvent(colided));

        }


        void OnFire(FireEvent ev)
        {

        }


        void OnCollision(CollisionEvent ev)
        {

        }

    }



}