using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query; // Required for QueryExpression

namespace MyPlugins
{
    public class DuplicateCheck : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // 1. Get Context and Service
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            // 2. Check Target
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity entity = (Entity)context.InputParameters["Target"];

                // 3. Check if the user is submitting an Email Address
                // "emailaddress1" is the database name for the Email field
                if (entity.Attributes.Contains("emailaddress1"))
                {
                    string newEmail = entity["emailaddress1"].ToString();

                    // 4. Query the Database
                    // "Go look in the Contact table for any record where emailaddress1 equals this new email"
                    QueryExpression query = new QueryExpression("contact");
                    query.ColumnSet = new ColumnSet("emailaddress1"); // We only need to retrieve the email column
                    query.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, newEmail);

                    EntityCollection results = service.RetrieveMultiple(query);

                    // 5. Evaluate Results
                    // If we found 1 or more records, it means a duplicate exists.
                    if (results.Entities.Count > 0)
                    {
                        throw new InvalidPluginExecutionException("Business Process Error: A contact with this email already exists!");
                    }
                }
            }
        }
    }
}