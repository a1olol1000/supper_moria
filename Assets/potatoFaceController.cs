using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class potatoFaceController : MonoBehaviour
{
    [SerializeField]
    float sped=5f;

    [SerializeField]
    float marioForce= 3000f;
    Rigidbody2D riidbody;
    Vector2 bottomcoliderSize;
    
    bool hasRelishedJumpButton= true;
    [SerializeField]
    float groundradius = 0.2f;
    [SerializeField]
    LayerMask groundlayer;



    // Start is called before the first frame update
    void Awake() 
    {
        riidbody = GetComponent<Rigidbody2D>();
        bottomcoliderSize.y =0.1f;
        bottomcoliderSize.x = GetComponent<Collider2D>().bounds.size.x * 0.9f;
    }
    
        
    

    // Update is called once per frame
    void Update()
    {
        
        
        bool isGrounded = Physics2D.OverlapCircle(Getfoot(), groundradius, groundlayer);

        if (Input.GetAxisRaw("Jump") > 0 && hasRelishedJumpButton == true && isGrounded)
        {
            riidbody.AddForce(Vector2.up * marioForce);
            hasRelishedJumpButton = false;
        }
        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasRelishedJumpButton = true;
        }        
        float momentX = Input.GetAxisRaw("Horizontal");
        Vector2 moment= new Vector2(momentX,0) * sped * Time.deltaTime;
        transform.Translate(moment);










    }
    private Vector2 GetfootSise()
    {
        return new(0.9f,GetComponent<Collider2D>().bounds.size.x * 0.9f);
    }
    private Vector2 Getfoot()
    {
        float height =GetComponent<Collider2D>().bounds.size.y;
        return transform.position + Vector3.down * height * 0.5f;
    }
    private void OnDrawGizmosSelected() 
    {
        
        
           
        
    }
}
