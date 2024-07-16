using System;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
   public Joystick movementJoystick;
   public float playerSpeed;
   private Rigidbody2D rb;
   public Animator myAnim;
   private bool facingRight;
   public GameObject objectclone;
   public List<GameObject> targetList;
   private void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        targetList =  new List<GameObject>(Resources.LoadAll<GameObject>("Templates"));
   }
   private void FixedUpdate()
   {
     try
     {
          
          if (movementJoystick.Direction.y != 0 && movementJoystick.Direction.x != 0)
          {    
               if(!facingRight && movementJoystick.Direction.x > 0)
               {
                    Flip();
               }else if(facingRight && movementJoystick.Direction.x < 0)
               {
                    Flip();
               }
                myAnim.SetBool("Moving",true);
               rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed,rb.velocity.y);
               if(movementJoystick.Direction.y > 0 && movementJoystick.Direction.y <= 0.5f)
               {
                    rb.velocity = new Vector2(rb.velocity.x, 5);
               }else if(movementJoystick.Direction.y > 0.5f && movementJoystick.Direction.y <= 1f)
               {
                    rb.velocity = new Vector2(rb.velocity.x, 10);
               }
              
               
          }else
          {
               myAnim.SetBool("Moving",false);
               
          }
     }catch(Exception exc)
     {
          changeObject();
       
     }
       
   }
   public void changeObject()
   {
     if(targetList.Count > 0)
          {
               if(objectclone!=null)
               {
                    Destroy(objectclone);
               }
               int index = UnityEngine.Random.Range(0, targetList.Count);
               objectclone = Instantiate(targetList[index],transform);
               myAnim = objectclone.GetComponent<Animator>();
               Debug.Log("Spawn "+targetList[index].name);
          }
   }
   public void attackSimple()
   {
          
          myAnim.SetTrigger("AttackMelee");
   }
   public void attackSkill1()
   {
          myAnim.SetTrigger("AttackSkillA");
   }
   public void attackSkill2()
   {
          myAnim.SetTrigger("AttackSkillB");
   }
   private void Flip()
   {
      facingRight = !facingRight;
      Vector2 theScale = transform.localScale;
      theScale.x *=-1; 
      transform.localScale = theScale;
   }
}
