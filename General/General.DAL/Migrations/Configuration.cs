namespace General.DAL.Migrations
{
    using General.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<General.DAL.GeneralDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(General.DAL.GeneralDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Set<SystemButton>().AddOrUpdate(
            //    new SystemButton
            //    {
            //        Title = "添加",
            //        ButtonCode = "Button_Add",
            //        Description = "添加按钮",
            //        Id = "201500000000000000000B0"
            //    }, new SystemButton
            //    {
            //        Title = "编辑",
            //        ButtonCode = "Button_Edit",
            //        Description = "修改、编辑按钮",
            //        Id = "201500000000000000000B1"
            //    }, new SystemButton
            //    {
            //        Title = "删除",
            //        ButtonCode = "Button_Del",
            //        Description = "删除按钮",
            //        Id = "201500000000000000000B2"
            //    }, new SystemButton
            //    {
            //        Title = "导入Excel",
            //        ButtonCode = "Button_ImportExcel",
            //        Description = "导入Excel按钮",
            //        Id = "201500000000000000000B3"
            //    }, new SystemButton
            //    {
            //        Title = "导出Excel",
            //        ButtonCode = "Button_ExportExcel",
            //        Description = "添加按钮，添加操作",
            //        Id = "201500000000000000000B4"
            //    }, new SystemButton
            //    {
            //        Title = "下载",
            //        ButtonCode = "Button_Download",
            //        Description = "下载按钮，下载模版",
            //        Id = "201500000000000000000B5"
            //    });

            context.Set<SystemRole>().AddOrUpdate(new SystemRole
            {
                RoleName = "系统超级管理员",
                Description = "系统权限最高的角色",
                Id = "201500000000000000000R1",
                Depth = 1,
                Path = "201500000000000000000R1,",
            });

            base.Seed(context);
        }
    }
}
