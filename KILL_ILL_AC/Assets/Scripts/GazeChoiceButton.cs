using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GazeChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image progressFill;
    [SerializeField] private float dwellTime = 1.5f;

    private Button button;
    private bool isGazedAt;
    private float timer;
    private bool fired;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (progressFill != null)
            progressFill.fillAmount = 0f;
    }

    private void Update()
    {
        if (!isGazedAt || fired)
            return;

        timer += Time.deltaTime;

        if (progressFill != null)
            progressFill.fillAmount = timer / dwellTime;

        if (timer >= dwellTime)
        {
            fired = true;
            button.onClick.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isGazedAt = true;
        timer = 0f;
        fired = false;

        if (progressFill != null)
            progressFill.fillAmount = 0f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetProgress();
    }

    public void ResetProgress()
    {
        isGazedAt = false;
        timer = 0f;
        fired = false;

        if (progressFill != null)
            progressFill.fillAmount = 0f;
    }
}