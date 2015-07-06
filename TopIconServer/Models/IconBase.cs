using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopIconServer.Models
{
    /// <summary>
    /// 图标基类
    /// </summary>
    public class IconBase : Entity
    {
        public string IconsetID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}