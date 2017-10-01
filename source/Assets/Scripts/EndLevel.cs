using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour {

    public GameObject endLevelUI;

    public Text textUI;

    public string[] text;

    private bool collided; // controle da colisão no bloco

    private int currentText;

    void Start()
    {
        collided = false;
        currentText = 0;
        textUI.text = "";
    }

    void Update()
    {

        if (collided)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Next();
            }

        }

    }

    void Next()
    {
        if (currentText < text.Length)
        {
            textUI.text = text[currentText++];
        }
        else
        {
            textUI.text = "Carregando  . . .";
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            collided = true;
            endLevelUI.SetActive(true);
            Next ();
        }
    }
}
