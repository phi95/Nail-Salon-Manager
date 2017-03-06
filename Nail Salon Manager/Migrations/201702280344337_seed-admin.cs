namespace Nail_Salon_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedadmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'8ace0dca-6b44-4ced-9107-cc60d0b64c0a', N'admin@nailsalonmanager.com', 0, N'ADA0SSHi6RLT0F1B5lBnYTJtSwcAy3b62PIeT3X4Hm5Udolu4CcBoTT4DoCr0QNOQA==', N'0f4a2888-f4c4-4097-ae82-d4d5f2fa3405', NULL, 0, 0, NULL, 1, 0, N'admin@nailsalonmanager.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a59791d7-a672-4937-b288-79c3343a540b', N'Employer')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ace0dca-6b44-4ced-9107-cc60d0b64c0a', N'a59791d7-a672-4937-b288-79c3343a540b')

            ");
        }

    public override void Down()
        {
        }
    }
}
