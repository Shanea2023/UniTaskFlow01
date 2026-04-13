using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Settings")]
    public class TaskTag : BaseObject
    {
        [RuleRequiredField]
        public virtual string Name { get; set; }

        public virtual string ColorCode { get; set; }

        // --- RELATIONSHIPS ---
        public virtual IList<OfficeTask> Tasks { get; set; } = new ObservableCollection<OfficeTask>();
    }
}