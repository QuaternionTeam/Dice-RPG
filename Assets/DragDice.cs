using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DragDice : MonoBehaviour
{
    public bool dragging;
    public bool target;
    public Vector3 initialPosition;

    public RawImage diceImage;

    public bool diceClicked;

    public bool targetSelected;

    public int numDice;

    public Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = diceImage.rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p"))
            playAnim();

        if(dragging)
        {
            Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            diceImage.rectTransform.position = mousePosition;
        }
        if(diceClicked)
        {
            print("Dado seleccionado");
            Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D ray = Physics2D.Raycast(mousePosition, mousePosition);
            if (ray.collider != null && ray.collider != gameObject.GetComponent<Collider2D>() && Input.GetMouseButtonDown(0))
            {
                targetSelected = true;
                print("objetivo seleccionado");
                applyDiceEffect();
            }

        }
        
    }

    public void OnMouseDown()
    {
        dragging = true;
        diceClicked = true;
        print("arrastrar objeto");
    }

    public void OnMouseUp()
    {
        print("soltar objeto");
        dragging =false;
        if(target)
        {
            // utiliza poder del coso
            print("seleccionaste objetivo");
            applyDiceEffect();
        }
        target = false;
        diceImage.rectTransform.position = initialPosition;

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Rigidbody2D>() != null)
        target = true;
    }



    public void applyDiceEffect()
    {
        print("aplicaste el efecto");
        anim.gameObject.SetActive(false);
    }

    public void playAnim()
    {

        print("reproducir animacion");
        anim.gameObject.SetActive(true);
        anim.SetTrigger("reset");
        anim.SetInteger("Dice",numDice);
    }


}
