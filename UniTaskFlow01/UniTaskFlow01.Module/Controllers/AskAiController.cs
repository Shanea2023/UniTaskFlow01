using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using UniTaskFlow01.Module.BusinessObjects;

namespace UniTaskFlow01.Module.Controllers
{
    // NEW: Changed to ViewController so we can read the data on the current screen
    public class AskAiController : ViewController
    {
        public AskAiController()
        {
            PopupWindowShowAction askAiAction = new PopupWindowShowAction(this, "AskAiAction", DevExpress.Persistent.Base.PredefinedCategory.View)
            {
                Caption = "Ask AI",
                ImageName = "Office2013_InitialState"
            };

            askAiAction.CustomizePopupWindowParams += AskAiAction_CustomizePopupWindowParams;
            askAiAction.Execute += AskAiAction_Execute;
        }

        private void AskAiAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(AskAiDialog));
            AskAiDialog dialog = objectSpace.CreateObject<AskAiDialog>();
            dialog.AiResponse = "Type a question and click 'OK' to talk to Gemini!";
            e.View = Application.CreateDetailView(objectSpace, dialog);
        }

        private async void AskAiAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.CanCloseWindow = false;
            AskAiDialog dialog = (AskAiDialog)e.PopupWindowViewCurrentObject;
            string userQuestion = dialog.Question;

            if (string.IsNullOrWhiteSpace(userQuestion))
            {
                dialog.AiResponse = "Please enter a question first.";
                e.PopupWindowView.Refresh();
                return;
            }

            try
            {
                dialog.AiResponse = "Thinking...";
                e.PopupWindowView.Refresh();

                // ---- NEW: GIVE THE AI "EYES" ----
                string taskContext = "The user is looking at a general screen or a list of items.";

                // Check if the screen the user is currently looking at is a specific OfficeTask!
                if (View.CurrentObject is OfficeTask currentTask)
                {
                    // If it is, grab all the details from the screen and hide them in the prompt
                    taskContext = $@"
                    The user is currently viewing a specific task in the database. 
                    Task Subject: {currentTask.Title}
                    Task Description: {currentTask.Description}
                    Task Status: {currentTask.Status}
                    ";

                    /* NOTE: If you named your properties differently in OfficeTask.cs 
                       (like 'Title' instead of 'Subject'), change the words above to match! */
                }
                // ----------------------------------

                string currentDate = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

                // We combine the Date, the Task Context, and the User's Question into one massive prompt
                string secretSystemPrompt = $"System Context: Today's date is {currentDate}. {taskContext}\n\nPlease answer the user's question accurately based on the context provided if relevant. \n\nUser Question: {userQuestion}";

                string apiKey = "AIzaSyAun6dtJAeHxi7RMwp1qN91mKVT321YBjc";
                string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

                var payload = new
                {
                    contents = new[]
                    {
                        new { parts = new[] { new { text = secretSystemPrompt } } }
                    }
                };

                string jsonPayload = JsonSerializer.Serialize(payload);
                using HttpClient client = new HttpClient();
                StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(responseJson);

                string aiAnswer = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                dialog.AiResponse = aiAnswer;
                e.PopupWindowView.Refresh();
            }
            catch (Exception ex)
            {
                dialog.AiResponse = "AI Error: " + ex.Message;
                e.PopupWindowView.Refresh();
            }
        }
    }
}