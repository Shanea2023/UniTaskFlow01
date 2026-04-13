using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using UniTaskFlow01.Module.BusinessObjects;

namespace UniTaskFlow01.Module.Controllers
{
    public class TaskGeneratorController : ObjectViewController<DetailView, OfficeTask>
    {
        private SimpleAction generateSubTasksAction;

        public TaskGeneratorController()
        {
            // This creates the button on your Task screen
            generateSubTasksAction = new SimpleAction(this, "GenerateSubTasks", PredefinedCategory.Edit)
            {
                Caption = "Auto-Generate Sub-Tasks",
                ConfirmationMessage = "Do you want AI to generate a checklist for this task?",
                ImageName = "Action_LogOptimization"
            };
            generateSubTasksAction.Execute += GenerateSubTasksAction_Execute;
        }

        private async void GenerateSubTasksAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var currentTask = ViewCurrentObject;

            // Safety check: Don't run if the task has no Title
            if (currentTask == null || string.IsNullOrEmpty(currentTask.Title))
            {
                Application.ShowViewStrategy.ShowMessage("Please enter a Task Title first!", InformationType.Error);
                return;
            }

            // 1. Prepare the prompt for Gemini
            string prompt = $"I have a task called '{currentTask.Title}'. " +
                            $"Provide a list of 4 short sub-tasks to complete this. " +
                            $"Return ONLY the task names, one per line, no numbers, no bullets.";

            try
            {
                // 2. Call the AI method ALREADY inside your OfficeTask class
                // We use 'await' because API calls take a few seconds
                string response = await currentTask.GetAiResponse(prompt);

                // 3. Split the response into individual lines
                string[] lines = response.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    // 4. Create a new SubTask record in the database
                    var subTask = ObjectSpace.CreateObject<SubTask>();
                    subTask.Title = line.Trim();
                    subTask.MainTask = currentTask; // Connects it to this specific task
                }

                // 5. Save changes and refresh the UI so the user sees the new items
                ObjectSpace.CommitChanges();
                View.ObjectSpace.Refresh();

                Application.ShowViewStrategy.ShowMessage("AI successfully generated sub-tasks!", InformationType.Success);
            }
            catch (Exception ex)
            {
                Application.ShowViewStrategy.ShowMessage("AI Error: " + ex.Message, InformationType.Error);
            }
        }
    }
}