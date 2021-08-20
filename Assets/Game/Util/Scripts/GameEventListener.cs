using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.SpacePirates.Util
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField]
        private GameEvent gameEvent;
        [SerializeField]
        private UnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}

