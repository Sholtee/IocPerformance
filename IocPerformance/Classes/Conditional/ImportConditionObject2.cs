using System;
using System.ComponentModel.Composition;
using ZenIoc;
using Solti.Utils.DI.Interfaces;

namespace IocPerformance.Classes.Conditions
{
    public interface IImportConditionObject2 { }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ImportConditionObject2: IImportConditionObject2
    {
        private static int counter;

        public ImportConditionObject2([ResolveNamed("ExportConditionalObject2")][Options(Name = "ExportConditionalObject2")] IExportConditionInterface exportConditionInterface)
        {
            if (exportConditionInterface == null)
            {
                throw new ArgumentNullException(nameof(exportConditionInterface));
            }

            if (exportConditionInterface.GetType() != typeof(ExportConditionalObject2))
            {
                throw new ArgumentException(
                    "Should have imported ExportConditionalObject2 got: " + exportConditionInterface.GetType().FullName,
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
