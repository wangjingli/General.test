using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace General.DAL
{
    /// <summary>
    ///   泛型数据访问接口基类
    /// </summary>
    /// <typeparam name="T">实体对象</typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// 根据指定条件查询实体
        /// </summary>
        /// <param name="predicate">where条件</param>
        /// <returns>返回：实体数据集合</returns>
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 根据唯一键 查询实体
        /// </summary>
        /// <param name="Id">主键、唯一键，ID</param>
        /// <returns>返回：实体数据</returns>
        T GetKey(string Id);
        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns>返回：所有实体数据集合</returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// 添加 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        void Add(T entityObject);
        /// <summary>
        /// 编辑/修改 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        void Edit(T entityObject);
        /// <summary>
        /// 删除 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        void Delete(T entityObject);
        /// <summary>
        /// 更新指定字段
        /// </summary>
        /// <param name="entityObject">待更新的实体</param>
        /// <param name="properties">待更新的字段</param>
        void Update(T entityObject, params Expression<Func<T, object>>[] properties);
        /// <summary>
        /// 提交/保存 变更到数据库
        /// </summary>
        void Save();
        /// <summary>
        /// 不校验正确性 提交/保存 变更到数据库
        /// </summary>
        void SaveWithoutVerification();
        /// <summary>
        /// 批量删除 实体数据
        /// </summary>
        /// <param name="dataList">实体数据</param>
        void RemoveRange(IEnumerable<T> dataList);
        /// <summary>
        /// 批量添加 实体数据
        /// </summary>
        /// <param name="dataList">实体数据集合</param>
        void AddRange(IEnumerable<T> dataList);




    }
}
