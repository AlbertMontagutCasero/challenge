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
                Vector3 startPosition = new Vector3(widthToInstantiate * 3, 0, 0);

                for (int i = 0; i < multiplicationResult; i++) //resultat taula multiplicar ex: 4x4 = 16 figures
                {
                    Vector3 nextPosition;
                    GameObject instantiated;
                    Renderer instantiadedRender;

                    if (multiplyBy == 0) // first iteration spawn red indicator cubes
                    {
                        nextPosition = new Vector3(
                            widthToInstantiate / 2,
                            i * widthToInstantiate + widthToInstantiate / 2,
                            table * (offset + widthToInstantiate) + widthToInstantiate / 2);
                        instantiated = Instantiate(toInstantiate, nextPosition, new Quaternion(0, 0, 0, 0));
                        instantiadedRender = instantiated.GetComponent<Renderer>();
                        instantiadedRender.material.color = new Color32(
                            (byte)((i + 1) * 255 / multiplicationResult),
                            0,
                            0,
                            255);
                    }

                    nextPosition = new Vector3(
                        startPosition.x + (multiplyBy * (offset + widthToInstantiate) + widthToInstantiate / 2),
                        startPosition.y + (i * widthToInstantiate + widthToInstantiate / 2),
                        startPosition.z + (table * (offset + widthToInstantiate) + widthToInstantiate / 2));
                    instantiated = Instantiate(toInstantiate, nextPosition, new Quaternion(0, 0, 0, 0));
                    instantiadedRender = instantiated.GetComponent<Renderer>();
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
