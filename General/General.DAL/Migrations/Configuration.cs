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
            //        Title = "���",
            //        ButtonCode = "Button_Add",
            //        Description = "��Ӱ�ť",
            //        Id = "201500000000000000000B0"
            //    }, new SystemButton
            //    {
            //        Title = "�༭",
            //        ButtonCode = "Button_Edit",
            //        Description = "�޸ġ��༭��ť",
            //        Id = "201500000000000000000B1"
            //    }, new SystemButton
            //    {
            //        Title = "ɾ��",
            //        ButtonCode = "Button_Del",
            //        Description = "ɾ����ť",
            //        Id = "201500000000000000000B2"
            //    }, new SystemButton
            //    {
            //        Title = "����Excel",
            //        ButtonCode = "Button_ImportExcel",
            //        Description = "����Excel��ť",
            //        Id = "201500000000000000000B3"
            //    }, new SystemButton
            //    {
            //        Title = "����Excel",
            //        ButtonCode = "Button_ExportExcel",
            //        Description = "��Ӱ�ť����Ӳ���",
            //        Id = "201500000000000000000B4"
            //    }, new SystemButton
            //    {
            //        Title = "����",
            //        ButtonCode = "Button_Download",
            //        Description = "���ذ�ť������ģ��",
            //        Id = "201500000000000000000B5"
            //    });

            context.Set<SystemRole>().AddOrUpdate(new SystemRole
            {
                RoleName = "ϵͳ��������Ա",
                Description = "ϵͳȨ����ߵĽ�ɫ",
                Id = "201500000000000000000R1",
                Depth = 1,
                Path = "201500000000000000000R1,",
            });

            base.Seed(context);
        }
    }
}
