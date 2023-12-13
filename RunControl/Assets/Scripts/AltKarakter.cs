using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AltKarakter : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _navMeshAgent;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().VarisNoktasi; //belirlenmiş olan varış noktasını poziyon olarak alıcak
    }

    private void LateUpdate()
    {
        _navMeshAgent.SetDestination(Target.transform.position); //sürekli o pozisyonu takip etmesini sağladım
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IgnelKutu"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AnlikKarakterSayisi--;
            gameObject.SetActive(false);
            
        }
    }
}
