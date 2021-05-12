using CC.Yi.Model;
using System;

namespace CC.Yi.Common
{
    public static class JsonHelper
    {
        public static string JsonToString(object data,int code=200,bool flag=true,string message="成功")
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { code=code,flag=flag,message=message,data=data});
        }
        public static string ToString(object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        public static info_user ToUser(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<info_user>(data);
        }
    }
}
