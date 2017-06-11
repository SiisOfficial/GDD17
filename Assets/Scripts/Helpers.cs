using UnityEngine;
using System;

/// <summary>
/// https://docs.unity3d.com/ScriptReference/Serializable.html
/// </summary>
namespace Helpers {

    [Serializable]
    public struct MinMax {
        [SerializeField]
        float rangeStart;
        [SerializeField]
        float rangeEnd;

        public float GetRandomValue() {
            return UnityEngine.Random.Range(rangeStart, rangeEnd);
        }
    }

    [Serializable]
    public struct MinMaxRange {
        [SerializeField]
        [Range(-10, 0)]
        float rangeStart;
        [SerializeField]
        [Range(0, 10)]
        float rangeEnd;

        public float GetRandomValue() {
            return UnityEngine.Random.Range(rangeStart, rangeEnd);
        }
    }

    public enum Direction {
        up,
        down,
        left,
        right,
        forward,
        back
    }

    public struct Movable {
        public Transform transform;
        public Vector3 scaleFrom;
        [HideInInspector]
        public Vector3 initScale;
        public Vector3 positionFrom;
        [HideInInspector]
        public Vector3 initPosition;
        public Vector3 rotationFrom;
        [HideInInspector]
        public Quaternion initRotation;
        public AnimationCurve transition;
        [Range(0, 10)]
        public float delay;
        [Range(0, 2)]
        public float targetTime;

    }
}
