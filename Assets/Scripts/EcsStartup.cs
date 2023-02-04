using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Clicker {
    sealed class EcsStartup : MonoBehaviour
    {

        private Player _player;
        EcsWorld _world;        
        IEcsSystems _systems;

        void Start ()
        {
            _player = FindObjectOfType<Player>();
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems.Add(new ClickedSystem());
            _systems

#if UNITY_EDITOR
                //.Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Inject()
                .Inject(_player)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
            }

            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}