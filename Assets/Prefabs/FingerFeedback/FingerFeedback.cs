using UnityEngine;
using UnityEngine.Serialization;

public class FingerFeedback : MonoBehaviour
{
    public GameObject startFingerGO;
    public GameObject endFingerGO;
    public GameObject wrongInput;
    LineRenderer feedbackLine;

    SpriteRenderer startFingerGOSprite;
    SpriteRenderer endFingerGOSprite;

    public Color ableToShoot = Color.green;
    public Color unableToShoot = Color.red;

    float threshold;

    // Start is called before the first frame update
    void Start()
    {
        startFingerGOSprite = startFingerGO.GetComponent<SpriteRenderer>();
        endFingerGOSprite = endFingerGO.GetComponent<SpriteRenderer>();
        feedbackLine = GetComponent<LineRenderer>();

        
        startFingerGO.SetActive(false);
        endFingerGO.SetActive(false);
        feedbackLine.enabled = false;

        SetColor(unableToShoot);
    }

    public void StartDrag(Vector3 position)
    {
        startFingerGO.SetActive(true);
        startFingerGO.transform.position = position;
        feedbackLine.enabled = true;
        feedbackLine.SetPosition(0, startFingerGO.transform.position);
        feedbackLine.SetPosition(1,startFingerGO.transform.position);
    }

    public void Dragging(Vector3 position)
    {
        endFingerGO.SetActive(true);
        endFingerGO.transform.position = position;
        feedbackLine.SetPosition(1, endFingerGO.transform.position);

        SetColor(Vector2.Distance(endFingerGO.transform.position, startFingerGO.transform.position) <= threshold
            ? unableToShoot
            : ableToShoot);
    }

    public void EndDrag()
    {
        startFingerGO.SetActive(false);
        endFingerGO.SetActive(false);
        feedbackLine.enabled = false;
        SetColor(unableToShoot);
    }

    public void SetThreshold(float thresholdValue)
    {
        threshold = thresholdValue;
    }

    void SetColor(Color currentColor)
    {
        startFingerGOSprite.material.color = currentColor;
        endFingerGOSprite.material.color = currentColor;
        feedbackLine.material.color = currentColor;
    }

    public void ToggleWrongInput(bool toggle)
    {
        wrongInput.SetActive(toggle);
    }
}
