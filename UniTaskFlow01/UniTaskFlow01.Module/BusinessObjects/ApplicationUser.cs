using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultProperty(nameof(UserName))]
    [CurrentUserDisplayImage(nameof(ProfilePicture))]
    public class ApplicationUser : PermissionPolicyUser, ISecurityUserWithLoginInfo, ISecurityUserLockout
    {
        public ApplicationUser() : base() { }

        public virtual Department Department { get; set; }

        // CHANGED: Set to byte[] to perfectly match your AddProfilePicture migration!
        [ImageEditor(ListViewImageEditorCustomHeight = 40, DetailViewImageEditorFixedHeight = 40)]
        public virtual byte[] ProfilePicture { get; set; }

        // Lockout Implementation
        [Browsable(false)]
        public virtual int AccessFailedCount { get; set; }

        [Browsable(false)]
        public virtual DateTime LockoutEnd { get; set; }

        [Browsable(false)]
        public virtual IList<ApplicationUserLoginInfo> LoginInfo { get; set; } = new ObservableCollection<ApplicationUserLoginInfo>();

        IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

        ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey)
        {
            ApplicationUserLoginInfo result = ((IObjectSpaceLink)this).ObjectSpace.CreateObject<ApplicationUserLoginInfo>();
            result.LoginProviderName = loginProviderName;
            result.ProviderUserKey = providerUserKey;
            result.User = this;
            return result;
        }
    }
}