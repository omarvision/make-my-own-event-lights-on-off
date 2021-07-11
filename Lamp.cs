using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light lamp = null;
    private string floor_name = "";

    private void Start()
    {
        floor_name = this.transform.parent.name;
        lamp.enabled = true;
    }

    //step 3. listen to event
    private void OnEnable()
    {
        Player.OnPlayerFloorChange += DoLight;  //add listener
    }
    private void OnDisable()
    {
        Player.OnPlayerFloorChange -= DoLight;  //remove listener
    }
    private void DoLight(string Floorname)
    {
        if (Floorname == floor_name)
        {
            lamp.enabled = true;
        }
        else
        {
            lamp.enabled = false;
        }
    }
}
