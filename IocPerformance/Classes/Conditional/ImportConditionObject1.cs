using System;
using System.ComponentModel.Composition;
using ZenIoc;
using Solti.Utils.DI.Interfaces;

namespace IocPerformance.Classes.Conditions
{
    public interface IImportConditionObject1 { }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ImportConditionObject1: IImportConditionObject1
    {
        private static int counter;

        public ImportConditionObject1(
            [ResolveNamed("ExportConditionalObject1")][Options(Name = "ExportConditionalObject1")] IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException(nameof(exportConditionInterface));
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject1))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject1 got: " + exportConditionInterface.GetType().FullName,
nameof(exportConditionInterface));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
