
using System;
using System.IO;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities.GoogleMap;
using Senparc.Weixin.MP.Entities.BaiduMap;
using System.Collections.Generic;
using Senparc.Weixin.MP.Helpers;

namespace MSCS_MVC.Weixin
{
    public class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        public readonly string AvatarImgUrl = "https://mmbiz.qlogo.cn/mmbiz/ls1wPo07ZdlslAOFrZRFtglwcv8zJ9ht5vuhe1uS3SpbribxCcAYW93c2Mb7pevxXvGu0tb03H8unkzDcBdD4uw/0?wx_fmt=jpeg";
        public CustomMessageHandler(Stream inputStream, PostModel postModel)
            : base(inputStream, postModel)
        {

        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>(); //ResponseMessageText也可以是News等其他类型
            responseMessage.Content = "这条消息来自DefaultResponseMessage。";
            return responseMessage;
        }

        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);

            responseMessage.Articles.Add(new Article()
            {
                Description = string.Format("您刚才发送了地理位置信息。Location_X {0} Location_Y {1} Scale {2} 标签 {3}",
                              requestMessage.Location_X, requestMessage.Location_Y,
                              requestMessage.Scale, requestMessage.Label),
                PicUrl = null,
                Title = "定位地点周边班车点功能开发中",
                Url = "http://cn.bing.com/ditu/default.aspx?v=2&FORM=LMLTCP&cp=31.235775~121.480894&style=r&lvl=14&tilt=-90&dir=0&alt=-1000&phx=0&phy=0&phscl=1&cid=F0B99E6D1EE0EE1F!132&encType=1"
            });

            return responseMessage;
        }
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            string title = "";
            string description = "";
            string picUrl = AvatarImgUrl;
            string newsUrl = "";

            string ret = "";
            bool bNeedSendNews = false;

            switch (requestMessage.Content.ToUpper())
            {
                #region All Round Trip Shuttle bus schedule
                case "RT":
                case "穿梭线路班车":
                    {
                        title = "穿梭线路班车";
                        description = "穿梭线路班车";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204220852&idx=1&sn=47f6173090c52439ca9e76c41af42e57&scene=18#rd";
                    }
                    break;
                case "RT1":
                    {
                        title = "RT1";
                        description = "RT 1: 徐家汇 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204406752&idx=1&sn=8613ea81d96c67a286204a34ff46c5b2#rd";
                    }
                    break;

                case "RT2":
                    {
                        title = "RT2";
                        description = "RT 2: 莲花路地铁站 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204406916&idx=1&sn=bbb962b0e4a8e475cb489bc9ecb54454#rd";
                    }
                    break;
                case "RT3":
                    {
                        title = "RT3";
                        description = "RT 3:  莘庄地铁站  － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204407002&idx=1&sn=222a7445f2d6b47585577429bf64e5d9#rd";
                    }
                    break;
                case "RT4":
                    {
                        title = "RT4";
                        description = "RT4: 东川路地铁站 — 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204407130&idx=1&sn=8fc92288081539a90363fc327f0cd4e7#rd";
                    }
                    break;
                case "RT5":
                    {
                        title = "RT5";
                        description = "RT 5: 沈杜公路地铁站－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204407290&idx=1&sn=4ca1a817071d892b7d8fbec43a601343#rd";
                    }
                    break;
                #endregion RoundTripRoutes

                #region All Weekends and Public Holidy shuttle bus schedule
                case "WH":
                case "周末线路班车及节假日线路班车":
                    {
                        title = "周末线路班车及节假日线路班车";
                        description = "周末线路班车及节假日线路班车";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204219832&idx=1&sn=2944a7bf1d121488797b72bede80e538&scene=18#rd";
                    }
                    break;
                case "WH1":
                    {
                        title = "WH1";
                        description = "WH 1: 徐家汇－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204406546&idx=1&sn=63ca06cddee76d92e3e57b198b96446c#rd";
                    }
                    break;
                case "WH2":
                    {
                        title = "WH2";
                        description = "WH 2: 大柏树－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204406573&idx=1&sn=5941c556eeecd6e9bcfb0f63e327e4ce#rd";
                    }
                    break;
                case "WH3":
                    {
                        title = "WH3";
                        description = "WH 3: 世纪大道地铁站－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204406601&idx=1&sn=111c29be85eb182d3249144f4ac2ea7e#rd";
                    }
                    break;
                #endregion


                #region All Regular shuttle bus schedule
                case "RR":
                case "常规班车线路":
                    {
                        title = "常规班车线路";
                        description = "常规班车线路";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204221666&idx=1&sn=29ca18a9daedb3efc2f0707e0f90ba86&scene=18#rd";
                    }
                    break;

                case "RR1":
                    {
                        title = "RR1";
                        description = "Route 1: 东陆路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204395150&idx=1&sn=e3897f7e44c3cedc4ef5e992086350f9#rd";
                    }
                    break;
                case "RR2":
                    {
                        title = "RR2";
                        description = "Route 2: 栖山路苗圃路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204395180&idx=1&sn=e6e4e2c365c76fdc55b28d455ed806ba#rd";
                    }
                    break;

                case "RR3":
                    {
                        title = "RR3";
                        description = "Route 3: 微软上海园区－东陆路";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204405272&idx=1&sn=271bb2b8a1fb86686803910389208ce3#rd";
                    }
                    break;
                case "RR5":
                    {
                        title = "RR5";
                        description = "Route 5: 东昌路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204405175&idx=1&sn=d7c64140cb434bce35a3e995a144c55d#rd";
                    }
                    break;
                case "RR6":
                    {
                        title = "RR6";
                        description = "Route 6: 明月路白桦路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204405076&idx=1&sn=a52fe083bc92f9b105d64dbd2e808ebc#rd";
                    }
                    break;
                case "RR7":
                    {
                        title = "RR7";
                        description = "Route 7: 世纪公园地铁站－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204405046&idx=1&sn=c1ebd2469faf10ae516fa2949caae5ad#rd";
                    }
                    break;
                case "RR8":
                    {
                        title = "RR8";
                        description = "Route 8:微软上海园区－明月路白桦路";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204405005&idx=1&sn=20616faaa1062d50a41bfb60adad976b#rd";
                    }
                    break;
                case "RR9":
                    {
                        title = "RR9";
                        description = "Route 9: 高科西路东明路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204394923&idx=1&sn=b9cc2d7be2c0b276112b469863115060#rd";
                    }
                    break;
                case "RR10":
                    {
                        title = "RR10";
                        description = "Route 10: 天宝路临平路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404936&idx=1&sn=133892758ca2fa57bf49c78288a1ec9b#rd";
                    }
                    break;
                case "RR11":
                    {
                        title = "RR11";
                        description = "Route 11: 黄兴路抚顺路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404896&idx=1&sn=6227514a14f55c3702dbb2806ac32ed3#rd";
                    }
                    break;
                case "RR12":
                    {
                        title = "RR12";
                        description = "Route 12: 水产西路蕰川公路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404869&idx=1&sn=c9111a3a49a5262998dcf00315a9bc6b#rd";
                    }
                    break;
                case "RR13":
                    {
                        title = "RR13";
                        description = "Route 13: 共和新路延长路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404832&idx=1&sn=638e59161eef65b93bde7ca45399a8d9#rd";
                    }
                    break;
                case "RR14":
                    {
                        title = "RR14";
                        description = "Route 14: 锦秋路（上海大学）－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404784&idx=1&sn=63baa47cbde8792b44933c3c36067537#rd";
                    }
                    break;
                case "RR15":
                    {
                        title = "RR15";
                        description = "Route 15: 白玉路曹杨路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404716&idx=1&sn=73a752bd96126a3fbe79c919c3ab2301#rd";
                    }
                    break;
                case "RR16":
                    {
                        title = "RR16";
                        description = "Route 16: 叶家宅－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404676&idx=1&sn=afdba0e454256021f9e446ca7212de70#rd";
                    }
                    break;
                case "RR17":
                    {
                        title = "RR17";
                        description = "Route 17: 天山路天中路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404658&idx=1&sn=7f8d9ba789d9612101197385efa060cb#rd";
                    }
                    break;
                case "RR18":
                    {
                        title = "RR18";
                        description = "Route 18: 人民广场 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404612&idx=1&sn=f59aa03343308d9d10d51b3c03b4adb5#rd";
                    }
                    break;
                case "RR19":
                    {
                        title = "RR19";
                        description = "Route 19: 宜山路桂林路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404460&idx=1&sn=95a8626e5da9e5abc31f50b81cdd7056#rd";
                    }
                    break;
                case "RR20":
                    {
                        title = "RR20";
                        description = "Route 20: 静安寺 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404397&idx=1&sn=e8f269d74e84327f687ffbaae034120e#rd";
                    }
                    break;

                case "RR21":
                    {
                        title = "RR21";
                        description = "Route 21: 龙茗路顾戴路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404305&idx=1&sn=c3f6952747eb4437149c8ca35320ef4e#rd";
                    }
                    break;
                case "RR22":
                    {
                        title = "RR22";
                        description = "Route 22: 莘庄地铁站 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404225&idx=1&sn=43a4ee3e43093e67118a6f452b62bfe0#rd";
                    }
                    break;
                case "RR23":
                    {
                        title = "RR23";
                        description = "Route 23: 莘松路春九路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404158&idx=1&sn=21be44c680b3e27d64bc55793fa6302c#rd";
                    }
                    break;
                case "RR32":
                    {
                        title = "RR32";
                        description = "Route 32: 锦绣路东建路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404105&idx=1&sn=df546c16d2a4772d8ab8850d97df8ee2#rd";
                    }
                    break;
                case "RR33":
                    {
                        title = "RR33";
                        description = "Route 33: 控江路双辽路－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204404031&idx=1&sn=94c130b98888f0f6d4e43c887ed71204#rd";
                    }
                    break;
                case "RR34":
                    {
                        title = "RR34";
                        description = "Route 34: 中春路 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204403964&idx=1&sn=d0a18eff225433f683328762c34e46bb#rd";
                    }
                    break;
                case "RR36":
                    {
                        title = "RR36";
                        description = "Route 36: 水产路地铁站－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204403891&idx=1&sn=fe3f0d4709c6e3f55c336abe0b66e901#rd";
                    }
                    break;
                case "RR37":
                    {
                        title = "RR37";
                        description = "Route 37: 九亭 － 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204403798&idx=1&sn=e1c597b380b0e59e0a6ff18a3846dc96#rd";
                    }
                    break;
                case "RR38":
                    {
                        title = "RR38";
                        description = "Route 38: 丰庄路－ 微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204403702&idx=1&sn=1083af38ca9c8c5c33300724d3624867#rd";
                    }
                    break;
                case "RR39":
                    {
                        title = "RR39";
                        description = "Route 39: 松江大学城－微软上海园区";
                        newsUrl = "http://mp.weixin.qq.com/s?__biz=MzA3OTc4MTU3Nw==&mid=204395194&idx=1&sn=dd67fe17998f138460b0d5b0cb5de017#rd";
                    }
                    break;
                #endregion

                case "XUJIAHUI":
                case "徐家汇":
                    ret = "WH1: 徐家汇 － 微软上海园区\r\nRT1: 徐家汇 － 微软上海园区\r\nRR20: 静安寺 － 微软上海园区";
                    break;
                case "XINZHUANG":
                case "莘庄":
                    ret = "RT3: 莘庄地铁站 － 微软上海园区\r\nRR22: 莘庄地铁站 － 微软上海园区\r\nWH1: 徐家汇 － 微软上海园区";
                    break;
                case "CENTURY AVENUE":
                case "世纪大道":
                    ret = "RR2: 栖山路苗圃路－微软上海园区\r\nRR3: 微软上海园区－东陆路\r\nRR9: 高科西路东明路－微软上海园区\r\nWH3: 世纪大道地铁站－微软上海园区";
                    break;
                case "PEOPLE SQUARE":
                case "人民广场":
                    ret = "RR18: 人民广场 － 微软上海园区";
                    break;
                default:
                    ret = "等等，我不太明白，你说什么？";
                    break;
            }

            bNeedSendNews = !string.IsNullOrEmpty(newsUrl);

            if (bNeedSendNews)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);

                responseMessage.Articles.Add(new Article()
                {
                    Description = description,
                    PicUrl = picUrl,
                    Title = title,
                    Url = newsUrl
                });
                return responseMessage;
            }

            var responseMsg = base.CreateResponseMessage<ResponseMessageText>();
            responseMsg.Content = ret;
            return responseMsg;
        }

        //public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage) {}
        //public override IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage) { }

        //public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage) { }
        //public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage) { }

        public override void Execute()
        {
            base.Execute();
        }

        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您来了。";
            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "什么？您要走啊？！";
            return responseMessage;
        }

    }
}