﻿using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Conditions;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Conditional_08_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsConditional;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            if (container.SupportsInterfacesOnly)
            {
                var importConditionObject1 = (IImportConditionObject1)container.Resolve(typeof(IImportConditionObject1));
                var importConditionObject2 = (IImportConditionObject2)container.Resolve(typeof(IImportConditionObject2));
                var importConditionObject3 = (IImportConditionObject3)container.Resolve(typeof(IImportConditionObject3));
            }
            else
            {
                var importConditionObject1 = (ImportConditionObject1)container.Resolve(typeof(ImportConditionObject1));
                var importConditionObject2 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));
                var importConditionObject3 = (ImportConditionObject3)container.Resolve(typeof(ImportConditionObject3));
            }
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsConditional)
            {
                return;
            }

            if (ImportConditionObject1.Instances != this.LoopCount
                || ImportConditionObject2.Instances != this.LoopCount
                || ImportConditionObject3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("ImportConditionObject count must be {0}", this.LoopCount));
            }
        }
    }
}