namespace 数据采集档案管理系统___课题版
{
    class UserHelper
    {
        private static User user;

        public static User GetUser()
        {
            if(user == null)
                user = new User();
            return user;
        }
    }
    class User
    {
        private object userId;
        private string userName;
        private string realName;
        private string passWord;
        private string userUnitId;
        private string userUnitName;
        private string userSpecialId;
        /// <summary>
        /// 用户ID
        /// </summary>
        public object UserId { get => userId; set => userId = value; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserName { get => userName; set => userName = value; }
        /// <summary>
        /// 用户所属单位ID
        /// </summary>
        public string UserUnitId { get => userUnitId; set => userUnitId = value; }
        /// <summary>
        /// 用户所属专项ID
        /// </summary>
        public string UserSpecialId { get => userSpecialId; set => userSpecialId = value; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get => realName; set => realName = value; }
        /// <summary>
        /// 用户所属单位名称
        /// </summary>
        public string UserUnitName { get => userUnitName; set => userUnitName = value; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get => passWord; set => passWord = value; }
    }
}
