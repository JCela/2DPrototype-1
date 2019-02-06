using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to the Player character - this determines which current material you are and changes the player's attributes based on current material

public class GetMaterial : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public PhysicsMaterial2D BASE;
    public PhysicsMaterial2D SteelMat;
    public PhysicsMaterial2D IceMat;
    public PhysicsMaterial2D WoodMat;
    public PhysicsMaterial2D CopperMat;

    private PhysicsMaterial2D CurrentMaterial;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();

        CurrentMaterial = BASE;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // BECOME STEEL
            BecomeSteel();
            Debug.Log("-- STEEL --");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // BECOME ICE
            BecomeIce();
            Debug.Log("-- ICE --");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // BECOME WOOD
            BecomeWood();
            Debug.Log("-- WOOD --");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // BECOME COPPER
            BecomeCopper();
            Debug.Log("-- COPPER --");
        }

        rb.sharedMaterial = CurrentMaterial;
    }

    private void BaseLine()
    {
        CurrentMaterial = BASE;
        rb.mass = 2;
        rb.drag = 4;
        rb.gravityScale = 2;
    }

    private void BecomeSteel()
    {
        CurrentMaterial = SteelMat;
    }

    private void BecomeIce()
    {
        CurrentMaterial = IceMat;

    }

    private void BecomeWood()
    {
        CurrentMaterial = WoodMat;

    }

    private void BecomeCopper()
    {
        CurrentMaterial = CopperMat;
    }
}
