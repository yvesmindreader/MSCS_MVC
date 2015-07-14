using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.Helpers;
using MSCS_MVC.Weixin;
namespace MSCS_MVC.Controllers
{

    public class WeChatController : Controller
    {
       public readonly string Token = "weixin";//与微信公众账号后台的Token设置保持一致，区分大小写。
       public static readonly string EncodingAESKey = "NQY6q5qsK0zipfCAyz2E4RxADiydBp9HgFeWsknljtd";
       public static readonly string AppId = "wx7d8ec4d26cc5d27d";
           
           
           /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content("参数错误！");
            }

            postModel.Token = Token;
            postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = AppId;//根据自己后台的设置保持一致

            var messageHandler = new CustomMessageHandler(Request.InputStream, postModel);//接收消息

            messageHandler.Execute();//执行微信处理过程

            return new WeixinResult(messageHandler);//返回结果
        }
    }
}