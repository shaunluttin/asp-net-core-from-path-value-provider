using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreUriToAssoc
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, 
        AllowMultiple = false, Inherited = true)]
    public class FromPath : Attribute, IBindingSourceMetadata, IModelNameProvider
    {
        /// <inheritdoc />
        public BindingSource BindingSource => BindingSource.Custom;

        /// <inheritdoc />
        public string Name { get; set; }
    }
}
