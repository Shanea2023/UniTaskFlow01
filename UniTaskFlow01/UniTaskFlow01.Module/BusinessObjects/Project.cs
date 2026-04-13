using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniTaskFlow01.Module.BusinessObjects
{
    public enum ProjectStatus { Active, OnHold, Completed }

    [DefaultClassOptions]
    [NavigationItem("Organization")]
    public class Project : BaseObject
    {
        [RuleRequiredField]
        public virtual string Name { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public virtual string Description { get; set; }

        public virtual DateTime? Deadline { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public virtual decimal Budget { get; set; }
        public virtual ProjectStatus Status { get; set; }

        // --- RELATIONSHIPS ---
        public virtual Department Department { get; set; }
        public virtual IList<OfficeTask> Tasks { get; set; } = new ObservableCollection<OfficeTask>();
    }
}