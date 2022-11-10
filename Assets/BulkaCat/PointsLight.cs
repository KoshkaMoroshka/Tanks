using UnityEngine;

public class PointsLight : MonoBehaviour
{
    [SerializeField] private Color32 _currentColor;
    [SerializeField] private Color32 _newColor;

    private void Start()
    {
        _currentColor = GetComponent<Light>().color;
        _newColor = new Color32(System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(255));
    }
    private void Update()
    {
        if (ColorEquals(GetComponent<Light>().color, _newColor))
        {
            GetComponent<Light>().color = Color32.Lerp(GetComponent<Light>().color, _newColor, Time.deltaTime * 2.5f); ;
        }
        else
        {
            _newColor = new Color32(System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(255));
        }
    }

    private bool ColorEquals(Color32 clr1, Color32 clr2)
    {
        if (Mathf.Abs(clr1.r - clr2.r) < 25 && Mathf.Abs(clr1.g - clr2.g) < 25 && Mathf.Abs(clr1.b - clr2.b) < 25)
        {
            return false;
        }
        return true;
    }
}
