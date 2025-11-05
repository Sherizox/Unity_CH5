using UnityEngine;

public class ModScript : MonoBehaviour
{
    public float move = 1f;
    public float rotate = 50f;

    public float Direction = 5f;   
    public float DirectionY = 5f;  
    public float moveY = 1f;       

    bool movingRight = true;
    bool movingUp = true;

    void Update()
    {
   
        //transform.Rotate(0, 0, rotate * Time.deltaTime);

      
        if (movingRight)
        {
            transform.Translate(move * Time.deltaTime, 0, 0);
            if (transform.position.x > Direction)
                movingRight = false;
        }
        else
        {
            transform.Translate(-move * Time.deltaTime, 0, 0);
            if (transform.position.x < -Direction)
                movingRight = true;
        }

       
        if (movingUp)
        {
            transform.Translate(0, moveY * Time.deltaTime, 0);
            if (transform.position.y > DirectionY)
                movingUp = false;
        }
        else
        {
            transform.Translate(0, -moveY * Time.deltaTime, 0);
            if (transform.position.y < -DirectionY)
                movingUp = true;
        }
    }
}
