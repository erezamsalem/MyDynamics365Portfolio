using System;
using System.Activities; // Required for Workflows
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow; // Required for Input/Output arguments

namespace MyCustomWorkflows
{
    public class GetTaxWorkflow : CodeActivity
    {
        // 1. Define INPUT (What the user types in the Workflow Step)
        [Input("Configuration Key (e.g., USA, UK)")]
        public InArgument<string> Key { get; set; }

        // 2. Define OUTPUT (What the Workflow gives back)
        [Output("Tax Value")]
        public OutArgument<string> Tax { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            // 3. Get the Tracing Service
            ITracingService tracingService = context.GetExtension<ITracingService>();
            tracingService.Trace("Workflow Started...");

            // 4. Get the Input Value user provided
            string keyData = Key.Get(context);

            // 5. YOUR LOGIC HERE
            // (The tutorial queries a database table, but let's use simple logic first 
            // so you can test it immediately without creating extra tables).

            string result = "0";

            if (keyData == "USA")
            {
                result = "10%";
            }
            else if (keyData == "UK")
            {
                result = "20%";
            }
            else
            {
                result = "5%";
            }

            // 6. Send the Result back to Dynamics
            Tax.Set(context, result);
        }
    }
}