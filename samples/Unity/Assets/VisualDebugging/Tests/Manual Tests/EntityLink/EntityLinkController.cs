﻿using Entitas.Unity;
using UnityEngine;

public class EntityLinkController : MonoBehaviour
{
    void Start()
    {
        var context = Contexts.sharedInstance.game;
        var e = context.CreateEntity();

        var go = new GameObject();
        go.Link(e);

        e.AddMyGameObject(go);

//        go.Unlink();

        Destroy(go);
    }
}
