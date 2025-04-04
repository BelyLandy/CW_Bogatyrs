using UnityEngine;

public class GARBAGE : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //void DirectionSpriteChangerg()
    //{
    //    float inputCircle = Mathf.Sqrt(moveInput.x * moveInput.x + moveInput.y * moveInput.y);
    //    //Vector2 newVelocity = rb.velocity;
    //    //direction = Vector2.zero;

    //    if (inputCircle > 0.3f && inputCircle <= 1f)
    //    {
    //        if (IsDiagonalMove(out direction))
    //        {
    //            //UpdateVelocity(ref newVelocity, direction, diagMove: true);
    //            diagMove = true;
    //        }
    //        else if (IsHorizontalMove() || IsVerticalMove())
    //        {
    //            if (diagMove)
    //            {
    //                //StopMovement(ref newVelocity);
    //                diagMove = false;
    //            }
    //            else
    //            {
    //                //UpdateVelocity(ref newVelocity, direction, diagMove: false);
    //            }
    //        }
    //    }
    //    else if (inputCircle == 0)
    //    {
    //        //StopMovement(ref newVelocity);
    //    }

    //    //rb.velocity = newVelocity;
    //}
    
    //void UpdateVelocity(ref Vector2 velocity, Vector2 direction, bool diagMove)
    //{
    //    float targetX = diagMove ? speed * speedMultiplier * direction.x : direction.x * speed * speedMultiplier;
    //    float targetY = diagMove ? speed * speedMultiplier * direction.y : direction.y * speed * speedMultiplier;
    //    //velocity.x = Mathf.MoveTowards(rb.velocity.x, targetX, walkAcceleration * Time.fixedDeltaTime);
    //    //velocity.y = Mathf.MoveTowards(rb.velocity.y, targetY, walkAcceleration * Time.fixedDeltaTime);

    //    //velocity.x = Mathf.Lerp(rb.velocity.x, targetX, Time.fixedDeltaTime * speedMultiplier);
    //    //velocity.y = Mathf.Lerp(rb.velocity.y, targetY, Time.fixedDeltaTime * speedMultiplier);

    //    velocity.x = targetX;
    //    velocity.y = targetY;
    //}

    //void StopMovement(ref Vector2 velocity)
    //{
    //    //velocity.x = Mathf.MoveTowards(rb.velocity.x, 0, groundDeceleration * Time.fixedDeltaTime);
    //    //velocity.y = Mathf.MoveTowards(rb.velocity.y, 0, groundDeceleration * Time.fixedDeltaTime);

    //    velocity = new Vector2(0, 0);
    //}

    //Vector2 targetVelocity = direction * speed * speedMultiplier;

    //if (moveInput.x != 0 || moveInput.y != 0)
    //{
    //    if (inputCircle >= 0.4f && inputCircle <= 1f)
    //    {
    //if (moveInput.x > (2.5f * moveInput.y) && moveInput.x >= (-2.5f * moveInput.y))
    //{
    //    //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    //    direction = new Vector2(1f, 0f);
    //    newVelocity.x = Mathf.MoveTowards(rb.velocity.x, (speed * speedMultiplier * direction).x, walkAcceleration * Time.fixedDeltaTime);
    //}

    //if (moveInput.x <= (2.5f * moveInput.y) && moveInput.x <= (-2.5f * moveInput.y))
    //{
    //    //transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    //    direction = new Vector2(-1f, 0f);
    //    newVelocity.x = Mathf.MoveTowards(rb.velocity.x, (speed * speedMultiplier * direction).x, walkAcceleration * Time.fixedDeltaTime);
    //}

    //if (moveInput.x <= (2.5f * moveInput.y) && moveInput.x >= (0.4f * moveInput.y))
    //        {
    //            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    //            direction = new Vector2(0.7071067811865475f, 0.7071067811865475f);
    //            newVelocity.x = Mathf.MoveTowards(rb.velocity.x, speed * speedMultiplier * direction.x, walkAcceleration * Time.fixedDeltaTime);
    //            newVelocity.y = Mathf.MoveTowards(rb.velocity.y, speed * speedMultiplier * direction.y, walkAcceleration * Time.fixedDeltaTime);
    //            Debug.Log("Diag");
    //        }
    //        }
    //    }
    //    if (moveInput.x == 0) 
    //    {
    //        newVelocity.x = Mathf.MoveTowards(rb.velocity.x, 0, groundDeceleration * Time.fixedDeltaTime);
    //    }
    //    if (moveInput.y == 0)
    //    {
    //        newVelocity.y = Mathf.MoveTowards(rb.velocity.y, 0, groundDeceleration * Time.fixedDeltaTime);
    //    }


    //void PlayerMovement()
    //{
    //    Vector2 targetVelocity = moveInput * speed * speedMultiplier;

    //    Vector2 newVelocity = rb.velocity;

    //    if (moveInput.x != 0)
    //    {
    //        newVelocity.x = Mathf.MoveTowards(rb.velocity.x, targetVelocity.x, walkAcceleration * Time.fixedDeltaTime);
    //    }
    //    else
    //    {
    //        newVelocity.x = Mathf.MoveTowards(rb.velocity.x, 0, groundDeceleration * Time.fixedDeltaTime);
    //    }

    //    if (moveInput.y != 0)
    //    {
    //        newVelocity.y = Mathf.MoveTowards(rb.velocity.y, targetVelocity.y, walkAcceleration * Time.fixedDeltaTime);
    //    }
    //    else
    //    {
    //        newVelocity.y = Mathf.MoveTowards(rb.velocity.y, 0, groundDeceleration * Time.fixedDeltaTime);
    //    }

    //    rb.velocity = newVelocity;
    //}
    // bool IsHorizontalMove()
    // {
    //     if (moveInput.x >= (2.5f * moveInput.y) && moveInput.x >= (-2.5f * moveInput.y))
    //     {
    //         //direction = Vector2.right;
    //         return true;
    //     }
    //
    //     if (moveInput.x <= (2.5f * moveInput.y) && moveInput.x <= (-2.5f * moveInput.y))
    //     {
    //         //direction = Vector2.left;
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    // bool IsVerticalMove()
    // {
    //     if (moveInput.x <= (0.4f * moveInput.y) && moveInput.x >= (-0.4f * moveInput.y))
    //     {
    //         //direction = Vector2.up;
    //         return true;
    //     }
    //
    //     if (moveInput.x >= (0.4f * moveInput.y) && moveInput.x <= (-0.4f * moveInput.y))
    //     {
    //         //direction = Vector2.down;
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    // bool IsDiagonalMove()
    // {
    //     if (moveInput.x < (2.5f * moveInput.y) && moveInput.x > (0.4f * moveInput.y))
    //     {
    //         //direction = new Vector2(0.71f, 0.71f);
    //         //direction = moveInput;
    //         //Debug.Log("Diag 1");
    //
    //         return true;
    //     }
    //
    //     if (moveInput.x < (0.4f * moveInput.y) && moveInput.x > (2.5f * moveInput.y))
    //     {
    //         //direction = new Vector2(-0.71f, -0.71f);
    //         //direction = moveInput;
    //         //Debug.Log("Diag 3");
    //         return true;
    //     }
    //
    //     if (moveInput.x < (-0.4f * moveInput.y) && moveInput.x > (-2.5f * moveInput.y))
    //     {
    //         //direction = new Vector2(-0.71f, 0.71f);
    //         //direction = moveInput;
    //         //Debug.Log("Diag 2");
    //         return true;
    //     }
    //
    //     if (moveInput.x < (-2.5f * moveInput.y) && moveInput.x > (-0.4f * moveInput.y))
    //     {
    //         //direction = new Vector2(0.71f, -0.71f);
    //         // direction = moveInput;
    //         //Debug.Log("Diag 4");
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    //
    // private bool diagMove = false;
    //
    // void DirectionSpriteChanger()
    // {
    //     float inputCircle = Mathf.Sqrt(moveInput.x * moveInput.x + moveInput.y * moveInput.y);
    //
    //     if (inputCircle > 0.5f && inputCircle <= 1f)
    //     {
    //         if (IsDiagonalMove())
    //         {
    //             diagMove = true;
    //         }
    //         else if (IsHorizontalMove() || IsVerticalMove())
    //         {
    //             if (diagMove)
    //             {
    //                 diagMove = false;
    //             }
    //         }
    //     }
    //     else
    //     {
    //     }
    // }
}
