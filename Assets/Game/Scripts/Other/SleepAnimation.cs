using System.Collections;
using UnityEngine;

public class SleepAnimation : MonoBehaviour
{
    public Transform playerTransform;
    
    public Transform lyingPosition;
    public Transform sittingPosition;
    public Transform standingPosition;

    private float sitDuration = 0.7f;
    private float standDuration = 0.8f;

    private bool isAnimating = false;
    public IEnumerator Wakeup()
    {
        if (isAnimating)
        {
            yield break;
        }
        isAnimating = true;

        G.player.SetMovementEnabled(false);

        playerTransform.position = lyingPosition.position;
        playerTransform.rotation = lyingPosition.rotation;

        standingPosition.rotation = Quaternion.Euler(0f, 0f, 0f);

        yield return new WaitForSeconds(1f);
        yield return MoveCamera(lyingPosition, sittingPosition, 1.5f);
        yield return new WaitForSeconds(1f);
        yield return MoveCamera(sittingPosition, standingPosition, 1.5f);

        G.player.ResetCamera(1f);

        G.player.SetMovementEnabled(true);

        isAnimating = false;
    }
    public IEnumerator GoToSleep()
    {
        if (isAnimating)
        {
            yield break;
        }
        isAnimating = true;

        G.player.SetMovementEnabled(false);

        standingPosition.position = playerTransform.position;
        standingPosition.rotation = playerTransform.rotation;

        yield return MoveCamera(standingPosition, sittingPosition, 1.5f);
        yield return new WaitForSeconds(1f);
        yield return MoveCamera(sittingPosition, lyingPosition, 1.5f);
        yield return new WaitForSeconds(1f);

        isAnimating = false;
    }

    private IEnumerator MoveCamera(Transform from, Transform to, float duration)
    {
        float time = 0f;
        
        Vector3 startPosition = from.position;
        Quaternion startRotation = from.rotation;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = Mathf.Clamp01(time / duration);

            t = Mathf.SmoothStep(0f, 1f, t);

            playerTransform.position = Vector3.Lerp(startPosition, to.position, t);
            playerTransform.rotation = Quaternion.Slerp(startRotation, to.rotation, t);

            G.player.cameraTransform.rotation = Quaternion.Slerp(startRotation, to.rotation, t);

            yield return null;
        }

        playerTransform.position = to.position;
        playerTransform.rotation = to.rotation;
    }
}
