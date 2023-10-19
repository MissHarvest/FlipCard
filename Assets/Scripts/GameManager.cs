using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor.Search;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject prefab_Card;

    public GameObject firstCard;
    public GameObject secondCard;


    public Text TimeText;
    public Text EndText;

    float time;

    private void Awake()
    {
        if(null == Instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        SpawnCards();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimeText.text = string.Format("{0:#0.00}", time);
        if(time >= 30.0f)
        {
            GameEnd();
        }
    }

    void SpawnCards()
    {
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
        
        for(int i = 0; i < rtans.Length; ++i)
        {
            float x = (i % 4) * 1.4f;
            float y = (i / 4) * 1.4f;

            var newCard = Instantiate(prefab_Card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            newCard.transform.localPosition = new Vector3(x, y, 1);

            string name = "rtan" + rtans[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(name);
        }
    }

    public void IsMatch()
    {
        if(firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name == secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name)
        {
            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            int cardLeft = GameObject.Find("Cards").transform.childCount;
            if(2 == cardLeft)
            {
                GameEnd();
            }
        }
        else
        {
            firstCard.GetComponent<Card>().Close();
            firstCard = null;

            secondCard.GetComponent<Card>().Close();
            secondCard = null;
        }
    }

    void GameEnd()
    {
        EndText.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
