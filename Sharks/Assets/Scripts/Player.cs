using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public GameObject canvas;
    
    

    [SerializeField] private int _maxHP;
    private int _currentHP = 100;
    [SerializeField] Slider _hpSlider;


    // Start is called before the first frame update
    void Start()
    {
        _currentHP = _maxHP;
        _hpSlider.maxValue = _maxHP;
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.joystickVec.y != 0)
		{
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(Vector2.zero, movementJoystick.joystickVec);
            float y = 180f;

            transform.rotation = Quaternion.Euler(new Vector3(angle * -1 + 180, 90f, y - 180));
        }
        
        else 
        {
            rb.velocity = Vector2.zero;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void ChangeHP(int value)
    {
        _currentHP += value;
        _hpSlider.value = _currentHP;

        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
        else if (_currentHP <= 0)
        {
            OnDeath();
        }
        Debug.Log("Value = " + value);
        Debug.Log("Current HP = " + _currentHP);
    }


    public void OnDeath()
    {
        canvas.SetActive(true);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Spike")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.name == "Fish"|| collision.name == "Fish(Clone)"|| collision.name == "Fish1(Clone)"|| collision.name == "Fish 2(Clone)")
        {
            
            transform.localScale = new Vector3(transform.localScale.x+0,transform.localScale.y+5,transform.localScale.z+5);
            Destroy(collision.gameObject);
        }
        else if(collision.name == "Human"|| collision.name == "Human(Clone)")
        {
            transform.localScale = new Vector3(transform.localScale.x + 0, transform.localScale.y + 5, transform.localScale.z + 5);
            Destroy(collision.gameObject);
        }
    }

}
