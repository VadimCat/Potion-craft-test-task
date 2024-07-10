﻿using System;
using System.Collections.Generic;

namespace Ji2.Context.Modules.Context
{
 public class DiContext : IDependenciesProvider, IDependenciesController
 {
  private static DiContext _instance;
  private readonly Dictionary<Type, object> _services = new();
  private readonly IDependenciesProvider _parentProvider;

  private DiContext()
  {
   _instance = this;
  }

  public DiContext(IDependenciesProvider parentProvider)
  {
   _parentProvider = parentProvider;
  }

  public static DiContext GetOrCreateInstance()
  {
   if (_instance != null)
    return _instance;

   return new DiContext();
  }

  public void Register<TContract>(TContract service)
  {
   Register(typeof(TContract), service);
  }

  public void Register(Type type, object service)
  {
   if (_services.ContainsKey(type))
   {
    throw new Exception($"Service already added by this type {type.FullName}");
   }

   if (type.IsInstanceOfType(service) || service.GetType() == type)
   {
    _services[type] = service;
   }
   else
   {
    throw new Exception("Service type doesn't match contract type");
   }
  }

  public TContract Get<TContract>()
  {
   if (!_services.ContainsKey(typeof(TContract)) && _parentProvider != null)
   {
    return _parentProvider.Get<TContract>();
   }

   if (!_services.ContainsKey(typeof(TContract)) && _parentProvider == null)
   {
    throw new Exception($"No service register by type {typeof(TContract)}");
   }

   return (TContract)_services[typeof(TContract)];
  }

  public bool TryGetService<TContract>(out TContract result)
  {
   if (!_services.ContainsKey(typeof(TContract)) && _parentProvider != null)
   {
    return _parentProvider.TryGetService(out result);
   }

   if (!_services.ContainsKey(typeof(TContract)) && _parentProvider == null)
   {
    result = default;
    return false;
   }

   result = (TContract)_services[typeof(TContract)];
   return true;
  }

  public void Unregister<TContract>()
  {
   Unregister(typeof(TContract));
  }

  public void Unregister(Type type)
  {
   if (!_services.ContainsKey(type))
   {
    throw new Exception("Service already unregistered by this type");
   }

   _services.Remove(type);
  }
 }

 public interface IDependenciesController
 {
  public void Register<TContract>(TContract service);
  public void Register(Type type, object service);
  public void Unregister(Type type);
  public void Unregister<TContract>();
 }

 public interface IDependenciesProvider
 {
  public TContract Get<TContract>();
  public bool TryGetService<TContract>(out TContract result);
 }
}