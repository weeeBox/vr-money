using UnityEngine;

using System;
using System.Collections;

using Random = UnityEngine.Random;

[Serializable]
public class MoneyMakerPrefabs
{
    [SerializeField]
    MoneyBundle m_moneyBundle;

    public MoneyBundle moneyBundle
    {
        get { return m_moneyBundle; }
    }
}

public class MoneyMaker : MonoBehaviour
{
    [SerializeField]
    MoneyMakerPrefabs m_prefabs;

    [SerializeField]
    int m_amount = 1000;

    [SerializeField]
    int m_bill = 20;

    [SerializeField]
    int m_strapSize = 100;

    [SerializeField]
    float m_gap = 0.01f;

    [SerializeField]
    float m_alpha = 0;

    [SerializeField]
    float m_offset = 0;

    void Start()
    {
        MakeMoney();
    }

    public void MakeMoney()
    {
        int strapAmount = m_bill * m_strapSize;

        int strapCount = m_amount / strapAmount;
        int rest = m_amount % strapAmount;

        int maxSize = 0;
        int count = 0;
        while (count < strapCount)
        {
            ++maxSize;
            count += maxSize * maxSize;
        }

        MoneyBundle[] oldBundles = FindObjectsOfType<MoneyBundle>();
        foreach (MoneyBundle bundle in oldBundles)
        {
            DestroyImmediate(bundle.gameObject);
        }

        Vector3 colliderSize = m_prefabs.moneyBundle.size;

        for (int size = maxSize; size > 0; --size)
        {
            float x = -(0.5f * (size - 1) * colliderSize.x + (size - 1) * m_gap);
            float y = (maxSize - size + 0.5f) * colliderSize.y;
            for (int i = 0; i < size; ++i)
            {
                float z = -(0.5f * (size - 1) * colliderSize.z + (size - 1) * m_gap);
                for (int j = 0; j < size; ++j)
                {
                    GameObject bundle = Instantiate(m_prefabs.moneyBundle.gameObject) as GameObject;
                    bundle.transform.position = new Vector3(x, y, z) + new Vector3(Random.Range(-m_offset, m_offset), 0, Random.Range(-m_offset, m_offset));
                    bundle.transform.rotation = Quaternion.AngleAxis(Random.Range(-m_alpha, m_alpha), Vector3.up);
                    z += colliderSize.z + m_gap;
                }
                x += colliderSize.x + m_gap;
            }
        }
    }
}
