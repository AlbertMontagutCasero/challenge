using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 gridSize;
    public GameObject toInstantiate;

    void Start()
    {
        for (int i = 0; i < gridSize.y; i++)
        {
            for (int j = 0; j < gridSize.x; j++)
            {
                for (int z = 0; z < (i + 1) * (j+1); z++) //resultat taula multiplicar ex: 4x4 = 16 figures
                {
                    float widthToInstantiate = toInstantiate.GetComponent<Renderer>().bounds.size.x;
                    Vector3 nextPosition = new Vector3(
                        (float)j * widthToInstantiate + widthToInstantiate / 2,
                        (float)z * widthToInstantiate + widthToInstantiate / 2,
                        (float)i * widthToInstantiate + widthToInstantiate / 2);
                    GameObject instantiate = Instantiate(toInstantiate, nextPosition, new Quaternion(0, 0, 0, 0));

                }
            }
        }
    }
}
