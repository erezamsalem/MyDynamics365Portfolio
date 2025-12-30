using System;
using Microsoft.Xrm.Sdk;

namespace MyPlugins
{
    public class HelloWorld : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // 1. Get the Context (Data regarding the event)
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // 2. Get the Entity (The record being created)
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity entity = (Entity)context.InputParameters["Target"];

                // 3. Check if we are creating a Contact
                if (entity.LogicalName != "contact") return;

                // 4. Set the "Personal Notes" (description) field to "Hello World"
                entity["description"] = "Hello world";
            }
        }
    }
}