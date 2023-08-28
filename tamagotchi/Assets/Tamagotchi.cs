using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Tamagotchi : MonoBehaviour
{
    public int Felicidade = 100;
    public TextMeshProUGUI felicidadeText;
    public int Fome = 0;
    public TextMeshProUGUI fomeText;
    public int Sujeira = 0;
    public TextMeshProUGUI sujeiraText;
    public bool isDead;
    public GameObject buttons;
    public GameObject playAgain;
    public float timer = 5;
    public AudioSource audio;
    public GameObject image;
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
         Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            TimerCallback();
            timer += 4;

        }

        felicidadeText.text = Felicidade.ToString();
        fomeText.text = Fome.ToString();
        sujeiraText.text = Sujeira.ToString();

        if(Fome >= 100 || Sujeira >= 100 || Felicidade <=0)
        {
            Died();
        }

    }

    private void TimerCallback()
    {
        Felicidade -= 10;
        Fome += 10;
        Sujeira +=10;
    }

    public void Alimentar()
    {
        if(Fome <= 100 && Fome >=10)
        {
            Fome -= 10;
            audio.Play();
        }
        
    }

    public void DarBanho()
    {
        if(Sujeira <= 100 && Sujeira >=10)
        {
            Sujeira -=10;
            audio.Play();
        }
    }

    public void DarCarinho()
    {
        if(Felicidade < 100)
        {
            Felicidade += 10;
            audio.Play();
        }
    }

    public void Died()
    {
            isDead = true;
            buttons.SetActive(false);
            playAgain.SetActive(true);
            image.SetActive(true);
            icon.SetActive(false);


           Time.timeScale = 0;
                         
        
    }

    public void LoadScene(string Scene)
    {
        
        SceneManager.LoadScene(Scene);
          Debug.Log("Recomeçou");
  }
    public void Quit()
    {
        Application.Quit();
    }

}
