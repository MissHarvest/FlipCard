using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public AudioClip flipSound;
    
    AudioSource audioSource;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touched()
    {
        audioSource.PlayOneShot(flipSound);

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
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void Close()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("Front").gameObject.SetActive(false);
        transform.Find("Back").gameObject.SetActive(true);
    }
}
