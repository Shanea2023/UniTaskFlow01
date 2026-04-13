using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl.EF;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    // ADDED ISupportNotifications here:
    public class SchedulerEvent : BaseObject, IEvent, ISupportNotifications
    {
        public virtual string Subject { get; set; }
        public virtual string Description { get; set; }

        public virtual DateTime StartOn { get; set; }
        public virtual DateTime EndOn { get; set; }
        public virtual bool AllDay { get; set; }
        public virtual string Location { get; set; }

        public virtual int Label { get; set; }
        public virtual int Status { get; set; }
        public virtual int Type { get; set; }

        [NotMapped]
        [Browsable(false)]
        public virtual string ResourceId { get; set; }

        [NotMapped]
        [Browsable(false)]
        public virtual object AppointmentId
        {
            get { return ID; }
        }

        // --- REQUIRED FOR NOTIFICATIONS ---
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
            get { return $"Event: {Subject}"; }
        }
    }
}