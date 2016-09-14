using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    public float smoothing;

    private Vector2 origem;
    private Vector2 direcao;
    private Vector2 smoothingDirection;
    private bool touched;
    private int pointerID;


    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        if (!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
            origem = eventData.position;
        }
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        // Compare a diferenca entre o inicio e o ponto atual
        if (eventData.pointerId == pointerID)
        {
            Vector2 posicaoAtual = eventData.position;
            Vector2 direcaoRaw = posicaoAtual - origem;
            direcao = direcaoRaw.normalized;

            //Debug.Log(direcao);
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        // Reseta tudo
        if (eventData.pointerId == pointerID)
        {
            direcao = Vector2.zero;
            touched = false;
        }
        
    }

    void Awake ()
    {
        direcao = Vector2.zero;
        touched = false;
    }

    public Vector2 GetDirecao ()
    {
        smoothingDirection = Vector2.MoveTowards(smoothingDirection, direcao, smoothing);
        return smoothingDirection;
    }
}
