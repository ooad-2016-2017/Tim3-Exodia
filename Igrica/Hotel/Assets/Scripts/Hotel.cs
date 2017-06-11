using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class Hotel : MonoBehaviour {
    
    private GameObject[] hotel;
    public Text scoreText;
    private const float BOUNDS_SIZE = 2.5f;
    private const float POMJERANJE = 5.0f;
    private const float GRESKA = 0.05f;
    private const float VELICINA = 1f;
    public GameObject gameOverPanel;

    private int index;
    private int disolver = 0;
    private int score = 0;
    private float pomjeranje = 0.0f;
    private float brzina = 1.0f;
    private bool desno = true;
    private bool gameOver = false;

    private float pocetnaPozicija;

    private Vector3 pozicija;

    private Vector3 posljednjaPozicija;


	void Start () {
        hotel = new GameObject[transform.childCount];
        GORepository go = new GORepository(ref hotel);
        for(Iterator iter = go.getIterator(); iter.hasNext();)
        {
            GameObject o = (GameObject)iter.next();
            o = transform.GetChild(disolver).gameObject;
            hotel[disolver] = o;
            disolver++;
        }

        index = transform.childCount - 1;
	}
	
	void Update () {
        if (gameOver)
            return;

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
                score++;
                //gratis ako je fino postavljena kocka
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
                score++;
                //gratis ako je fino postavljena kocka
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
        brzina += 0.1f;
        if (brzina > 1.5 && brzina < 1.7)
            brzina += 1;
        if (brzina > 4.9 && brzina < 5.1)
            brzina += 3;
        return true;
    }

    private void Kraj()
    {
        if (PlayerPrefs.GetInt("score") < score)
            PlayerPrefs.SetInt("score", score);
        gameOver = true;
        gameOverPanel.SetActive(true);
        hotel[index].AddComponent<Rigidbody>();
    }

    public void OnButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

