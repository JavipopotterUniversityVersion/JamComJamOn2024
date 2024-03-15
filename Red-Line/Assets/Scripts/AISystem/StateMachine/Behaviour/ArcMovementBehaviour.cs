using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMovementBehaviour : MonoBehaviour, IBehaviour
{
    TargetHandler targetHandler;
    [SerializeField] AnimationCurve curve;

    [SerializeField]
    float duration = 1f;

    [SerializeField]
    float height = 1f;

    [SerializeField] Vector2 rangeX;
    [SerializeField] Vector2 rangeY;

    private void Awake() {
        targetHandler = GetComponentInParent<TargetHandler>();
    }

    public void ExecuteBehaviour()
    {
        Vector2 start = targetHandler.transform.position;
        Vector2 end = new Vector2(Random.Range(rangeX.x, rangeX.y), Random.Range(rangeY.x, rangeY.y)) + (Vector2)targetHandler.transform.position;

        StartCoroutine(Curve(start, end));
    }

    IEnumerator Curve(Vector2 start, Vector2 end)
    {
        float timePassed = 0;

        while (timePassed < duration)
        {
            float t = timePassed / duration;
            Vector2 position = Vector2.Lerp(start, end, t);
            position.y += curve.Evaluate(t) * height;

            targetHandler.transform.position = position;

            timePassed += Time.deltaTime;
            yield return null;
        }
    }

    private void OnValidate() {
        // name = $"ArcMovementBehaviour {duration}s";
    }
}