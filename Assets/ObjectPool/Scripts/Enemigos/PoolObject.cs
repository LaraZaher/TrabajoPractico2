using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolObject : MonoBehaviour
{
    public static PoolObject instance { get; private set; }


    [SerializeField] private List<GameObject> Pool_Proyectiles;
    [SerializeField] GameObject Proyectiles;
    [SerializeField] int Cantidad_Pool;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        AñadirProyectil(Cantidad_Pool);
    }



    private void AñadirProyectil(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject obstacle = Instantiate(Proyectiles);
            obstacle.SetActive(false);
            Pool_Proyectiles.Add(obstacle);

            obstacle.transform.parent = transform;
        }
    }

    public GameObject GetProyectile()
    {
        for (int i = 0; i < Cantidad_Pool; i++)
        {
            if (!Pool_Proyectiles[i].activeSelf)
            {
                if (Pool_Proyectiles[i] != null)
                {
                    Pool_Proyectiles[i].SetActive(true);
                    return Pool_Proyectiles[i];
                }
            }
        }
        AñadirProyectil(1);
        Pool_Proyectiles[Pool_Proyectiles.Count - 1].SetActive(true);
        return Pool_Proyectiles[Pool_Proyectiles.Count - 1];
    }
}