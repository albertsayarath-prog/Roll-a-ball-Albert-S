using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class scr : MonoBehaviour
{

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;

    private int count;

    public TextMeshProUGUI countText;

    public GameObject winText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void FixedUpdate(){
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);


        rb.AddForce(movement * speed);
    }

        void OnTriggerEnter(Collider other)
    {

       if (other.gameObject.CompareTag("Pickup")) 
       {
           other.gameObject.SetActive(false);
           count = count + 1;
           SetCountTest();
       }

       if (other.gameObject.CompareTag("Pickup2"))
       {
        other.gameObject.SetActive(false);
        speed = speed + 20;
       }


    }
    void SetCountTest(){
        countText.text = "Count: " +count.ToString();
        if(count >= 6){
            winText.SetActive(true);
            Destroy(GameObject.FindWithTag("Enemy"));
        }
       }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
            winText.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You lose!";
        }
    }

}
