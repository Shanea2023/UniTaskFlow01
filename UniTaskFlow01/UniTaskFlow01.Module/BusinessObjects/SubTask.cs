using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class SubTask : BaseObject
    {
        public virtual string Title { get; set; }
        public virtual bool IsCompleted { get; set; }

        // This links it back to the main Task
        public virtual OfficeTask MainTask { get; set; }
    }
}