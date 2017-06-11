using Helpers;
using UnityEngine;

[HelpURL("https://docs.unity3d.com/ScriptReference/DisallowMultipleComponent.html")]

[RequireComponent(typeof(Rigidbody))]

[DisallowMultipleComponent]

[AddComponentMenu("Useful Scripts/Box Pusher")]
public class startForce : MonoBehaviour {

    [Range(0, 1000)]
    public int force;

    public Direction direction;

    Vector3 _direction = Vector3.up;

    void OnValidate() {
        switch(direction) {
            case Direction.up:
                _direction = Vector3.up;
                break;
            case Direction.down:
                _direction = Vector3.down;
                break;
            case Direction.left:
                _direction = Vector3.left;
                break;
            case Direction.right:
                _direction = Vector3.right;
                break;
            case Direction.forward:
                _direction = Vector3.forward;
                break;
            case Direction.back:
                _direction = Vector3.back;
                break;
        }
    }

    void Start() {
        GetComponent<Rigidbody>().AddForce(_direction * force);
    }

}
