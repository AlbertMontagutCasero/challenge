using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numTables = 3;
    public int maxMultiplyBy = 10;
    public GameObject toInstantiate;

    void Start()
    {
        for (int table = 0; table < numTables; table++)
        {
            for (int multiplyBy = 0; multiplyBy < maxMultiplyBy; multiplyBy++)
            {
                int multiplicationResult = (table + 1) * (multiplyBy + 1);
                float widthToInstantiate = toInstantiate.GetComponent<Renderer>().bounds.size.x;
                float offset = widthToInstantiate;

                if (multiplyBy == 0) // first 
                {
                    for (int z = 0; z < multiplicationResult; z++)
                    {
                    Vector3 nextPosition = new Vector3(
                        (float)multiplyBy * (widthToInstantiate + widthToInstantiate / 2),
                        (float)z * widthToInstantiate + widthToInstantiate / 2,
                        (float)table * (widthToInstantiate + widthToInstantiate / 2));

                        GameObject instantiated = Instantiate(toInstantiate, nextPosition, new Quaternion(0, 0, 0, 0));
                        Renderer instantiadedRender = instantiated.GetComponent<Renderer>();
                        instantiadedRender.material.color = new Color32(
                            (byte)((z + 1) * 255 / multiplicationResult),
                            0,
                            0,
                            255);
                    }
                }

                for (int i = 0; i < multiplicationResult; i++) //resultat taula multiplicar ex: 4x4 = 16 figures
                {

                    Vector3 nextPosition = new Vector3(
                        (float)multiplyBy * (offset + widthToInstantiate + widthToInstantiate / 2) ,
                        (float)i * widthToInstantiate + widthToInstantiate / 2,
                        (float)table * (offset + widthToInstantiate + widthToInstantiate / 2));

                    GameObject instantiated = Instantiate(toInstantiate, nextPosition, new Quaternion(0, 0, 0, 0));
                    Renderer instantiadedRender = instantiated.GetComponent<Renderer>();
                    instantiadedRender.material.color = new Color32(
                        0,
                        (byte)(multiplyBy * 255 / maxMultiplyBy),
                        (byte)((i + 1) * 255 / multiplicationResult),
                        255);
                }
            }
        }
    }
}
