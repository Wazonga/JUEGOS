using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//inserta un rigdbody al ojbejto 
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;

    private Rigidbody2D mRB;
    private Vector3 mDirection = Vector3.zero;
    private Animator mAnimator;

    private PlayerInput mPlayerInput;

    private Transform hitBox;


    private void Start()
    {
        mRB = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mPlayerInput = GetComponent<PlayerInput>();

        hitBox = transform.Find("HitBox");

        ConvoManager.Instance.OnConvoStop += OnConvoStopDelegate;
    }

    private void OnConvoStopDelegate()
    {
        mPlayerInput.SwitchCurrentActionMap("Player");
    }


    private void Update()
    {

        if(mDirection != Vector3.zero)
        {
            mAnimator.SetBool("IsMoving",true);
            mAnimator.SetFloat("Horizontal", mDirection.x);
            mAnimator.SetFloat("Vertical", mDirection.y);
        }
        else
        {
            //quieto
            mAnimator.SetBool("IsMoving",false);
        }

    }

    private void FixedUpdate()
    {
        mRB.MovePosition(
           transform.position + (mDirection * speed * Time.fixedDeltaTime)
           );
    }

    
    public void OnMove(InputValue value)
    {
        mDirection = value.Get<Vector2>().normalized;
       
    }

    public void OnNext (InputValue Value){
        if(Value.isPressed){
            ConvoManager.Instance.NextConvo();
        }
    }

      public void OnCancel (InputValue Value){
        if(Value.isPressed){
            ConvoManager.Instance.StopConvo();
        }
    }

    public void OnAttack(InputValue Value){
        if(Value.isPressed){
            mAnimator.SetTrigger("Attack");
            hitBox.gameObject.SetActive(true);
        }
    }

     public void OnSpin(InputValue Value){
        if(Value.isPressed){
            mAnimator.SetTrigger("Spin");
            hitBox.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        Convo conversation;
        if(other.transform.TryGetComponent<Convo>(out conversation))
        {
            mPlayerInput.SwitchCurrentActionMap("Conversation");
            ConvoManager.Instance.StartConvo(conversation);
        }
    }

    public void DisableHB(){
        hitBox.gameObject.SetActive(false);
    }
}
