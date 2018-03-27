using System.Collections.Generic;
using System.Data;

namespace 数据采集档案管理系统___课题版
{
    /// <summary>
    /// 当前操作对象类型
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,
        /// <summary>
        /// 计划
        /// </summary>
        Plan = 1,
        /// <summary>
        /// 项目
        /// </summary>
        Plan_Project = 2,
        /// <summary>
        /// 课题
        /// </summary>
        Plan_Topic = 3,
        /// <summary>
        /// 子课题
        /// </summary>
        Plan_Topic_Subject = 4,
    }
    /// <summary>
    /// 数据库字典帮助类
    /// </summary>
    class DictionaryHelper
    {
        /// <summary>
        /// 根据编码获取其下的数据的id和name属性
        /// </summary>
        /// <param name="parentCode">父节点Code</param>
        public static List<object[]> GetValuesByCode(object parentCode)
        {
            object parentId = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_id FROM data_dictionary WHERE dd_code = '{parentCode}'");
            return SQLiteHelper.ExecuteColumnsQuery($"SELECT dd_id, dd_name FROM data_dictionary WHERE dd_pId='{parentId}' ORDER BY dd_sort", 2);
        }

        /// <summary>
        /// 根据编码获取其下的数据表格
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public static DataTable GetTableByCode(object parentCode)
        {
            object parentId = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_id FROM data_dictionary WHERE dd_code = '{parentCode}'");
            return SQLiteHelper.ExecuteQuery($"SELECT * FROM data_dictionary WHERE dd_pId='{parentId}' ORDER BY dd_sort");
        }
    }
}
