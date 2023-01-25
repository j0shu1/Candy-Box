using UnityEngine;

public class CreateLollipop : MonoBehaviour
{
    public GameObject lollipopPrefab;
    public int xSpawn;
    public int ySpawn;

    private GameObject[] lollipops;
    private float weirdConstant = 0.009259259f;

    void Start()
    {
        SpawnLollipop();
    }
    private void Update()
    {
        lollipops = GameObject.FindGameObjectsWithTag("Lollipop");
        if (lollipops.Length == 0)
        {
            SpawnLollipop();
        }
    }
    private void SpawnLollipop()
    {
        //ySpawn = Random.Range(0 + 50, 1080 - 50); // Adjust by 50 for radius of the cube
        //xSpawn = Random.Range(0 + 50, 1920 - 50);
        //xSpawn = 0;
        //ySpawn = 0;
        GameObject newLollipop = Instantiate(
            lollipopPrefab,
            new Vector3(xSpawn * weirdConstant, ySpawn * weirdConstant, 1),
            Quaternion.identity,
            transform);
        newLollipop.name = "lollipop";
    }

}
