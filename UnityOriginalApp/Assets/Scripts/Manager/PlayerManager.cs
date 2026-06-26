using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static PlayerManager instance;

    [HideInInspector]
    public Transform editNameLayout;
    public int totalPlayers;
    [HideInInspector]
    public ParticleSystem clickPartical;
    #endregion

    #region PRIVATE_VARS

    private Button TheButton;
    float timer;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        TheButton = GetComponent<Button>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9.23f);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (timer >= 1)
            {
                ParticleSystem go = Instantiate(clickPartical);
                go.transform.position = mousePosition;
                Destroy(go.gameObject, 1);
                timer = 0;
            }
        }
    }

    public void WhenClicked()
    {
        TheButton.interactable = false;
        StartCoroutine(EnableButtonAfterDelay(TheButton, 1));
    }

    IEnumerator EnableButtonAfterDelay(Button button, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        button.interactable = true;
    }

}

