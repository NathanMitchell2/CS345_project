using UnityEngine;
using TMPro;
using System.Collections;

public class TMPObjectMovement : MonoBehaviour
{
    public TMP_Text tmpText; // Reference to the TMP_Text object to move

    private RectTransform rectTransform;
    private Vector3 originalPosition;

    // Movement parameters
    public float moveDownSpeed = 100f;
    public float moveUpSpeed = 50f;
    public float moveDownDistance = 230f; // (180 - (-50)) distance to move down
    public float moveUpDistance = 230f;   // Same distance to move up

    private bool movingDown = false;
    private bool movingUp = false;

    private void Start()
    {
        rectTransform = tmpText.GetComponent<RectTransform>();
        originalPosition = rectTransform.localPosition;
    }

    public void MoveDownAndUp()
    {
        Debug.Log("Preparing to move");
        if (!movingDown && !movingUp)
        {
            Debug.Log("Moving");
            StartCoroutine(MoveDownCoroutine());
        }
    }

    IEnumerator MoveDownCoroutine()
    {
        movingDown = true;
        float startY = rectTransform.localPosition.y;
        float endY = startY - moveDownDistance;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * (moveDownSpeed / moveDownDistance);
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, Mathf.Lerp(startY, endY, t), rectTransform.localPosition.z);
            yield return null;
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        StartCoroutine(MoveUpCoroutine());
    }

    IEnumerator MoveUpCoroutine()
    {
        movingDown = false;
        movingUp = true;
        float startY = rectTransform.localPosition.y;
        float endY = originalPosition.y;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * (moveUpSpeed / moveUpDistance);
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, Mathf.Lerp(startY, endY, t), rectTransform.localPosition.z);
            yield return null;
        }

        movingUp = false;
    }
}
