using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Transform tankPosition;
    public ObjectManager fuelManager;
    public Text tankPositionText;
    public Text fuelPositionText;
    public Text distanceText;
    public Text energyText;

    public Drive drive;

    public void AddEnergy(string amount)
    {
        int n;
        if (int.TryParse(amount, out n))
        {
            drive.AddEnergy(n);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tankPositionText.text = tankPosition.position.ToString();
        fuelPositionText.text = fuelManager.GetObject().transform.position.ToString();
        energyText.text = drive.GetEnergy().ToString();
    }

    private static string PositionToString(Vector3 position)
    {
        return "(" + (int)position.x + "," + (int)position.y + ")";
    }
}
