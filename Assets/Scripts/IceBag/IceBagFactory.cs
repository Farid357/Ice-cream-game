﻿using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class IceBagFactory : Factory<IceBagMovement>
    {
        [SerializeField] private Transform[] _spawnPoints;

        public override Vector3 GetNextPoint()
        {
            var randomIndex = Random.Range(0, _spawnPoints.Length);
            var randomPoint = _spawnPoints[randomIndex];
            return randomPoint.position;
        }
    }
}