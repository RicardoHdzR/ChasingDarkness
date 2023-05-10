using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] int x, y;
    [SerializeField] GameObject room, navpoint, wall, llave, exit;
    void Start()
    {
        Debug.LogWarning("Generating rooms");
        for (int i = 1; i < x+1; i++)
            for (int j = 1; j < y+1; j++)
                Instantiate(room, new Vector3(i * 6, j * 4, 0), Quaternion.identity);

        Debug.LogWarning("Generating navs");
        List<GameObject> points = new List<GameObject>();
        for (int i = 0; i < x+1; i++)
            for (int j = 0; j < y+1; j++)
                points.Add(Instantiate(navpoint, new Vector3(i * 6 +1, j * 4 + 3, 0), Quaternion.identity));

        Debug.LogWarning("Generating friends");
        for (int i = 0; i < points.Count; i++)
        {
            List<GameObject> points2 = new List<GameObject>();
            if (i%(x+1) != 0)
                points2.Add(points[i - 1]);

            if ((i + 1)% (x + 1) != 0)
                points2.Add(points[i + 1]);

            if (i > (x + 1))
                points2.Add(points[((((int)i / x) - 1) * x) + (i % x)-1]);

            if (i < points.Count - x - 2)
                points2.Add(points[((((int)i / x) + 1) * x) + (i % x)+1]);

            Debug.LogWarning("Adding friends");
            points[i].GetComponent<NavPoint>().friends = points2.ToArray();
        }
        Debug.LogWarning("Generating walls");
        for (int i = 0; i < x*6 + 2; i++)
            Instantiate(wall, new Vector3(i + 0.5f, 1.5f),Quaternion.identity);

        for (int i = 0; i < x * 6 + 2; i++)
            Instantiate(wall, new Vector3(i + 0.5f, x * 4 + 4.5f), Quaternion.identity);

        for (int j = 0; j < y * 4 +2; j++)
            Instantiate(wall, new Vector3(-0.5f, j + 2.5f), Quaternion.identity);

        for (int j = 0; j < y * 4 + 2; j++)
            Instantiate(wall, new Vector3(y * 6 + 2.5f, j + 2.5f), Quaternion.identity);

        Debug.LogWarning("Generating key");
        Instantiate(llave, points[Random.Range(1, points.Count)].transform.position, Quaternion.identity);

        Debug.LogWarning("Generating exit");
        //Instantiate(exit, new Vector3(Random.Range(0, x * 6) + 0.5f, x * 4 + 4.5f), Quaternion.identity)a
	Vector3 exitpos = Vector3.forward;
	switch(Random.Range(0, 4)){
        case 0: //North
	    exitpos = new Vector3(Random.Range(0, x * 6) + 0.5f, x * 4 + 4.5f);
	    break;
	case 1: //South
	    exitpos = new Vector3(Random.Range(0, x * 6) + 0.5f, 1.5f);
	    break;
	case 2: //East
	    exitpos = new Vector3(y * 6 + 2.5f, 2.5f + Random.Range(0, y * 4));
	    break;
	case 3: //West
	    exitpos = new Vector3(-0.5f, Random.Range(0, y * 4) + 2.5f);
	    break;
	}
	exit.transform.position = exitpos;

    }

}
