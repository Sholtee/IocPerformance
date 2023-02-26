using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Multiple;

namespace IocPerformance.Benchmarks.Advanced
{
    public class IEnumerable_07_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsMultiple;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            if (container.SupportsInterfacesOnly)
            {
                var importMultiple1 = (IImportMultiple1)container.Resolve(typeof(IImportMultiple1));
                var importMultiple2 = (IImportMultiple2)container.Resolve(typeof(IImportMultiple2));
                var importMultiple3 = (IImportMultiple3)container.Resolve(typeof(IImportMultiple3));
            }
            else
            {
                var importMultiple1 = (ImportMultiple1)container.Resolve(typeof(ImportMultiple1));
                var importMultiple2 = (ImportMultiple2)container.Resolve(typeof(ImportMultiple2));
                var importMultiple3 = (ImportMultiple3)container.Resolve(typeof(ImportMultiple3));
            }
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsMultiple)
            {
                return;
            }

            if (ImportMultiple1.Instances != this.LoopCount
                || ImportMultiple2.Instances != this.LoopCount
                || ImportMultiple3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("ImportMultiple count must be {0}", this.LoopCount));
            }
        }
    }
}