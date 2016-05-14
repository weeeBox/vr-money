using UnityEngine;
using System.Collections;

public class MoneyBundle : MonoBehaviour
{
    BoxCollider m_collider;

    public Vector3 size
    {
        get { return boxCollider.size; }
    }

    BoxCollider boxCollider
    {
        get
        {
            if (m_collider == null)
            {
                m_collider = GetComponent<BoxCollider>();
            }
            return m_collider;
        }
    }
}
