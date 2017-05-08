using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

using S = System;

[HelpURL("https://docs.unity3d.com/ScriptReference/HelpURLAttribute.html")]

[AddComponentMenu("Kolaylıklar/Genel Kolaylıklar")]
public class generalAttributes : MonoBehaviour {

    [S.NonSerializedAttribute]
    public bool isActive = false;

    [HideInInspector]
    public bool isSpecial = false;

    [Header("Çok Kullanışlı Değişkenler")]
    [Space(8)]

    [TooltipAttribute("Küp nerede yaratılsın?")]
    [SerializeField]
    Vector3 cubePosition = Vector3.one;
    [TooltipAttribute("Küpün büyüklüğü ne olsun?")]
    [SerializeField]
    [Range(0, 3)]
    float cubeScale = 1f;

    [Header("Bunlar da Kullanışlı Değişkenler")]
    [Space(8)]

    [SerializeField]
    AnimationCurve transition = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    [Range(0, 5)]
    [SerializeField]
    float transitionTime = 1f;
    [TooltipAttribute("Küp nereye gitsin?")]
    [SerializeField]
    Vector3 cubeTargetPosition = Vector3.one * 2f;

    [Header("Bu Daha Az Kullanışlı Bir Değişken")]
    [Space(8)]

    public bool useGradient = true;

    [Header("Off! Bu Nasıl Bir Kullanışlılık Böyle? Resmen Hayatım Kolaylaştı")]
    [Space(8)]

    [SerializeField]
    Gradient gradientColor;
    [ContextMenuItem("Renk Üret", "GenerateColor")]
    [SerializeField]
    Color color;

    [Space(12)]

    [SerializeField]
    [MultilineAttribute(4)]
    string iHaveTooManyThingsToWrite;

    [SerializeField]
    [TextAreaAttribute]
    string butIAmMuchMoreUsable;

    [Space(12)]

    [SerializeField]
    UnityEvent OnClick;

    [ContextMenu("Translate My GameObject")]
    void TranslateMyGameObject() {
        if(EditorApplication.isPlaying) {
            Debug.Log("Hello Translate My GameObject");
            StartCoroutine(translateGameObject());
        }
    }

    void OnValidate() {
        if(useGradient) {
            GetComponent<Renderer>().sharedMaterial.color = gradientColor.Evaluate(Random.Range(0f, 1f));
        } else {
            GetComponent<Renderer>().sharedMaterial.color = color;
        }
    }

    void Start() {
        transform.position = cubePosition;
        transform.localScale = transform.localScale * cubeScale;
    }

    void GenerateColor() {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        OnValidate();
    }

    IEnumerator translateGameObject() {
        float passedTime = 0f;

        while(passedTime < transitionTime) {
            passedTime += Time.deltaTime;
            float lerpValue = transition.Evaluate(passedTime / transitionTime);

            transform.position = Vector3.LerpUnclamped(cubePosition, cubeTargetPosition, lerpValue);

            yield return null;
        }

    }

    void OnMouseDown() {
        OnClick.Invoke();
    }
}
