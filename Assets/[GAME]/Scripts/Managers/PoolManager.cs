using System;
using System.Collections.Generic;
using System.Linq;
using Engine;
using UnityEngine;

namespace Scripts.Managers
{
    public class PoolManager : Singleton<PoolManager>
    {
        public List<PoolObjectInfo> PoolObjectInfos;
        
        private readonly Dictionary<TypeObject, GameObject> poolObjects = new Dictionary<TypeObject, GameObject>();
        private readonly Dictionary<TypeObject, HashSet<GameObject>> activePoolObjects = new Dictionary<TypeObject, HashSet<GameObject>>();
        private readonly Dictionary<TypeObject, Queue<GameObject>> notActivePoolObjects = new Dictionary<TypeObject, Queue<GameObject>>();
        private Transform parentPoolObjects;
        
        private void Start()
        {
            parentPoolObjects = (GameObject.Find("[POOL]") ?? new GameObject("[POOL]")).transform;
            foreach (var poolObjectInfo in PoolObjectInfos)
            {
                poolObjects.Add(poolObjectInfo.TypeObject, poolObjectInfo.PoolObject);
                var notActivePool = GeneratePool(poolObjectInfo);
                notActivePoolObjects.Add(poolObjectInfo.TypeObject, new Queue<GameObject>(notActivePool));
                activePoolObjects.Add(poolObjectInfo.TypeObject, new HashSet<GameObject>());
            }
        }

        private IEnumerable<GameObject> GeneratePool(PoolObjectInfo poolObjectInfo)
        {
            return Enumerable
                .Range(0, poolObjectInfo.CountCreateOnStart)
                .Select(e =>
                {
                    var o = Instantiate(poolObjectInfo.PoolObject, parentPoolObjects);
                    o.SetActive(false);
                    return o;
                });
        }

        public GameObject InstantiatePoolObject(TypeObject typeObject)
        {
            var pool = notActivePoolObjects[typeObject];
            var poolObject = pool.Count > 0 ? pool.Dequeue() : Instantiate(poolObjects[typeObject], parentPoolObjects);
            activePoolObjects[typeObject].Add(poolObject);
            poolObject.SetActive(true);
            return poolObject;
        }

        public void DestroyPoolObject(TypeObject typeObject, GameObject poolObject)
        {
            var activePool = activePoolObjects[typeObject];
            if (!activePool.Contains(poolObject))
            {
                Debug.LogError($"{poolObject} is not pool object");
                return;
            }

            activePool.Remove(poolObject);
            notActivePoolObjects[typeObject].Enqueue(poolObject);
            poolObject.SetActive(false);
        }

        public enum TypeObject
        {
            PlayerBullet,
            Bullet,
            BigBullet,
            Explosion
        }

        [Serializable]
        public class PoolObjectInfo
        {
            public TypeObject TypeObject;
            public GameObject PoolObject;
            public int CountCreateOnStart;
        }
    }
}