using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISay.Models
{
    public class ParameterDefault
    {

    }

    public class PostType
    {
        List<string> list = new List<string>();

        public List<string> returnList()
        {
            list.Add("BossSay");
            list.Add("Travel");

            return list;
        }
    }

    public class ErrMsg
    {
        List<string> ErrMsg_CN = new List<string>();
        List<string> ErrMsg_EN = new List<string>();

        public List<string> returnList_CN()
        {
            ErrMsg_CN.Add("你冷靜一點，手不要發抖!");
            ErrMsg_CN.Add("這種東西是很講天分的!");
            ErrMsg_CN.Add("這不科學，逆天了!");
            ErrMsg_CN.Add("嚇不倒我的，404你知道的!");
            ErrMsg_CN.Add("豈有此理，看來你也非等閒之輩!");

            return ErrMsg_CN;
        }

        public List<string> returnList_EN()
        {
            ErrMsg_EN.Add("Please Calm Down. Don't Shock!");
            ErrMsg_EN.Add("That Needs Some Talent!");
            ErrMsg_EN.Add("No Explain. You should know what is 404!");
            ErrMsg_EN.Add("OOPs.It's Unreasonable!");
            ErrMsg_EN.Add("I Know. That Doesn't Make Sense!");

            return ErrMsg_EN;
        }
    }
}