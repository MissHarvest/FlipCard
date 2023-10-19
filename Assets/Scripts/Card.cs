using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touched()
    {
        Debug.Log("TTT");
        anim.SetBool("isOpen", true);
        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);

        if(null == GameManager.Instance.firstCard)
        {
            GameManager.Instance.firstCard = this.gameObject;
        }
        else
        {
            GameManager.Instance.secondCard = this.gameObject;
            GameManager.Instance.IsMatch();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void Close()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("Front").gameObject.SetActive(false);
        transform.Find("Back").gameObject.SetActive(true);
    }
}
