﻿using System;
using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;
using NinjectAttr = Ninject;
using StashBoxAttr = Stashbox.Attributes;
using UnityAttr = Unity;
using MvvmCrossAttr = MvvmCross.IoC;
using InjectorDotNET = Solti.Utils.DI.Interfaces;

namespace IocPerformance.Classes.Properties
{
    public interface ISubObjectB
    {
        void Verify(string containerName);
    }

    [MEFAttr.ExportAttribute(typeof(ISubObjectB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(ISubObjectB))]
    public class SubObjectB : ISubObjectB
    {
        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public IServiceB ServiceB { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB was null for SubObjectC for container " + containerName);
            }
        }
    }
}
