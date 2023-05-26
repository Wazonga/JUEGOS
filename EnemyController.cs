using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{

   #region  PUBLIC PROPERTIES 
    public float WakeDistance = 5.0f;
    public float speed = 2.0f;
    public float AtkDistance = 1F;

    #region  Components
     public Transform Player;
     public SpriteRenderer spriteRenderer {private set; get;}
     public Rigidbody2D rb { private set; get;}
     public Animator mAnimator {private set; get;}

     public bool AtkEnd {set;get;} = false;
     public Transform HitBox;
     #endregion

   #endregion

   #region Private Properties 
   private FSM<EnemyController> mFSM;
   #endregion
   private Color defaultColor;

   private void Start()
   {
    spriteRenderer = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    mAnimator = GetComponent<Animator>();
    HitBox = transform.Find("HitBox");

    mFSM = new FSM<EnemyController>(new Enemy.IdleState(this));
    mFSM.Begin();

   }

   private void FixedUpdate()
   {
        mFSM.Tick(Time.fixedDeltaTime);
   }

   public void SetAtkEnd() {
      AtkEnd = true;  
   }
}