using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;


namespace Clicker
{
    public class ClickedSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsCustomInject<Player> _player = default;
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<PlayerClicked> _playerClicked = default;
        private readonly EcsFilterInject<Inc<PlayerClicked, PlayerComponent>> _filter = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var player = ref _filter.Pools.Inc2.Get(entity);
                
                //Do Some Logic
                Debug.Log($"{player.Transform} {player.Transform.name}");
                _playerClicked.Value.Del(entity);
            }
        }

        public void Init(IEcsSystems systems)
        {
            var entity = _world.Value.NewEntity();
            ref var playerComponent = ref _world.Value.GetPool<PlayerComponent>().Add(entity);
            playerComponent.Transform = _player.Value.transform;
            _player.Value.Init(_world.Value, entity);
        }
    }
}