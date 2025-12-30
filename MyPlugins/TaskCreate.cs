using System;
using Microsoft.Xrm.Sdk;

namespace MyPlugins
{
    public class TaskCreate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // 1. Obtain the execution context
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // 2. Obtain the Organization Service (Required to CREATE data)
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            // 3. Check if the InputParameters contains a target
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                // Get the Contact entity that caused this plugin to run
                Entity contactEntity = (Entity)context.InputParameters["Target"];

                try
                {
                    // 4. Define the New Task
                    Entity taskRecord = new Entity("task");

                    // Set the Subject and Description
                    taskRecord["subject"] = "Follow up with new Contact";
                    taskRecord["description"] = "System generated task: Please reach out to this customer.";

                    // Set the Due Date (2 days from now)
                    taskRecord["scheduledend"] = DateTime.Now.AddDays(2);

                    // Set Priority to High (1 = Normal, 2 = High)
                    taskRecord["prioritycode"] = new OptionSetValue(2);

                    // 5. LINK THE TASK TO THE CONTACT (Crucial Step)
                    // We create a reference to the Contact that was just created.
                    // We use contactEntity.Id to grab the GUID of the new record.
                    if (context.OutputParameters.Contains("id"))
                    {
                        Guid contactId = new Guid(context.OutputParameters["id"].ToString());
                        taskRecord["regardingobjectid"] = new EntityReference("contact", contactId);
                    }
                    else
                    {
                        // Fallback for Sync plugins where ID is in the Target
                        taskRecord["regardingobjectid"] = new EntityReference("contact", contactEntity.Id);
                    }

                    // 6. Create the Task in the Database
                    service.Create(taskRecord);
                }
                catch (Exception ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred creating the task: " + ex.Message);
                }
            }
        }
    }
}