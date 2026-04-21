using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class GazeClicker : MonoBehaviour
{
    public float dwellTime = 1.5f;

    private float timer = 0f;
    private Button currentButton;

    void Update()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = new Vector2(Screen.width / 2, Screen.height / 2);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        Button foundButton = null;

        foreach (var result in results)
        {
            foundButton = result.gameObject.GetComponent<Button>();
            if (foundButton != null) break;
        }

        if (foundButton != currentButton)
        {
            currentButton = foundButton;
            timer = 0f;
        }

        if (currentButton != null)
        {
            timer += Time.deltaTime;

            if (timer >= dwellTime)
            {
                currentButton.onClick.Invoke();
                timer = 0f;
            }
        }
    }
}