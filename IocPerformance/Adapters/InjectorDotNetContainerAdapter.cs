using System;

using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

using Solti.Utils.DI;
using Solti.Utils.DI.Interfaces;

using IServiceCollection = Solti.Utils.DI.Interfaces.IServiceCollection;

namespace IocPerformance.Adapters
{
    public sealed class InjectorDotNetContainerAdapter : ContainerAdapterBase
    {
        private IScopeFactory FScopeFactory;

        private IInjector FScope;

        public override string PackageName { get; } = "Injector.NET";

        public override string Name { get; } = "Injector.NET";

        public override string Version { get; } = typeof(ScopeFactory)
            .Assembly
            .GetName()
            .Version
            .ToString();

        public override string Url { get; } = "https://github.com/Sholtee/injector";

        public override bool SupportsInterception { get; } = true;

        public override bool SupportGeneric { get; } = true;

        public override bool SupportsMultiple { get; } = true;

        public override bool SupportsPropertyInjection { get; } = true;

        public override bool SupportsChildContainer { get; } = false;

        public override bool SupportAspNetCore { get; } = false;

        public override bool SupportsInterfacesOnly { get; } = true;

        public override bool SupportsConditional { get; } = true;

        public override object Resolve(Type type) => FScope.Get(type);

        public override void Dispose()
        {
            FScope?.Dispose();
            FScope = null;

            FScopeFactory?.Dispose();
            FScopeFactory = null;
        }

        public override void Prepare()
        {
            FScopeFactory = ScopeFactory.Create((IServiceCollection svcs) =>
            {
                RegisterBasic(svcs);
                RegisterPropertyInjection(svcs);
                RegisterGeneric(svcs);
                RegisterInterceptor(svcs);
                RegisterMultiple(svcs);
            });
            FScope = FScopeFactory.CreateScope();
        }

        public override void PrepareBasic()
        {
            FScopeFactory = ScopeFactory.Create(RegisterBasic);
            FScope = FScopeFactory.CreateScope();
        }

        private static void RegisterBasic(IServiceCollection svcs)
        {
            RegisterDummies(svcs);
            RegisterStandard(svcs);
            RegisterComplex(svcs);
        }

        private static void RegisterDummies(IServiceCollection svcs) => svcs
            .Service<IDummyOne, DummyOne>(Lifetime.Transient)
            .Service<IDummyTwo, DummyTwo>(Lifetime.Transient)
            .Service<IDummyThree, DummyThree>(Lifetime.Transient)
            .Service<IDummyFour, DummyFour>(Lifetime.Transient)
            .Service<IDummyFive, DummyFive>(Lifetime.Transient)
            .Service<IDummySix, DummySix>(Lifetime.Transient)
            .Service<IDummySeven, DummySeven>(Lifetime.Transient)
            .Service<IDummyEight, DummyEight>(Lifetime.Transient)
            .Service<IDummyNine, DummyNine>(Lifetime.Transient)
            .Service<IDummyTen, DummyTen>(Lifetime.Transient);

        private static void RegisterStandard(IServiceCollection svcs) => svcs
            .Service<ISingleton1, Singleton1>(Lifetime.Singleton)
            .Service<ISingleton2, Singleton2>(Lifetime.Singleton)
            .Service<ISingleton3, Singleton3>(Lifetime.Singleton)
            .Service<ITransient1, Transient1>(Lifetime.Transient)
            .Service<ITransient2, Transient2>(Lifetime.Transient)
            .Service<ITransient3, Transient3>(Lifetime.Transient)
            .Service<ICombined1, Combined1>(Lifetime.Transient)
            .Service<ICombined2, Combined2>(Lifetime.Transient)
            .Service<ICombined3, Combined3>(Lifetime.Transient);

        private static void RegisterComplex(IServiceCollection svcs) => svcs
            .Service<IFirstService, FirstService>(Lifetime.Singleton)
            .Service<ISecondService, SecondService>(Lifetime.Singleton)
            .Service<IThirdService, ThirdService>(Lifetime.Singleton)
            .Service<ISubObjectOne, SubObjectOne>(Lifetime.Transient)
            .Service<ISubObjectTwo, SubObjectTwo>(Lifetime.Transient)
            .Service<ISubObjectThree, SubObjectThree>(Lifetime.Transient)
            .Service<IComplex1, Complex1>(Lifetime.Transient)
            .Service<IComplex2, Complex2>(Lifetime.Transient)
            .Service<IComplex3, Complex3>(Lifetime.Transient);

        private static void RegisterPropertyInjection(IServiceCollection svcs) => svcs
            .Service<IServiceA, ServiceA>(Lifetime.Singleton)
            .Service<IServiceB, ServiceB>(Lifetime.Singleton)
            .Service<IServiceC, ServiceC>(Lifetime.Singleton)
            .Service<ISubObjectA, SubObjectA>(Lifetime.Transient)
            .Service<ISubObjectB, SubObjectB>(Lifetime.Transient)
            .Service<ISubObjectC, SubObjectC>(Lifetime.Transient)
            .Service<IComplexPropertyObject1, ComplexPropertyObject1>(Lifetime.Transient)
            .Service<IComplexPropertyObject2, ComplexPropertyObject2>(Lifetime.Transient)
            .Service<IComplexPropertyObject3, ComplexPropertyObject3>(Lifetime.Transient);

        private static void RegisterMultiple(IServiceCollection svcs) => svcs
            .Service<ISimpleAdapter, SimpleAdapterOne>(1.ToString(), Lifetime.Transient)
            .Service<ISimpleAdapter, SimpleAdapterTwo>(2.ToString(), Lifetime.Transient)
            .Service<ISimpleAdapter, SimpleAdapterThree>(3.ToString(), Lifetime.Transient)
            .Service<ISimpleAdapter, SimpleAdapterFour>(4.ToString(), Lifetime.Transient)
            .Service<ISimpleAdapter, SimpleAdapterFive>(5.ToString(), Lifetime.Transient)
            .Service<IImportMultiple1, ImportMultiple1>(Lifetime.Transient)
            .Service<IImportMultiple2, ImportMultiple2>(Lifetime.Transient)
            .Service<IImportMultiple3, ImportMultiple3>(Lifetime.Transient);

        private static void RegisterConditional(IServiceCollection svcs) => svcs
            .Service<IExportConditionInterface, ExportConditionalObject1>(nameof(ExportConditionalObject1), Lifetime.Transient)
            .Service<IExportConditionInterface, ExportConditionalObject2>(nameof(ExportConditionalObject2), Lifetime.Transient)
            .Service<IExportConditionInterface, ExportConditionalObject3>(nameof(ExportConditionalObject3), Lifetime.Transient)
            .Service<IImportConditionObject1, ImportConditionObject1>(Lifetime.Transient)
            .Service<IImportConditionObject2, ImportConditionObject2>(Lifetime.Transient)
            .Service<IImportConditionObject3, ImportConditionObject3>(Lifetime.Transient);

        private static void RegisterGeneric(IServiceCollection svcs) => svcs
            .Service(typeof(IGenericInterface<>), typeof(GenericExport<>), Lifetime.Transient)
            .Service(typeof(IImportGeneric<>), typeof(ImportGeneric<>), Lifetime.Transient);

        private static void RegisterInterceptor(IServiceCollection svcs) => svcs
            .Service<ICalculator1, Calculator1>(Lifetime.Transient)
            .Service<ICalculator2, Calculator2>(Lifetime.Transient)
            .Service<ICalculator3, Calculator3>(Lifetime.Transient);
    }
}