using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagdollUnfreeze : MonoBehaviour
{
    public float m_Force;

    private Dictionary<Rigidbody, (Vector3, Vector3)> m_RigidbodyDict;
    private bool m_Triggered;
    private float m_ResetTime;
    public Text HitTable;

    private void Awake()
    {
        m_RigidbodyDict = new Dictionary<Rigidbody, (Vector3, Vector3)>();
        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
            m_RigidbodyDict.Add(rigidbody, (rigidbody.transform.position, rigidbody.transform.eulerAngles));
        }
    }

    private void Update()
    {
        if (m_Triggered && m_ResetTime <= Time.time)
            Reset();
    }

    public void TriggerRagdoll()
    {
        HitTable.text = "true";
        if (m_Triggered)
            return;

        foreach (var rigidbody in m_RigidbodyDict.Keys)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(rigidbody.transform.up * m_Force, ForceMode.Impulse);
        }

        m_ResetTime = Time.time + 5f;
        m_Triggered = true;
    }

    public void Reset()
    {
        foreach (var entries in m_RigidbodyDict)
        {
            var rigidbody = entries.Key;
            var (postion, eulerAngles) = entries.Value;

            rigidbody.isKinematic = true;
            rigidbody.transform.SetPositionAndRotation(postion, Quaternion.Euler(eulerAngles));
        }
        m_Triggered = false;
    }
}
