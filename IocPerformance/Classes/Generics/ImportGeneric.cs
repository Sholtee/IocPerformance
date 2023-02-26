using IocPerformance.Classes.Generics;
using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Generics
{
    public interface IImportGeneric<T> { }

    [Export(typeof(ImportGeneric<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ImportGeneric<>))]
    public class ImportGeneric<T>: IImportGeneric<T>
    {
        protected static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public ImportGeneric(IGenericInterface<T> importGenericInterface)
        {
            if (importGenericInterface == null)
            {
                throw new ArgumentNullException(nameof(importGenericInterface));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ImportGeneric()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
