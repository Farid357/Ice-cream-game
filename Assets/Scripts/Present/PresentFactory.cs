using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class PresentFactory : Factory<Present>
    {
        [SerializeField] private Transform _spawnPoint;
        private readonly Timer _timer = new(30f);

        private void Start() => _timer.Start();

        protected override Vector3 GetNextPoint() => _spawnPoint.position;

        protected override Present GetPrefab()
        {
            List<float> chances = new();
            for (int i = 0; i < Prefabs.Length; i++)
            {
                chances.Add(Prefabs[i].ChanceCurve.Evaluate(_timer.PassedTime));
            }

            float chance = Random.Range(0, chances.Sum());
            float value = 0;

            for (int i = 0; i < chances.Count; i++)
            {
                value += chances[i];
                if (chance < value)
                {
                    return Prefabs[i];
                }
            }
            return Prefabs[Prefabs.Length - 1];
        }
    }
}
