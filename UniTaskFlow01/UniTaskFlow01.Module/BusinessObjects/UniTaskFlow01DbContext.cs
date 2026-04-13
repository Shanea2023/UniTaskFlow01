using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.ExpressApp.EFCore.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UniTaskFlow01.Module.BusinessObjects
{
    
    public class UniTaskFlow01EFCoreDbContext : DbContext
    {
        public UniTaskFlow01EFCoreDbContext(DbContextOptions<UniTaskFlow01EFCoreDbContext> options) : base(options)
        {
        }

        public DbSet<DevExpress.Persistent.BaseImpl.EF.FileData> FileData { get; set; }
        //public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<SubTask> SubTasks { get; set; }

        public DbSet<SchedulerEvent> SchedulerEvents { get; set; }
        public DbSet<OfficeTask> OfficeTasks { get; set; }
        // --- NEW CLICKUP FEATURES ---
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }

        // --- SECURITY SYSTEM ---
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationUserLoginInfo> UserLoginInfos { get; set; }
        public DbSet<PermissionPolicyRole> Roles { get; set; }

        // --- FIX FOR THE RED ERROR (Layout Settings) ---
        public DbSet<ModelDifference> ModelDifferences { get; set; }
        public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            // 🔥 VERY IMPORTANT FIX FOR XAF SECURITY
            modelBuilder.HasChangeTrackingStrategy(
                ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues
            );

            // Security: Link LoginInfo to Users
            modelBuilder.Entity<ApplicationUserLoginInfo>(b => {
                b.HasIndex(nameof(ApplicationUserLoginInfo.LoginProviderName),
                           nameof(ApplicationUserLoginInfo.ProviderUserKey))
                 .IsUnique();
            });

            // Relationship: Department -> Staff
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Department)
                .WithMany(d => d.StaffMembers);

            // Relationship: Task -> Assigned User
            modelBuilder.Entity<OfficeTask>()
                .HasOne(t => t.AssignedTo)
                .WithMany();
        }
    }
}
