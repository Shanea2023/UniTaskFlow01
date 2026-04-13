using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Collaboration")]
    public class TaskComment : BaseObject
    {
        [RuleRequiredField]
        [FieldSize(FieldSizeAttribute.Unlimited)]
        public virtual string Text { get; set; }

        public virtual DateTime DatePosted { get; set; } = DateTime.Now;

        // --- RELATIONSHIPS ---
        public virtual ApplicationUser Author { get; set; }
        public virtual OfficeTask Task { get; set; }
    }
}