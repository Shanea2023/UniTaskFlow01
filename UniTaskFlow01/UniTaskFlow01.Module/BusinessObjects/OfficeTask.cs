using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniTaskFlow01.Module.BusinessObjects
{
    public enum TaskPriority
    {
        Low = 0,
        Normal = 1,
        High = 2,
        Critical = 3
    }

    public enum TaskStatus
    {
        [ImageName("State_Task_NotStarted")]
        Draft = 0,
        [ImageName("BO_User")]
        Assigned = 1,
        [ImageName("State_Task_InProgress")]
        InProgress = 2,
        [ImageName("Action_About")]
        UnderReview = 3,
        [ImageName("State_Task_Completed")]
        Completed = 4,
        [ImageName("State_Task_Deferred")]
        Deferred = 5
    }

    [DefaultClassOptions]
    [NavigationItem("Tasks")]
    [Appearance("OverdueTask", AppearanceItemType = "ViewItem", TargetItems = "*",
        Criteria = "DueDate < LocalDateTimeToday() and Status != 'Completed'", BackColor = "MistyRose")]
    [Appearance("CompletedTaskGreen", AppearanceItemType = "ViewItem", TargetItems = "Status",
        Criteria = "Status = 4", Context = "ListView", BackColor = "LightGreen", FontColor = "Black")]
    [DevExpress.Persistent.Validation.RuleCriteria("DueDateAfterStartDate",
        DevExpress.Persistent.Validation.DefaultContexts.Save,
        "DueDate >= StartDate",
        CustomMessageTemplate = "Hold on! The Due Date cannot be earlier than the Start Date.")]
    [RuleCriteria("AdminCannotComplete", DefaultContexts.Save,
     "Not (IsCurrentUserInRole('Administrators') And (Status = 'Completed' Or Status = 'InProgress'))",
     CustomMessageTemplate = "Administrators can only Draft or Assign tasks. Only the assigned user can update progress.")]
    public class OfficeTask : BaseObject, ISupportNotifications
    {
        // ---> HIDING THE CUSTOM FIELDS HERE <---
        [Browsable(false)]
        [RuleRequiredField]
        public virtual string Title { get; set; }

        [Browsable(false)]
        public virtual DateTime? StartDate { get; set; }

        [Browsable(false)]
        public virtual DateTime DueDate { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public virtual string Description { get; set; }

        public virtual DateTime? DateCreated { get; set; } = DateTime.Now;

        public virtual TaskPriority Priority { get; set; }

        // --- REQUIRED FOR NOTIFICATIONS ---
        [ModelDefault("EditMask", "g")]
        [ModelDefault("DisplayFormat", "{0:g}")]
        public virtual DateTime? AlarmTime { get; set; }
        public virtual bool IsPostponed { get; set; }

        // --- MISSING NOTIFICATION PROPERTIES ---
        [NotMapped]
        [Browsable(false)]
        public virtual object UniqueId
        {
            get { return ID; }
        }

        [NotMapped]
        [Browsable(false)]
        public virtual string NotificationMessage
        {
            get { return $"Task: {Title}"; }
        }

        public virtual TaskStatus Status { get; set; }

        // --- PARENT RELATIONSHIPS ---
        public virtual ApplicationUser AssignedTo { get; set; }
        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }

        // ---> UN-HIDING THE CALENDAR FIELDS HERE <---
        public virtual DateTime StartOn { get; set; }
        public virtual DateTime EndOn { get; set; }

        // Fixed EF Mapping error for Subject
        [NotMapped]
        public virtual string Subject { get { return Title; } set { Title = value; } }

        public virtual string Location { get; set; }
        public virtual bool AllDay { get; set; }
        public virtual int Label { get; set; }

        [NotMapped]
        [Browsable(false)]
        public virtual object ResourceId { get; set; }

        // --- CHILD RELATIONSHIPS ---
        public virtual IList<TaskComment> Comments { get; set; } = new ObservableCollection<TaskComment>();
        public virtual IList<WorkLog> WorkLogs { get; set; } = new ObservableCollection<WorkLog>();
        public virtual IList<TaskAttachment> Attachments { get; set; } = new ObservableCollection<TaskAttachment>();

        // --- MANY-TO-MANY RELATIONSHIP ---
        public virtual IList<TaskTag> Tags { get; set; } = new ObservableCollection<TaskTag>();

        public virtual DevExpress.Persistent.BaseImpl.EF.FileData Attachment { get; set; }

        public async System.Threading.Tasks.Task<string> GetAiResponse(string prompt)
        {
            try
            {
                // ... your existing API logic ...
            }
            catch (Exception ex)
            {
                return $"Error calling AI: {ex.Message}";
            }
            return "No response received from AI.";
        }
    }
}