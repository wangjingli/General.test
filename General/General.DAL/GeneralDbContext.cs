using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using General.Model;

namespace General.DAL
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class GeneralDbContext : DbContext
    {
        /// <summary>
        /// 账户
        /// </summary>
        public DbSet<Account> Account { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }
        /// <summary>
        /// 系统菜单
        /// </summary>
        public DbSet<SystemMenu> SystemMenu { get; set; }
        /// <summary>
        /// 系统角色
        /// </summary>
        public DbSet<SystemRole> SystemRole { get; set; }
        /// <summary>
        /// 系统按钮
        /// </summary>
        public DbSet<SystemButton> SystemButton { get; set; }

        /// <summary>
        /// 默认构造函数 
        /// 连接数据库 昵称：DefaultConnection
        /// </summary>
        public GeneralDbContext()
            : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }
        /// <summary>
        /// 模型生成事件 ，修改数据表的名称
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Where(c => c.Name.ToLower() != "contactway").Configure(e => e.ToTable(e.ClrType.Name));
            base.OnModelCreating(modelBuilder);
        }
    }
}
