﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Senparc.Weixin.MP.AppStore
{
    public class OAuthAccountInfo
    {
        //public int user_id { get; set; }
        //public int user_name { get; set; }
        public int weixin_id { get; set; }
        public string weixin_name { get; set; }
    }

    /// <summary>
    /// 获取OAuth AccessToken的结果
    /// 如果错误，返回结果{"errcode":40029,"errmsg":"invalid code"}
    /// </summary>
    public class OAuthAccessTokenResult : WxJsonResult
    {
        private int _expiresIn;


        //以下看似不符合C#规范的命名方式参考微信的OAUTH
        public string access_token { get; set; }

        public int expires_in
        {
            get { return _expiresIn; }
            set
            {
                _expiresIn = value;
                ExpireTimeTicks = DateTime.Now.AddSeconds(expires_in).Ticks;
            }
        }

        public string refresh_token { get; set; }
        public OAuthAccountInfo account_info { get; set; }

        /// <summary>
        /// 过期时间Ticks
        /// </summary>
        public long ExpireTimeTicks { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireTime
        {
            get
            {
                return new DateTime(ExpireTimeTicks);
            }
        }
    }
}