using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isHitClue;
    private Vector2 movement;
    private CluesCollectible _cluesCollectible;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (isHitClue)
        {
            _cluesCollectible.UItext.gameObject.SetActive(true);
            _cluesCollectible.TextPopUp();
        }
        else
        {
            _cluesCollectible.UItext.gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, -Vector2.down);
        
        
        if (hit2D.Length >= 2) 
        {
            _cluesCollectible = hit2D[1].transform.GetComponent<CluesCollectible>();
            if (_cluesCollectible != null)
            {
                isHitClue = true;
                Debug.Log("I am a clue"); 
            }
            else
            {
                _cluesCollectible = null;
                isHitClue = false;
            }
            // _cluesCollectible.UItext.gameObject.SetActive(true);
            // _cluesCollectible.TextPopUp();
        } 
        else
        {
            isHitClue = false;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}