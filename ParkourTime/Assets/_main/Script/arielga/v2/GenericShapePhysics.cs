using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericShapePhysics : MonoBehaviour
{
    public Vector3 velocidad;
    public Vector3 aceleracion;
    public Vector3 fuerza;

    public float masa = 1f;
    public float gravedad = 1f;

    private float t;

    void Update()
    {
        t = Time.deltaTime;
        Vector3 direccionDeFuerza = Vector3.ClampMagnitude(-velocidad, 1f);
        aplicarFuerza(direccionDeFuerza * 100f * t);

        aceleracion = fuerza / masa;
        fuerza = Vector3.zero;
        velocidad += aceleracion * t;

        transform.position = transform.position + velocidad * t + 0.5f * fuerza * t * t;
        aplicarFuerza(Vector3.down * gravedad * masa);
    }

    private void FixedUpdate()
    {

    }

    public void aplicarFuerza(Vector3 qVector)
    {
        fuerza += qVector;
    }

}
