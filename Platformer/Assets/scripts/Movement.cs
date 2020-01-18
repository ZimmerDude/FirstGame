using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
	public float jumpHight = 500f;
    public float force = 200f;
    public bool canJump=true;
    public bool left=false;
    public bool right=false;

   
   public void leftMove(){
       left=true; 
    }

    public void rightMove(){
       right=true; 
    }
    
    public void release(){
    left=false;
    right=false;
    }
    
    void Update(){
        if(left){
            Vector2 movement = new Vector2 (-1f, 0f);
                if(!canJump)
                    rb2D.AddForce(movement * force/2);
                else
                    rb2D.AddForce(movement * force);
        }
        
        if(right){
            Vector2 movement = new Vector2 (1f, 0f);
                if(!canJump)
                    rb2D.AddForce(movement * force/2);
                else
                    rb2D.AddForce(movement * force);
        }
    }
    
    public void jump(){
        if(canJump){
        Vector2 movement = new Vector2 (0f, 1f);
        rb2D.AddForce(movement * jumpHight);
        }
    }
    
    
    void OnCollisionExit2D(Collision2D collision){
    if(collision.gameObject.tag=="Ground"){
    canJump=false;
    }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.tag=="Ground"){
    canJump=true;
    }
    }
    
}
