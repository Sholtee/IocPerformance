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
    public interface IComplexPropertyObject1
    {
        void Verify(string containerName);
    }

    public interface IComplexPropertyObject2
    {
        void Verify(string containerName);
    }

    public interface IComplexPropertyObject3
    {
        void Verify(string containerName);
    }

    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject1))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplexPropertyObject1))]
    public class ComplexPropertyObject1 : IComplexPropertyObject1
    {
        private static int counter;

        public ComplexPropertyObject1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }

    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject2))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplexPropertyObject2))]
    public class ComplexPropertyObject2 : IComplexPropertyObject2
    {
        private static int counter;

        public ComplexPropertyObject2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }

    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject3))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplexPropertyObject3))]
    public class ComplexPropertyObject3 : IComplexPropertyObject3
    {
        private static int counter;

        public ComplexPropertyObject3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        [InjectorDotNET.Inject]
        public virtual ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }
}
