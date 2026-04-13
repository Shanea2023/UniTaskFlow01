using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System;
using UniTaskFlow01.Module.BusinessObjects;

// If your OfficeTask is in a specific namespace, you might need to add it here, 
// e.g., using UniTaskFlow01.Module.BusinessObjects;

namespace UniTaskFlow01.Module.Controllers
{
    public class TaskActionsController : ViewController
    {
        public TaskActionsController()
        {
            // 1. Tell the button to ONLY show up when looking at OfficeTasks
            TargetObjectType = typeof(OfficeTask);

            // 2. Create the physical button
            SimpleAction completeTaskAction = new SimpleAction(this, "CompleteTask", PredefinedCategory.Edit)
            {
                Caption = "Mark as Complete",

                // We can reuse that awesome green checkmark icon you found earlier!
                ImageName = "State_Task_Completed",

                // This ensures the button only lights up when the user clicks on exactly ONE task
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            };

            // 3. Tell the application what method to run when the button is clicked
            completeTaskAction.Execute += CompleteTaskAction_Execute;
        }

        private void CompleteTaskAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            // Get the specific task the user currently has selected
            OfficeTask selectedTask = (OfficeTask)e.CurrentObject;

            // Change its status to your Completed enum value 
            selectedTask.Status = UniTaskFlow01.Module.BusinessObjects.TaskStatus.Completed;

            // Save the change to the database automatically
            ObjectSpace.CommitChanges();

            // Refresh the screen so the user sees the task jump to the Completed group!
            View.Refresh();
        }
    }
}