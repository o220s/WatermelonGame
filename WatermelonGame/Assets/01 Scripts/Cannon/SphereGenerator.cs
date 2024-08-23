using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] spherePrefeb;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int sphereIndex = Random.Range(0, spherePrefeb.Length);

            GameObject sphere = Instantiate(spherePrefeb[sphereIndex], transform.position, transform.rotation);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 position = ray.direction;
            position = position.normalized * 2000;
            sphere.GetComponent<SphereController>().Throw(position);
        }
    }
}
