using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * 5);
    }
}
