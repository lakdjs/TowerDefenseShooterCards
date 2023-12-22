using System;
using System.Collections;
using System.Collections.Generic;
using CharacterSystem;
using UnityEngine;

public class CanvasElementFollower : MonoBehaviour
{
   [SerializeField] private Transform character;
   [SerializeField] private Vector3 offset;
   private Camera _camera;

   private void Awake()
   {
      if (character == null)
      {
         character = FindObjectOfType<Character>().gameObject.transform;
      }
      _camera = Camera.main;
   }

   private void Update()
   {
      transform.position = character.position + offset;
      transform.rotation = _camera.transform.rotation;
   }
}
