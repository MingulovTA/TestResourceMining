using System.Collections;
using App.ServiceLocator;
using App.ServiceLocator.Interfaces;
using UnityEngine;

namespace App.Services.Runners
{
    public interface ICoroutineRunner : IService
    {
        Coroutine Run(IEnumerator coroutine);
    }
}