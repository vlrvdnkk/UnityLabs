using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace _Source
{
    public class Mover : MonoBehaviour
    {
        private TransformAccessArray _transformArray;
        private NativeArray<float> _speeds;
        private float _radius;
        private JobHandle _moveJobHandle;

        void Awake()
        {
            _transformArray = new TransformAccessArray(1);
        }
        
        public void Init(float speed, float radius)
        {
            _radius = radius;
            _speeds = new NativeArray<float>(1, Allocator.Persistent);
            _speeds[0] = speed;

            _transformArray.Add(transform);
        }

        void Update()
        {
            MoveJob moveJob = new MoveJob
            {
                DeltaTime = Time.deltaTime,
                Speeds = _speeds,
                Radius = _radius
            };

            _moveJobHandle = moveJob.Schedule(_transformArray);
        }

        void LateUpdate()
        {
            _moveJobHandle.Complete();
        }

        void OnDestroy()
        {
            _moveJobHandle.Complete();
            if (_transformArray.isCreated)
                _transformArray.Dispose();
            if (_speeds.IsCreated)
                _speeds.Dispose();
        }

        private struct MoveJob : IJobParallelForTransform
        {
            public float DeltaTime { set => _deltaTime = value; }
            public float Radius { set => _radius = value; }
            public NativeArray<float> Speeds { set => _speeds = value; }
            
            private float _deltaTime;
            private float _radius;
            private NativeArray<float> _speeds;

            public void Execute(int index, TransformAccess transform)
            {
                float angle = Mathf.Atan2(transform.position.z, transform.position.x) + _speeds[index] * _deltaTime;
                transform.position = new Vector3(Mathf.Cos(angle) * _radius, 0, Mathf.Sin(angle) * _radius);
            }
        }
    }
}