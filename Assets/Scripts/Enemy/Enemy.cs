using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCreated;
    [SerializeField]
    private UnityEvent onDestroyed;

    //[SerializeField]
    //private float hueMin = 0;
    //[SerializeField]
    //private float hueMax = 1;
    //[SerializeField]
    //private float saturationMin = 0.7f;
    //[SerializeField]
    //private float saturationMax = 1;
    //[SerializeField]
    //private float valueMin = 0.7f;
    //[SerializeField]
    //private float valueMax = 1;
    //[SerializeField]
    //private float arrangeRange = 0.5f;
    //[SerializeField]
    //private float emissionIntensity = 5;
    //[SerializeField]
    //private ParticleSystem environmentParticle;
    //[SerializeField]
    //private MeshRenderer holeMeshRenderer;

    //[SerializeField]
    //private ParticleSystem destroyParticle;
    //[SerializeField]
    //private AudioSource destroyAudio;
    //[SerializeField]
    //private GameObject modelGameObject;
    [SerializeField]
    private float destroyDelay = 1;
    private bool isDestroyed = false;


    //private NavMeshAgent navMeshAgent;



    //private void Awake()
    private void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();

        //navMeshAgent.SetDestination(new Vector3(0, 2, 1));
        //navMeshAgent.speed *= Random.Range(0.8f, 1.5f);

        //RandomColor();

        //test
        //Invoke(nameof(Destroy), Random.Range(1, 6));


        onCreated?.Invoke();
        EnemyManager.Instance.OnSpawn(this);
    }

    //private void RandomColor()
    //{
    //    Color color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);

    //    ParticleSystem.MainModule module = environmentParticle.main;
    //    module.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1 - arrangeRange, 1 + arrangeRange));

    //    environmentParticle.GetComponent<ParticleSystemRenderer>().material.SetColor("_EmissionColor", color * emissionIntensity);

    //    holeMeshRenderer.material.SetColor("_EmissionColor", color * emissionIntensity);


    //    //dead particle
    //    module = destroyParticle.main;
    //    module.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1 - arrangeRange, 1 + arrangeRange));

    //    destroyParticle.GetComponent<ParticleSystemRenderer>().material.SetColor("_EmissionColor", color * emissionIntensity);
    //}

    public void Destroy()
    {
        if (isDestroyed) return;

        isDestroyed = true;

        //destroyParticle.Play();
        //destroyAudio.Play();

        //environmentParticle.Stop();
        //navMeshAgent.enabled = false;
        //modelGameObject.SetActive(false);

        Destroy(gameObject, destroyDelay);

        onDestroyed?.Invoke();
        EnemyManager.Instance.OnDestroyed(this);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
