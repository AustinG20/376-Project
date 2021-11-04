using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lock_controller : MonoBehaviour
{

    [SerializeField] private List<GameObject> pins;
    [SerializeField] private List<int> pin_order;
    [SerializeField] private float wait_time;
    private int pins_pushed = 0;
    private float remaining_time = 0;
    private int pin = 0;
    private bool reset_pins = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remaining_time > 0)
        {
            remaining_time -= Time.deltaTime;
        }
        else
        {
            if (reset_pins)
            {
                ResetPins(pin);
                reset_pins = false;
            }
        }
        
    }

    public void PushPin(int pin_number)
    {
        if (pin_number < pins.Count && !reset_pins)
        {
            if (!pins[pin_number].GetComponent<pin_controller>().state)
            {
                pins[pin_number].GetComponent<pin_controller>().Toggle();
                remaining_time = wait_time;
                pin = pin_number;
                reset_pins = true;
            }
        }
    }

    private void ResetPins(int pin_number)
    {
        // if the pin number is out of order reset pins
        if (pin_order[pins_pushed] != pin_number + 1)
        {
            pins_pushed = 0;
            foreach (GameObject pin in pins)
            {
                pin.GetComponent<pin_controller>().ResetPosition();
            }
        }
        else
        {
            pins_pushed++;
        }
        
    }
}
