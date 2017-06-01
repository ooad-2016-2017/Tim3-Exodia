using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hotel : MonoBehaviour {
    
    private GameObject[] hotel;
    public Text scoreText;
    private const float BOUNDS_SIZE = 2.5f;
    private const float POMJERANJE = 5.0f;
    private const float GRESKA = 0.1f;
    private const float VELICINA = 1f;
    private int combo = 0;
    public GameObject endPanel;

    private int index;
    private int score = 0;
    private float pomjeranje = 0.0f;
    private float brzina = 2.5f;
    private bool desno = true;
    private bool gameOver = false;

    private float pocetnaPozicija;

    private Vector3 pozicija;

    private Vector3 posljednjaPozicija;


	void Start () {
        hotel = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            hotel[i] = transform.GetChild(i).gameObject;

        index = transform.childCount - 1;
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if(PostaviSprat())
            {
                NapraviSprat();
                score++;
                scoreText.text = score.ToString();
            }
            else
            {
                Kraj();
            }
        }

        PomjeriSprat();

        //pomjeri hotel cijeli
        transform.position = Vector3.Lerp(transform.position, pozicija, POMJERANJE * Time.deltaTime);
	}

    private void PomjeriSprat()
    {
        if (gameOver)
            return;
        pomjeranje += Time.deltaTime * brzina;
        if(desno) 
            hotel[index].transform.localPosition = new Vector3(Mathf.Sin(pomjeranje) * BOUNDS_SIZE, score, pocetnaPozicija);
        else
            hotel[index].transform.localPosition = new Vector3(pocetnaPozicija, score, Mathf.Sin(pomjeranje) * BOUNDS_SIZE);
    }

    private void NapraviSprat()
    {
        posljednjaPozicija = hotel[index].transform.localPosition;
        index--;
        if (index < 0)
            index = transform.childCount - 1;

        pozicija = (Vector3.down) * score;
        hotel[index].transform.localPosition = new Vector3(0, score, 0);
    }

    private bool PostaviSprat()
    {
        Transform t = hotel[index].transform;

        if(desno)
        {
            float deltaX = posljednjaPozicija.x - t.position.x;
            if(Mathf.Abs(deltaX) <= GRESKA)
            {
                combo++;
                //perfect
            }
            else
            {
                if (Mathf.Abs(deltaX) > VELICINA)
                    return false;
            }
        }
        else
        {
            float deltaZ = posljednjaPozicija.z - t.position.z;
            if (Mathf.Abs(deltaZ) <= GRESKA)
            {
                combo++;
                //perfect
            }
            else
            {
                if (Mathf.Abs(deltaZ) > VELICINA)
                    return false;
            }
        }

        if (desno)
            pocetnaPozicija = t.localPosition.x;
        else
            pocetnaPozicija = t.localPosition.z;
        desno = !desno;
        return true;
    }

    private void Kraj()
    {
        Debug.Log("NEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        gameOver = true;
        endPanel.SetActive(true);
        hotel[index].AddComponent<Rigidbody>();
    }

    public void OnButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

