using Leopotam.EcsLite;
using UnityEngine;


namespace Clicker
{
    public class Player : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private int _entityID;
        
        /// <summary>
        /// Init player before start
        /// </summary>
        /// <param name="ecsWorld"> ecs world</param>
        /// <param name="entity"> player's entity</param>
        public void Init(EcsWorld ecsWorld , int entity)
        {
            _ecsWorld = ecsWorld;
            _entityID = entity;
        }
        
        private void OnMouseDown()
        {
            if (_ecsWorld == null) return;
            
            var pool = _ecsWorld.GetPool<PlayerClicked>();
            if (!pool.Has(_entityID))
            {
                pool.Add(_entityID);
            }
        }
    }
}
