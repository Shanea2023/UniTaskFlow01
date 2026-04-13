using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTaskFlow01.Module.BusinessObjects;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Organization")]
    public class Department : BaseObject
    {
        public virtual string Name { get; set; }
        public virtual string OfficeRoomNumber { get; set; }

        // Relationship: One Department has many Staff Members
        public virtual IList<ApplicationUser> StaffMembers { get; set; } = new ObservableCollection<ApplicationUser>();
    

        // Relationship: One Department can have many Tasks (Like ClickUp "Spaces")
        public virtual IList<OfficeTask> DepartmentTasks { get; set; } = new ObservableCollection<OfficeTask>();
    }
}
