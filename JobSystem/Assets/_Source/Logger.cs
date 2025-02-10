using System.Collections;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace _Source
{
    public class Logger : MonoBehaviour
    {
        [SerializeField] private float logInterval;

        public void Init()
        {
            StartCoroutine(LogCalculationCoroutine());
        }

        IEnumerator LogCalculationCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(logInterval);

                NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);
                float randomValue = Random.Range(1f, 100f);

                CalculateLogJob logJob = new CalculateLogJob
                {
                    RandomValue = randomValue,
                    Result = result
                };

                JobHandle logHandle = logJob.Schedule();
                logHandle.Complete();

                Debug.Log($"Object {gameObject.name} Log({randomValue}) = {result[0]}");

                result.Dispose();
            }
        }

        private struct CalculateLogJob : IJob
        {
            public float RandomValue { set => _randomValue = value; }
            public NativeArray<float> Result { set => _result = value; }
            
            private float _randomValue;
            private NativeArray<float> _result;

            public void Execute()
            {
                _result[0] = Mathf.Log(_randomValue);
            }
        }
    }
}